using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService
{
    public class StockPriceFetcherService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _stocks = new List<(string, string, string, long)>
            {
                ("INFY", "NSE", "Infosys", 1),
              //("RELIANCE", "NSE", "Reliance Industries", 2),
              //("TCS", "NSE", "Tata Consultancy Services", 3),
              //("HDFCBANK", "NSE", "HDFC Bank", 4),
              //("ICICIBANK", "NSE", "ICICI Bank", 5),
              //("HINDUNILVR", "NSE", "Hindustan Unilever", 6),
              //("ITC", "NSE", "ITC Limited", 7),
              //("KOTAKBANK", "NSE", "Kotak Mahindra Bank", 8),
              //("LT", "NSE", "Larsen & Toubro", 9),
              //("SBIN", "NSE", "State Bank of India", 10),
              //("AXISBANK", "NSE", "Axis Bank", 11),
              //("BAJFINANCE", "NSE", "Bajaj Finance", 12)
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            List<double> iterationTimes = new();

            while (!stoppingToken.IsCancellationRequested)
            {
                var stopwatch = Stopwatch.StartNew();

                var tasks = _stocks.Select(stock => Task.Run(async () =>
                {
                    try
                    {
                        using var response = await _httpClient.GetAsync(
                            $"https://localhost:7237/api/Stock/price{stock.id}?ticker={stock.ticker}&exchange={stock.exchange}",
                            stoppingToken);

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync(stoppingToken);
                            var stockData = JsonSerializer.Deserialize<StockDataDto>(content);

                            if (stockData != null)
                            {
                                var stockPrice = new StockPricePerSec
                                {
                                    Ticker = stock.ticker,
                                    TickerId = stock.id,
                                    StockDateTime = stockData.time,
                                    StockPrice = stockData.price
                                };

                                var jsonContent = new StringContent(
                                    JsonSerializer.Serialize(stockPrice), Encoding.UTF8, "application/json");

                                using var postResponse = await _httpClient.PostAsync(
                                    $"https://localhost:7237/api/StockPricePerSec/addStockPrice{stock.id}",
                                    jsonContent,
                                    stoppingToken);

                                if (!postResponse.IsSuccessStatusCode)
                                {
                                    // Log the failure
                                }
                            }
                        }
                        else
                        {
                            // Log the failure
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                    }
                }, stoppingToken));

                // Wait for all tasks to complete.
                await Task.WhenAll(tasks);
                stopwatch.Stop();

                iterationTimes.Add(stopwatch.Elapsed.TotalMilliseconds);

                // Trigger garbage collection periodically
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // Delay for half a second
                await Task.Delay(20, stoppingToken);
            }
        }
    }

}
