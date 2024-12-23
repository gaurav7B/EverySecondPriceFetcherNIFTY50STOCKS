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
    public class StockPriceFetcherService3 : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService3(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _stocks = new List<(string, string, string, long)>
            {
                //("JSWSTEEL", "NSE", "JSW Steel", 31),
                //("ADANIENT", "NSE", "Adani Enterprises", 32),
                ("BPCL", "NSE", "Bharat Petroleum Corporation", 33),
                //("INDUSINDBK", "NSE", "IndusInd Bank", 34),
                //("CIPLA", "NSE", "Cipla", 35),
                //("DRREDDY", "NSE", "Dr. Reddy's Laboratories", 36),
                //("ADANIPORTS", "NSE", "Adani Ports and SEZ", 37),
                //("GRASIM", "NSE", "Grasim Industries", 38),
                //("HEROMOTOCO", "NSE", "Hero MotoCorp", 39),
                //("EICHERMOT", "NSE", "Eicher Motors", 40),
                //("COALINDIA", "NSE", "Coal India", 41),
                //("TATAMOTORS", "NSE", "Tata Motors", 42),
                //("SHREECEM", "NSE", "Shree Cement", 43),
                //("APOLLOHOSP", "NSE", "Apollo Hospitals", 44),
                //("BRITANNIA", "NSE", "Britannia Industries", 45),
                //("UPL", "NSE", "UPL Limited", 46),
                //("PIDILITIND", "NSE", "Pidilite Industries", 47),
                //("VEDL", "NSE", "Vedanta", 48),
                //("BAJAJAUTO", "NSE", "Bajaj Auto", 49)
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
                //await Task.Delay(20, stoppingToken);
            }
        }
    }

}
