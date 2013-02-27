using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;

namespace MainApp
{
    public class ViewModel
    {
        public IEnumerable<object> MyData
        {
            get
            {
                try
                {
                    StocksDataService.StocksData svc = new StocksDataService.StocksData(new Uri("http://localhost:8080/WebApplication1/StocksDataService.svc/"));
                    var q = svc.Stocks.Where(s => s.Name.StartsWith("Mic"));
                    //var q = from s in svc.Stocks join c in svc.Quotes on s.Id equals c.StockId select new { s.Id, s.Name, c.Sell };
                    //    MessageBox.Show(s.Id);
                    //StocksDataService.Stock stock = svc.Stocks.Where(s => s.Id == "MSFT").FirstOrDefault();
                    //MessageBox.Show(stock.Id);
                    //svc.AddObject("Stocks", new StocksDataService.Stock() { Id = "ABC", Name = "New stock" });
                    //svc.SaveChanges();
                    return q.ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
