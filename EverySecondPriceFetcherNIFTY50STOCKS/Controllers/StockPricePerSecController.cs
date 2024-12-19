﻿using Microsoft.AspNetCore.Mvc;
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



















    }
}
