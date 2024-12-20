using System.Diagnostics;
using System.Text.Json;
using System.Text;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;

namespace CandelMakerServices.Controllers.StratergicServices
{
    public class ThreeWhiteSoilders : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly List<(string ticker, string exchange, string name, long id)> _stocks;

        public ThreeWhiteSoilders(HttpClient httpClient)
        {
            _httpClient = httpClient;

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
                        var response = await _httpClient.GetAsync($"https://localhost:7237/api/StockPricePerSec/GetForCandel?ticker={stock.ticker}");

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var candelData = JsonSerializer.Deserialize<Candel>(content);

                            if (candelData != null)
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {
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

        }

    }
}
