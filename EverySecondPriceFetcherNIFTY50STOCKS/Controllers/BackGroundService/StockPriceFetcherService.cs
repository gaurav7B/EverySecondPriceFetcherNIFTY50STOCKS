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
    public class StockPriceFetcherService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StockPriceFetcherService> _logger;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public StockPriceFetcherService(HttpClient httpClient, ILogger<StockPriceFetcherService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _stocks = new List<(string, string, string, long)>
            {
                ("INFY", "NSE", "Infosys", 1),
                ("RELIANCE", "NSE", "Reliance Industries", 2),
                ("TCS", "NSE", "Tata Consultancy Services", 3),
                ("HDFCBANK", "NSE", "HDFC Bank", 4),
                ("ICICIBANK", "NSE", "ICICI Bank", 5),
                ("HINDUNILVR", "NSE", "Hindustan Unilever", 6),
                ("ITC", "NSE", "ITC Limited", 7),
                ("KOTAKBANK", "NSE", "Kotak Mahindra Bank", 8),
                ("LT", "NSE", "Larsen & Toubro", 9),
                ("SBIN", "NSE", "State Bank of India", 10),
                ("AXISBANK", "NSE", "Axis Bank", 11),
                ("BAJFINANCE", "NSE", "Bajaj Finance", 12)

                //                ("INFY", "NSE", "Infosys", 1),
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
                //("BAJFINANCE", "NSE", "Bajaj Finance", 12),
                //("BHARTIARTL", "NSE", "Bharti Airtel", 13),
                //("HCLTECH", "NSE", "HCL Technologies", 14),
                //("ASIANPAINT", "NSE", "Asian Paints", 15),
                //("DMART", "NSE", "Avenue Supermarts", 16),
                //("MARUTI", "NSE", "Maruti Suzuki India", 17),
                //("SUNPHARMA", "NSE", "Sun Pharmaceutical Industries", 18),
                //("NTPC", "NSE", "NTPC Limited", 19),
                //("TITAN", "NSE", "Titan Company", 20),
                //("POWERGRID", "NSE", "Power Grid Corporation", 21),
                //("ULTRACEMCO", "NSE", "UltraTech Cement", 22),
                //("WIPRO", "NSE", "Wipro", 23),
                //("TECHM", "NSE", "Tech Mahindra", 24),
                //("BAJAJFINSV", "NSE", "Bajaj Finserv", 25),
                //("ONGC", "NSE", "Oil and Natural Gas Corporation", 26),
                //("HDFCLIFE", "NSE", "HDFC Life Insurance", 27),
                //("SBILIFE", "NSE", "SBI Life Insurance", 28)


                //("M%26M", "NSE", "Mahindra & Mahindra", 29),
                //("DIVISLAB", "NSE", "Divi's Laboratories", 30),
                //("JSWSTEEL", "NSE", "JSW Steel", 31),
                //("ADANIENT", "NSE", "Adani Enterprises", 32),
                //("BPCL", "NSE", "Bharat Petroleum Corporation", 33),
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
