using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using System.Diagnostics;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService
{
    public class StockPriceFetcherService3 : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StockPriceFetcherService3> _logger;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService3(HttpClient httpClient, ILogger<StockPriceFetcherService3> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _stocks = new List<(string, string, string, long)>
            {
                ("BAJAJFINSV", "NSE", "Bajaj Finserv", 25),
                ("ONGC", "NSE", "Oil and Natural Gas Corporation", 26),
                ("HDFCLIFE", "NSE", "HDFC Life Insurance", 27),
                ("SBILIFE", "NSE", "SBI Life Insurance", 28),
                ("M%26M", "NSE", "Mahindra & Mahindra", 29),
                ("DIVISLAB", "NSE", "Divi's Laboratories", 30)
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Stock price fetcher service started.");

            List<double> iterationTimes = new();


            while (!stoppingToken.IsCancellationRequested)
            {
                var stopwatch = Stopwatch.StartNew();

                var tasks = _stocks.Select(stock => Task.Run(async () =>
                {
                    try
                    {
                        var response = await _httpClient.GetAsync($"https://localhost:7237/api/Stock/price{stock.id}?ticker={stock.ticker}&exchange={stock.exchange}", stoppingToken);

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

                                var jsonContent = new StringContent(JsonSerializer.Serialize(stockPrice), Encoding.UTF8, "application/json");
                                var postResponse = await _httpClient.PostAsync($"https://localhost:7237/api/StockPricePerSec/addStockPrice{stock.id}", jsonContent, stoppingToken);

                                if (!postResponse.IsSuccessStatusCode)
                                {
                                    _logger.LogError($"Failed to post stock price for {stock.ticker}. Status Code: {postResponse.StatusCode}");
                                }
                            }
                        }
                        else
                        {
                            _logger.LogError($"Failed to fetch stock price for {stock.ticker}. Status Code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error occurred while processing stock {stock.ticker}");
                    }
                }, stoppingToken));

                // Wait for all tasks to complete.
                await Task.WhenAll(tasks);

                stopwatch.Stop();
                iterationTimes.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            _logger.LogInformation("Stock price fetcher service stopped.");
        }


    }
}
