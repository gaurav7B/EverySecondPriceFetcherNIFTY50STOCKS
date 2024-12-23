//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Hosting;
//using System.Diagnostics;
//using EverySecondPriceFetcherNIFTY50STOCKS.Model;

//namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService
//{
//    public class StockPriceFetcherService2 : BackgroundService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

//        public StockPriceFetcherService2(HttpClient httpClient)
//        {
//            _httpClient = httpClient;

//            _stocks = new List<(string, string, string, long)>
//            {
//                //("JSWSTEEL", "NSE", "JSW Steel", 31),
//                ("ADANIENT", "NSE", "Adani Enterprises", 32),
//                //("BPCL", "NSE", "Bharat Petroleum Corporation", 33),
//                //("INDUSINDBK", "NSE", "IndusInd Bank", 34),
//                //("CIPLA", "NSE", "Cipla", 35),
//                //("DRREDDY", "NSE", "Dr. Reddy's Laboratories", 36),
//                //("ADANIPORTS", "NSE", "Adani Ports and SEZ", 37),
//                //("GRASIM", "NSE", "Grasim Industries", 38),
//                //("HEROMOTOCO", "NSE", "Hero MotoCorp", 39),
//                //("EICHERMOT", "NSE", "Eicher Motors", 40),
//                //("COALINDIA", "NSE", "Coal India", 41),
//                //("TATAMOTORS", "NSE", "Tata Motors", 42),
//                //("SHREECEM", "NSE", "Shree Cement", 43),
//                //("APOLLOHOSP", "NSE", "Apollo Hospitals", 44),
//                //("BRITANNIA", "NSE", "Britannia Industries", 45),
//                //("UPL", "NSE", "UPL Limited", 46),
//                //("PIDILITIND", "NSE", "Pidilite Industries", 47),
//                //("VEDL", "NSE", "Vedanta", 48),
//                //("BAJAJAUTO", "NSE", "Bajaj Auto", 49)
//            };
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            List<double> iterationTimes = new();

//            while (!stoppingToken.IsCancellationRequested)
//            {
//                var stopwatch = Stopwatch.StartNew();

//                var tasks = _stocks.Select(stock => Task.Run(async () =>
//                {
//                    try
//                    {
//                        using var response = await _httpClient.GetAsync(
//                            $"https://localhost:7237/api/Stock/price{stock.id}?ticker={stock.ticker}&exchange={stock.exchange}",
//                            stoppingToken);

//                        if (response.IsSuccessStatusCode)
//                        {
//                            var content = await response.Content.ReadAsStringAsync(stoppingToken);
//                            var stockData = JsonSerializer.Deserialize<StockDataDto>(content);

//                            if (stockData != null)
//                            {
//                                var stockPrice = new StockPricePerSec
//                                {
//                                    Ticker = stock.ticker,
//                                    TickerId = stock.id,
//                                    StockDateTime = stockData.time,
//                                    StockPrice = stockData.price
//                                };

//                                var jsonContent = new StringContent(
//                                    JsonSerializer.Serialize(stockPrice), Encoding.UTF8, "application/json");

//                                using var postResponse = await _httpClient.PostAsync(
//                                    $"https://localhost:7237/api/StockPricePerSec/addStockPrice{stock.id}",
//                                    jsonContent,
//                                    stoppingToken);

//                                if (!postResponse.IsSuccessStatusCode)
//                                {
//                                    // Log the failure
//                                }
//                            }
//                        }
//                        else
//                        {
//                            // Log the failure
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        // Log the exception
//                    }
//                }, stoppingToken));

//                // Wait for all tasks to complete.
//                await Task.WhenAll(tasks);
//                stopwatch.Stop();

//                iterationTimes.Add(stopwatch.Elapsed.TotalMilliseconds);

//                // Trigger garbage collection periodically
//                GC.Collect();
//                GC.WaitForPendingFinalizers();

//                // Delay for half a second
//                //await Task.Delay(20, stoppingToken);
//            }
//        }
//    }

//}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Hosting;
//using System.Diagnostics;
//using EverySecondPriceFetcherNIFTY50STOCKS.Model;

//namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService
//{
//    public class StockPriceFetcherService : BackgroundService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

//        public StockPriceFetcherService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;

//            _stocks = new List<(string, string, string, long)>
//            {
//                ("JSWSTEEL", "NSE", "JSW Steel", 31),
//                //("ADANIENT", "NSE", "Adani Enterprises", 32),
//                //("BPCL", "NSE", "Bharat Petroleum Corporation", 33),
//                //("INDUSINDBK", "NSE", "IndusInd Bank", 34),
//                //("CIPLA", "NSE", "Cipla", 35),
//                //("DRREDDY", "NSE", "Dr. Reddy's Laboratories", 36),
//                //("ADANIPORTS", "NSE", "Adani Ports and SEZ", 37),
//                //("GRASIM", "NSE", "Grasim Industries", 38),
//                //("HEROMOTOCO", "NSE", "Hero MotoCorp", 39),
//                //("EICHERMOT", "NSE", "Eicher Motors", 40),
//                //("COALINDIA", "NSE", "Coal India", 41),
//                //("TATAMOTORS", "NSE", "Tata Motors", 42),
//                //("SHREECEM", "NSE", "Shree Cement", 43),
//                //("APOLLOHOSP", "NSE", "Apollo Hospitals", 44),
//                //("BRITANNIA", "NSE", "Britannia Industries", 45),
//                //("UPL", "NSE", "UPL Limited", 46),
//                //("PIDILITIND", "NSE", "Pidilite Industries", 47),
//                //("VEDL", "NSE", "Vedanta", 48),
//                //("BAJAJAUTO", "NSE", "Bajaj Auto", 49)
//            };
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            List<double> iterationTimes = new();

//            while (!stoppingToken.IsCancellationRequested)
//            {
//                var stopwatch = Stopwatch.StartNew();

//                var tasks = _stocks.Select(stock => Task.Run(async () =>
//                {
//                    try
//                    {
//                        using var response = await _httpClient.GetAsync(
//                            $"https://localhost:7237/api/Stock/price{stock.id}?ticker={stock.ticker}&exchange={stock.exchange}",
//                            stoppingToken);

//                        if (response.IsSuccessStatusCode)
//                        {
//                            var content = await response.Content.ReadAsStringAsync(stoppingToken);
//                            var stockData = JsonSerializer.Deserialize<StockDataDto>(content);

//                            if (stockData != null)
//                            {
//                                var stockPrice = new StockPricePerSec
//                                {
//                                    Ticker = stock.ticker,
//                                    TickerId = stock.id,
//                                    StockDateTime = stockData.time,
//                                    StockPrice = stockData.price
//                                };

//                                var jsonContent = new StringContent(
//                                    JsonSerializer.Serialize(stockPrice), Encoding.UTF8, "application/json");

//                                using var postResponse = await _httpClient.PostAsync(
//                                    $"https://localhost:7237/api/StockPricePerSec/addStockPrice{stock.id}",
//                                    jsonContent,
//                                    stoppingToken);

//                                if (!postResponse.IsSuccessStatusCode)
//                                {
//                                    // Log the failure
//                                }
//                            }
//                        }
//                        else
//                        {
//                            // Log the failure
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        // Log the exception
//                    }
//                }, stoppingToken));

//                // Wait for all tasks to complete.
//                await Task.WhenAll(tasks);
//                stopwatch.Stop();

//                iterationTimes.Add(stopwatch.Elapsed.TotalMilliseconds);

//                // Trigger garbage collection periodically
//                GC.Collect();
//                GC.WaitForPendingFinalizers();

//                // Delay for half a second
//                //await Task.Delay(20, stoppingToken);
//            }
//        }
//    }

//}



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
    public class StockPriceFetcherService2 : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService2(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _stocks = new List<(string, string, string, long)>
            {
                ("ADANIENT", "NSE", "Adani Enterprises", 32),
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


