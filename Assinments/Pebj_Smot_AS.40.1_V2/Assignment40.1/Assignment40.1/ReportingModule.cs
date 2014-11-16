using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;

namespace Assignment40_1
{
    class ReportingModule
    {
        NorthWind northWind;
        public ReportingModule(NorthWind northWind)
        {
            this.northWind = northWind;
             
        }
        public Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
           var result = northWind.Orders()
                      .Select(x => x)
                      .OrderByDescending(x => x.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice) -  l.Discount)).Take(count);
            List<OrdersByTotalPriceDto> res = new List<OrdersByTotalPriceDto>();
           foreach (var o in result)
           {
               OrdersByTotalPriceDto order = new OrdersByTotalPriceDto();
               order.TotalPrice = o.Order_Details.Sum(l => l.Quantity * l.UnitPrice);
               order.TotalPriceWithDiscount = Convert.ToDecimal(o.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice) - l.Discount));
           }
          Report<IList<OrdersByTotalPriceDto>,ReportError> report = new Report<IList<OrdersByTotalPriceDto>,ReportError>();
            report.Data = res;
            return report;
            
        }
    }
}
