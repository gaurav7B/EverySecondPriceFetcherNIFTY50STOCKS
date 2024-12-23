
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using HtmlAgilityPack; // Make sure to include this package via NuGet
using System.Diagnostics;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using System.Text.Json;

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
                ("BPCL", "NSE", "Bharat Petroleum Corporation", 33),
                // Add other stocks as necessary
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
                        // Using the logic from your provided code to fetch the stock price from Google Finance
                        var url = $"https://www.google.com/finance/quote/{stock.ticker}:{stock.exchange}";

                        // Fetch the page content
                        var response = await _httpClient.GetStringAsync(url, stoppingToken);

                        var htmlDoc = new HtmlDocument();
                        htmlDoc.LoadHtml(response);

                        // Parse the stock price
                        var priceNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'YMlKec fxKbKc')]");

                        if (priceNode != null)
                        {
                            var priceText = priceNode.InnerText.Trim();
                            if (decimal.TryParse(priceText.Substring(1).Replace(",", ""), out var price)) // Remove the currency symbol and commas
                            {
                                // Prepare stock data to store
                                var stockData = new StockDataDto
                                {
                                    time = DateTime.Now,
                                    price = (decimal)(double)price // Casting to double to fit the existing model
                                };

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
                            else
                            {
                                // Log the failure in parsing the price
                            }
                        }
                        else
                        {
                            // Log the failure if the price node is not found
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

                // Delay for half a second (if needed)
                //await Task.Delay(20, stoppingToken);
            }
        }
    }
}

