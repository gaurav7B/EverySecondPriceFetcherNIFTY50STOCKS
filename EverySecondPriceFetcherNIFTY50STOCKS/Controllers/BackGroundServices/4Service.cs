using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Newtonsoft.Json;
using Polly;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace StockLogger.BackgroundServices.BackGroundServiceForEach
{
    public class _4Service : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;  // Inject IHttpClientFactory
        private bool _isRunning = true;
        private int ID = 4;

        public _4Service(IHttpClientFactory httpClientFactory)
        {
            _httpClient = new HttpClient();
            _httpClientFactory = httpClientFactory;  // Assign IHttpClientFactory
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await PriceMaker(); // Ensure PriceMaker completes before the next iteration starts.
            }
        }

        // Method to fetch stock TICKER and EXCHANGE data from the API
        private async Task<IEnumerable<StockTickerExchange>> GetStockTickerExchanges()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7237/api/StockTickerExchange");
                if (response.IsSuccessStatusCode)
                {
                    var stockTickerExchangesJson = await response.Content.ReadAsStringAsync();

                    var stockTickerExchanges = JsonConvert.DeserializeObject<IEnumerable<StockTickerExchange>>(stockTickerExchangesJson);

                    return stockTickerExchanges;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task PriceSecMaker(long Id, string ticker, string exchange)
        {

            var response = await _httpClient.GetAsync($"https://localhost:7237/api/Stock/price?ticker={ticker}&exchange={exchange}"); // API to get the TICKER time and price

            if (response.IsSuccessStatusCode)
            {
                var stockDataJson = await response.Content.ReadAsStringAsync();
                // Assuming the response is a JSON object containing "time" and "price"
                var stockData = JsonConvert.DeserializeObject<StockDataDto>(stockDataJson);

                if (stockData != null)
                {
                    var stockPricePayload = new StockPricePerSec
                    {
                        Ticker = ticker,
                        TickerId = Id,
                        StockDateTime = stockData.time,
                        StockPrice = stockData.price,
                    };

                    // Serialize the object to JSON
                    var jsonPayload = JsonConvert.SerializeObject(stockPricePayload);

                    // Create the HttpContent with the JSON data
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Send the request
                    var postResponse = await _httpClient.PostAsync("https://localhost:7237/api/StockPricePerSec", content);

                    if (postResponse.IsSuccessStatusCode)
                    {

                    }
                }
            }
        }

        private async Task PriceMaker()
        {
            var currentMinute = DateTime.Now.Second;

            var stocks = (await GetStockTickerExchanges())?.Select(x => new { x.Id, x.Ticker, x.Exchange }).Where(x => x.Id == ID).ToArray(); // Get the Stocks
            var stockTasks = stocks.Select(stock => PriceSecMaker((long)stock.Id, stock.Ticker, stock.Exchange)); // Create tasks dynamically for each stock

            await Task.WhenAll(stockTasks); // Process all tasks in parallel
        }
    }
}
