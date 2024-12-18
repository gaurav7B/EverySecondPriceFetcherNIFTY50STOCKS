using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTickerExchangeController : ControllerBase
    {
        private readonly StockLogger2DbContext _context;

        public StockTickerExchangeController(StockLogger2DbContext context)
        {
            _context = context;
        }

        // GET: api/StockTickerExchange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTickerExchange>>> GetStockTickerExchanges()
        {
            return await _context.StockTickerExchanges.ToListAsync();
        }
    }
}
