using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_PartIII.Model;

namespace Assignment40_PartIII
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
                      .GroupBy(order => order.OrderID)
                      .Select(orders => new
                      {
                          OrderKey = orders.Key,
                          TotalPrice = orders.Sum(o => o.Order_Details.Sum(
                                                   l => l.Quantity * l.UnitPrice)),
                          Discount = orders.Sum(o => o.Order_Details.Sum(
                                                   l => l.Discount))
                      })
                      .OrderByDescending(x => x.TotalPrice).Take(count);
            List<OrdersByTotalPriceDto> res = new List<OrdersByTotalPriceDto>();
           foreach (var o in result)
           {
              
           }
          Report<IList<OrdersByTotalPriceDto>,ReportError> report = new Report<IList<OrdersByTotalPriceDto>,ReportError>();
            report.Data = res;
            return report;
            
        }
    }
}
