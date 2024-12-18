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

        // POST: api/StockPricePerSec
        [HttpPost]
        public async Task<ActionResult<StockPricePerSec>> PostStockPricePerSec(StockPricePerSec stockPricePerSec)
        {
            _context.StockPricePerSec.Add(stockPricePerSec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockPricePerSec", new { id = stockPricePerSec.Id }, stockPricePerSec);
        }

    }
}
