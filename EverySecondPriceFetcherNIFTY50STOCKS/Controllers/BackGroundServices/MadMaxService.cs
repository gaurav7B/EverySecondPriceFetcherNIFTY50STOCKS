using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Newtonsoft.Json;
using Polly;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace StockLogger.BackgroundServices.BackGroundServiceForEach
{
    public class MadMaxService : BackgroundService
    {
        private readonly ILogger<MadMaxService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;  // Inject IHttpClientFactory
        private bool _isRunning = true;

        public MadMaxService(ILogger<MadMaxService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClientFactory = httpClientFactory;  // Assign IHttpClientFactory
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var stocks = (await GetStockTickerExchanges())?.Select(x => new { x.Id, x.Ticker, x.Exchange }).ToArray();

                var stockTasks = stocks.Select(stock => CandelMaker((int)stock.Id, stock.Ticker, stock.Exchange)); // Create tasks dynamically for each stock
                await Task.WhenAll(stockTasks); // Process all tasks in parallel
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
                _logger.LogError(ex, "Error fetching stock ticker exchanges.");
                return null;
            }
        }

        private async Task CandelMaker(int id, string ticker, string exchange)
        {
            
        }
    }
}
