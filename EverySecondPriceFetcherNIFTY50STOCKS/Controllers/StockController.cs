using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public StockController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("price")]
        public async Task<IActionResult> GetStockPriceByTicker(string ticker, string exchange)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            var response = await _httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var priceNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'YMlKec fxKbKc')]");
            if (priceNode == null)
            {
                return NotFound("Price not found.");
            }

            var priceText = priceNode.InnerText.Trim();
            if (!decimal.TryParse(priceText.Substring(1).Replace(",", ""), out var price))
            {
                return BadRequest("Failed to parse price.");
            }

            var stockData = new StockDataDto
            {
                time = DateTime.Now,
                price = price
            };

            return Ok(stockData);
        }

    }
}
