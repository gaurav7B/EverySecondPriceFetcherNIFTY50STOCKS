using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPricePerSecController : ControllerBase
    {
        private readonly StockLogger2DbContext _context;

        public StockPricePerSecController(StockLogger2DbContext context)
        {
            _context = context;
        }


        //1 MIN
        // GET: https://localhost:7237/api/StockPricePerSec/GetCandel?ticker=INFY
        [HttpGet("GetCandel")]
        public async Task<IActionResult> MakeMinCandel([FromQuery] string ticker)
        {
            // Fetch data from the database based on the ticker
            var query = _context.StockPricePerSec
                                .Where(sp => sp.Ticker == ticker)
                                .OrderBy(sp => sp.StockDateTime); // Ensure the data is sorted by time

            var result = await query.ToListAsync();

            // Grouping stock prices by minute (rounded to the nearest minute)
            var groupedResult = result
                                .GroupBy(sp => new DateTime(
                                    sp.StockDateTime.Year,
                                    sp.StockDateTime.Month,
                                    sp.StockDateTime.Day,
                                    sp.StockDateTime.Hour,
                                    sp.StockDateTime.Minute,
                                    0))
                                .Select(g => g.ToList())
                                .ToList();

            StockPricePerSec firstStockPrice = null;
            StockPricePerSec highestStockPrice = null;
            StockPricePerSec lowestStockPrice = null;
            StockPricePerSec lastStockPrice = null;

            List<Candel> CandelList = new List<Candel>();

            if (groupedResult != null)
            {
                foreach (List<StockPricePerSec> sp in groupedResult)
                {
                    firstStockPrice = GetFirstStockPrice(sp);
                    highestStockPrice = GetHighestStockPrice(sp);
                    lowestStockPrice = GetLowestStockPrice(sp);
                    lastStockPrice = GetLastStockPrice(sp);

                    var CandelPayLoad = new Candel
                    {
                        StartPrice = firstStockPrice.StockPrice,  // Use the first price from the list
                        HighestPrice = highestStockPrice.StockPrice, // Get the highest price from the list
                        LowestPrice = lowestStockPrice.StockPrice,  // Get the lowest price from the list
                        EndPrice = lastStockPrice.StockPrice,     // Use the last price from the list

                        OpenTime = firstStockPrice.StockDateTime,
                        CloseTime = lastStockPrice.StockDateTime,

                        Ticker = firstStockPrice.Ticker,
                        TickerId = firstStockPrice.TickerId,
                        Exchange = "NSE",
                    };

                    // Set the BullBear status based on your logic
                    CandelPayLoad.SetBullBearStatus();
                    CandelPayLoad.SetPriceChange();

                    CandelList.Add(CandelPayLoad);
                }
            }

            // Return the list of candles in JSON format
            return new JsonResult(CandelList);
        }






        //5 MIN
        // GET: https://localhost:7237/api/StockPricePerSec/Get5MinCandel?ticker=INFY
        [HttpGet("Get5MinCandel")]
        public async Task<IActionResult> Make5MinCandel([FromQuery] string ticker)
        {
            // Fetch data from the database based on the ticker
            var query = _context.StockPricePerSec
                                .Where(sp => sp.Ticker == ticker)
                                .OrderBy(sp => sp.StockDateTime); // Ensure the data is sorted by time

            var result = await query.ToListAsync();

            // Grouping stock prices by minute (rounded to the nearest minute)
            var groupedBy5Min = result
                .GroupBy(sp => new DateTime(
                    sp.StockDateTime.Year,
                    sp.StockDateTime.Month,
                    sp.StockDateTime.Day,
                    sp.StockDateTime.Hour,
                    sp.StockDateTime.Minute / 5 * 5,
                    0))
                .Select(g => g.ToList())
                .ToList();

            StockPricePerSec firstStockPrice = null;
            StockPricePerSec highestStockPrice = null;
            StockPricePerSec lowestStockPrice = null;
            StockPricePerSec lastStockPrice = null;

            List<Candel> CandelList = new List<Candel>();

            if (groupedBy5Min != null)
            {
                foreach (List<StockPricePerSec> sp in groupedBy5Min)
                {
                    firstStockPrice = GetFirstStockPrice(sp);
                    highestStockPrice = GetHighestStockPrice(sp);
                    lowestStockPrice = GetLowestStockPrice(sp);
                    lastStockPrice = GetLastStockPrice(sp);

                    var CandelPayLoad = new Candel
                    {
                        StartPrice = firstStockPrice.StockPrice,  // Use the first price from the list
                        HighestPrice = highestStockPrice.StockPrice, // Get the highest price from the list
                        LowestPrice = lowestStockPrice.StockPrice,  // Get the lowest price from the list
                        EndPrice = lastStockPrice.StockPrice,     // Use the last price from the list

                        OpenTime = firstStockPrice.StockDateTime,
                        CloseTime = lastStockPrice.StockDateTime,

                        Ticker = firstStockPrice.Ticker,
                        TickerId = firstStockPrice.TickerId,
                        Exchange = "NSE",
                    };

                    // Set the BullBear status based on your logic
                    CandelPayLoad.SetBullBearStatus();
                    CandelPayLoad.SetPriceChange();

                    CandelList.Add(CandelPayLoad);
                }
            }

            // Return the list of candles in JSON format
            return new JsonResult(CandelList);
        }


        //10 MIN
        // GET: https://localhost:7237/api/StockPricePerSec/Get10MinCandel?ticker=INFY
        [HttpGet("Get10MinCandel")]
        public async Task<IActionResult> Make10MinCandel([FromQuery] string ticker)
        {
            // Fetch data from the database based on the ticker
            var query = _context.StockPricePerSec
                                .Where(sp => sp.Ticker == ticker)
                                .OrderBy(sp => sp.StockDateTime); // Ensure the data is sorted by time

            var result = await query.ToListAsync();

            // Grouping stock prices by minute (rounded to the nearest 10 minutes)
            var groupedBy10Min = result
                .GroupBy(sp => new DateTime(
                    sp.StockDateTime.Year,
                    sp.StockDateTime.Month,
                    sp.StockDateTime.Day,
                    sp.StockDateTime.Hour,
                    sp.StockDateTime.Minute / 10 * 10,
                    0))
                .Select(g => g.ToList())
                .ToList();

            List<Candel> CandelList = new List<Candel>();

            if (groupedBy10Min != null)
            {
                foreach (var sp in groupedBy10Min)
                {
                    var firstStockPrice = GetFirstStockPrice(sp);
                    var highestStockPrice = GetHighestStockPrice(sp);
                    var lowestStockPrice = GetLowestStockPrice(sp);
                    var lastStockPrice = GetLastStockPrice(sp);

                    var CandelPayLoad = new Candel
                    {
                        StartPrice = firstStockPrice.StockPrice,
                        HighestPrice = highestStockPrice.StockPrice,
                        LowestPrice = lowestStockPrice.StockPrice,
                        EndPrice = lastStockPrice.StockPrice,

                        OpenTime = firstStockPrice.StockDateTime,
                        CloseTime = lastStockPrice.StockDateTime,

                        Ticker = firstStockPrice.Ticker,
                        TickerId = firstStockPrice.TickerId,
                        Exchange = "NSE",
                    };

                    CandelPayLoad.SetBullBearStatus();
                    CandelPayLoad.SetPriceChange();

                    CandelList.Add(CandelPayLoad);
                }
            }

            return new JsonResult(CandelList);
        }


        //15 MIN
        // GET: https://localhost:7237/api/StockPricePerSec/Get15MinCandel?ticker=INFY
        [HttpGet("Get15MinCandel")]
        public async Task<IActionResult> Make15MinCandel([FromQuery] string ticker)
        {
            // Fetch data from the database based on the ticker
            var query = _context.StockPricePerSec
                                .Where(sp => sp.Ticker == ticker)
                                .OrderBy(sp => sp.StockDateTime); // Ensure the data is sorted by time

            var result = await query.ToListAsync();

            // Grouping stock prices by minute (rounded to the nearest 15 minutes)
            var groupedBy15Min = result
                .GroupBy(sp => new DateTime(
                    sp.StockDateTime.Year,
                    sp.StockDateTime.Month,
                    sp.StockDateTime.Day,
                    sp.StockDateTime.Hour,
                    sp.StockDateTime.Minute / 15 * 15,
                    0))
                .Select(g => g.ToList())
                .ToList();

            List<Candel> CandelList = new List<Candel>();

            if (groupedBy15Min != null)
            {
                foreach (var sp in groupedBy15Min)
                {
                    var firstStockPrice = GetFirstStockPrice(sp);
                    var highestStockPrice = GetHighestStockPrice(sp);
                    var lowestStockPrice = GetLowestStockPrice(sp);
                    var lastStockPrice = GetLastStockPrice(sp);

                    var CandelPayLoad = new Candel
                    {
                        StartPrice = firstStockPrice.StockPrice,
                        HighestPrice = highestStockPrice.StockPrice,
                        LowestPrice = lowestStockPrice.StockPrice,
                        EndPrice = lastStockPrice.StockPrice,

                        OpenTime = firstStockPrice.StockDateTime,
                        CloseTime = lastStockPrice.StockDateTime,

                        Ticker = firstStockPrice.Ticker,
                        TickerId = firstStockPrice.TickerId,
                        Exchange = "NSE",
                    };

                    CandelPayLoad.SetBullBearStatus();
                    CandelPayLoad.SetPriceChange();

                    CandelList.Add(CandelPayLoad);
                }
            }

            return new JsonResult(CandelList);
        }


        public static StockPricePerSec GetHighestStockPrice(List<StockPricePerSec> stockList)
        {
            // Get the object with the highest StockPrice
            var highestStockPrice = stockList.OrderByDescending(stock => stock.StockPrice).FirstOrDefault();

            return highestStockPrice;
        }

        public static StockPricePerSec GetLowestStockPrice(List<StockPricePerSec> stockList)
        {
            // Get the object with the lowest StockPrice
            var lowestStockPrice = stockList.OrderBy(stock => stock.StockPrice).FirstOrDefault();

            return lowestStockPrice;
        }


        public static StockPricePerSec GetFirstStockPrice(List<StockPricePerSec> stockList)
        {
            // Get the first object in the list
            var firstStockPrice = stockList.FirstOrDefault();

            return firstStockPrice;
        }

        public static StockPricePerSec GetLastStockPrice(List<StockPricePerSec> stockList)
        {
            // Get the last object in the list
            var lastStockPrice = stockList.LastOrDefault();

            return lastStockPrice;
        }


        // POST: api/StockPricePerSec/addStockPrice
        [HttpPost("addStockPrice1")]
        public async Task<ActionResult> PostStockPrice1([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        // POST: api/StockPricePerSec/addStockPrice2
        [HttpPost("addStockPrice2")]
        public async Task<ActionResult> PostStockPrice2([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice3")]
        public async Task<ActionResult> PostStockPrice3([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice4")]
        public async Task<ActionResult> PostStockPrice4([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice5")]
        public async Task<ActionResult> PostStockPrice5([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice6")]
        public async Task<ActionResult> PostStockPrice6([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice7")]
        public async Task<ActionResult> PostStockPrice7([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice8")]
        public async Task<ActionResult> PostStockPrice8([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice9")]
        public async Task<ActionResult> PostStockPrice9([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice10")]
        public async Task<ActionResult> PostStockPrice10([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice11")]
        public async Task<ActionResult> PostStockPrice11([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice12")]
        public async Task<ActionResult> PostStockPrice12([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice13")]
        public async Task<ActionResult> PostStockPrice13([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice14")]
        public async Task<ActionResult> PostStockPrice14([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice15")]
        public async Task<ActionResult> PostStockPrice15([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice16")]
        public async Task<ActionResult> PostStockPrice16([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice17")]
        public async Task<ActionResult> PostStockPrice17([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice18")]
        public async Task<ActionResult> PostStockPrice18([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice19")]
        public async Task<ActionResult> PostStockPrice19([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice20")]
        public async Task<ActionResult> PostStockPrice20([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice21")]
        public async Task<ActionResult> PostStockPrice21([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice22")]
        public async Task<ActionResult> PostStockPrice22([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice23")]
        public async Task<ActionResult> PostStockPrice23([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice24")]
        public async Task<ActionResult> PostStockPrice24([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice25")]
        public async Task<ActionResult> PostStockPrice25([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice26")]
        public async Task<ActionResult> PostStockPrice26([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }



        [HttpPost("addStockPrice27")]
        public async Task<ActionResult> PostStockPrice27([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice28")]
        public async Task<ActionResult> PostStockPrice28([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }




        [HttpPost("addStockPrice29")]
        public async Task<ActionResult> PostStockPrice29([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }





        [HttpPost("addStockPrice30")]
        public async Task<ActionResult> PostStockPrice30([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                // Add the stock price data to the database context
                _context.StockPricePerSec.Add(stockPricePerSec);

                // Save changes asynchronously, passing the cancellation token
                await _context.SaveChangesAsync(cancellationToken);

                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation of the operation
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                // Log and handle exceptions gracefully
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("addStockPrice31")]
        public async Task<ActionResult> PostStockPrice31([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice32")]
        public async Task<ActionResult> PostStockPrice32([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice33")]
        public async Task<ActionResult> PostStockPrice33([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice34")]
        public async Task<ActionResult> PostStockPrice34([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice35")]
        public async Task<ActionResult> PostStockPrice35([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice36")]
        public async Task<ActionResult> PostStockPrice36([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice37")]
        public async Task<ActionResult> PostStockPrice37([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice38")]
        public async Task<ActionResult> PostStockPrice38([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice39")]
        public async Task<ActionResult> PostStockPrice39([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice40")]
        public async Task<ActionResult> PostStockPrice40([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice41")]
        public async Task<ActionResult> PostStockPrice41([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice42")]
        public async Task<ActionResult> PostStockPrice42([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice43")]
        public async Task<ActionResult> PostStockPrice43([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice44")]
        public async Task<ActionResult> PostStockPrice44([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice45")]
        public async Task<ActionResult> PostStockPrice45([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice46")]
        public async Task<ActionResult> PostStockPrice46([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice47")]
        public async Task<ActionResult> PostStockPrice47([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice48")]
        public async Task<ActionResult> PostStockPrice48([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice49")]
        public async Task<ActionResult> PostStockPrice49([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addStockPrice50")]
        public async Task<ActionResult> PostStockPrice50([FromBody] StockPricePerSec stockPricePerSec, CancellationToken cancellationToken)
        {
            if (stockPricePerSec == null)
            {
                return BadRequest("Invalid stock price data.");
            }

            try
            {
                _context.StockPricePerSec.Add(stockPricePerSec);
                await _context.SaveChangesAsync(cancellationToken);
                return Ok("Stock price data inserted successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Operation canceled.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

    }
}
