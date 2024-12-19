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

        [HttpGet("price1")]
        public async Task<IActionResult> GetStockPriceByTicker1(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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

        [HttpGet("price2")]
        public async Task<IActionResult> GetStockPriceByTicker2(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price3")]
        public async Task<IActionResult> GetStockPriceByTicker3(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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

        [HttpGet("price4")]
        public async Task<IActionResult> GetStockPriceByTicker4(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price5")]
        public async Task<IActionResult> GetStockPriceByTicker5(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price6")]
        public async Task<IActionResult> GetStockPriceByTicker6(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price7")]
        public async Task<IActionResult> GetStockPriceByTicker7(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price8")]
        public async Task<IActionResult> GetStockPriceByTicker8(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price9")]
        public async Task<IActionResult> GetStockPriceByTicker9(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price10")]
        public async Task<IActionResult> GetStockPriceByTicker10(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price11")]
        public async Task<IActionResult> GetStockPriceByTicker11(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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





        [HttpGet("price12")]
        public async Task<IActionResult> GetStockPriceByTicker12(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price13")]
        public async Task<IActionResult> GetStockPriceByTicker13(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price14")]
        public async Task<IActionResult> GetStockPriceByTicker14(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price15")]
        public async Task<IActionResult> GetStockPriceByTicker15(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price16")]
        public async Task<IActionResult> GetStockPriceByTicker16(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price17")]
        public async Task<IActionResult> GetStockPriceByTicker17(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price18")]
        public async Task<IActionResult> GetStockPriceByTicker18(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price19")]
        public async Task<IActionResult> GetStockPriceByTicker19(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price20")]
        public async Task<IActionResult> GetStockPriceByTicker20(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price21")]
        public async Task<IActionResult> GetStockPriceByTicker21(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price22")]
        public async Task<IActionResult> GetStockPriceByTicker22(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price23")]
        public async Task<IActionResult> GetStockPriceByTicker23(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price24")]
        public async Task<IActionResult> GetStockPriceByTicker24(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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




        [HttpGet("price25")]
        public async Task<IActionResult> GetStockPriceByTicker25(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price26")]
        public async Task<IActionResult> GetStockPriceByTicker26(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price27")]
        public async Task<IActionResult> GetStockPriceByTicker27(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price28")]
        public async Task<IActionResult> GetStockPriceByTicker28(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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


        [HttpGet("price29")]
        public async Task<IActionResult> GetStockPriceByTicker29(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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



        [HttpGet("price30")]
        public async Task<IActionResult> GetStockPriceByTicker30(string ticker, string exchange, CancellationToken cancellationToken)
        {
            var requestDto = new GetStockPriceRequestDto
            {
                Ticker = ticker,
                Exchange = exchange
            };

            var url = $"https://www.google.com/finance/quote/{requestDto.Ticker}:{requestDto.Exchange}";

            string response;
            try
            {
                // Pass cancellation token to support graceful stopping.
                response = await _httpClient.GetStringAsync(url, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully.
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Request canceled.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

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
