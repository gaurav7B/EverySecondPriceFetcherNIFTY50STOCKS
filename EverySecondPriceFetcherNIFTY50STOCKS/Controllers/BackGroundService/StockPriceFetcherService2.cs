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
    public class StockPriceFetcherService2 : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StockPriceFetcherService2> _logger;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService2(HttpClient httpClient, ILogger<StockPriceFetcherService2> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _stocks = new List<(string, string, string, long)>
            {
                ("BHARTIARTL", "NSE", "Bharti Airtel", 13),
                ("HCLTECH", "NSE", "HCL Technologies", 14),
                ("ASIANPAINT", "NSE", "Asian Paints", 15),
                ("DMART", "NSE", "Avenue Supermarts", 16),
                ("MARUTI", "NSE", "Maruti Suzuki India", 17),
                ("SUNPHARMA", "NSE", "Sun Pharmaceutical Industries", 18),
                ("NTPC", "NSE", "NTPC Limited", 19),
                ("TITAN", "NSE", "Titan Company", 20),
                ("POWERGRID", "NSE", "Power Grid Corporation", 21),
                ("ULTRACEMCO", "NSE", "UltraTech Cement", 22),
                ("WIPRO", "NSE", "Wipro", 23),
                ("TECHM", "NSE", "Tech Mahindra", 24)
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

                // Trigger garbage collection periodically
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            _logger.LogInformation("Stock price fetcher service stopped.");
        }

    }
}

