using System.ComponentModel.DataAnnotations;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Model
{
    public class StockPricePerSec
    {
        [Key]
        public long Id { get; set; }

        // Company information
        public string Ticker { get; set; }
        public long TickerId { get; set; }

        // Time information
        public DateTime StockDateTime { get; set; }

        // Price information
        public decimal StockPrice { get; set; }
    }
}
