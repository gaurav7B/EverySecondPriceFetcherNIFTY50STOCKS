using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Model
{
    public class StockLogger2DbContext : DbContext
    {
        public StockLogger2DbContext(DbContextOptions<StockLogger2DbContext> options)
    : base(options)
        {
        }

        public DbSet<StockTickerExchange> StockTickerExchanges { get; set; }
        public DbSet<StockPricePerSec> StockPricePerSec { get; set; }
    }
}
