using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Services.Common;
using System.ServiceModel.Web;

namespace CLRData
{
    public class StocksData
    {
        public StocksData()
        {
            _stocks = new List<Stock>()
            {
                new Stock() { Id = "MSFT", Name = "Microsoft", Quotes = new List<Quote>
                {
                    new Quote() { StockId = "MSFT", Buy = 24.95, Sell = 25.20, Timestamp = 25 },
                    new Quote() { StockId = "MSFT", Buy = 24.50, Sell = 25.25, Timestamp = 26 }
                }},
                new Stock() { Id = "HON", Name = "Honeywell" },
                new Stock() { Id = "IBM", Name = "International Business Machines" }
            };
            _quotes = new List<Quote>()
            {
                new Quote() { Buy = 24.95, Sell = 25.20, Timestamp = 25 }
            };
        }
        List<Stock> _stocks;
        List<Quote> _quotes;
        public IQueryable<Stock> Stocks { get { return _stocks.AsQueryable(); } }
        public IQueryable<Quote> Quotes
        {
            get
            {
                return _quotes.AsQueryable();
            }
        }

        [WebGet]
        public IQueryable<Quote> GetStockQuotes(string id)
        {
            if (_quotes == null) return null;
            return _quotes.Where((q) => q.StockId == id).AsQueryable();
        }
    }

    [DataServiceKeyAttribute("Id")]
    public class Stock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
    }
    [DataServiceKeyAttribute("StockId", "Timestamp")]
    public class Quote
    {
        public string StockId { get; set; }
        public long Timestamp { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }
    }
}