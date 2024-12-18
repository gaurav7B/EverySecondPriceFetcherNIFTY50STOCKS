using System.ComponentModel.DataAnnotations;

namespace EverySecondPriceFetcherNIFTY50STOCKS.Model
{
    public class StockTickerExchange
    {
        [Key]
        public long Id { get; set; }

        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public string CompanyName { get; set; }
    }
}
