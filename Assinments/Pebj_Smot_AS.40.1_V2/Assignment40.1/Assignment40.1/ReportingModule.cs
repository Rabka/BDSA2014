using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;

namespace Assignment40_1
{
    /// <summary>
    /// The reporting module allows the user to get reports of orders.
    /// </summary>
    class ReportingModule
    {
        NorthWind northWind;
        public ReportingModule(NorthWind northWind)
        {
            this.northWind = northWind;
             
        }
        /// <summary>
        /// Returns a list of Top OrdersByTotalPriceDto ordered by TotalPrice.
        /// </summary>
        /// <param name="count">How many results is desired</param>
        /// <returns> Report<IList<OrdersByTotalPriceDto>, Exception></returns>
        public Report<IList<OrdersByTotalPriceDto>, Exception> TopOrdersByTotalPrice(int count)
        {
            Report<IList<OrdersByTotalPriceDto>, Exception> report = new Report<IList<OrdersByTotalPriceDto>, Exception>();
            try
            {
                var result = northWind.Orders()
                           .Select(x => x)
                           .OrderByDescending(x => x.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice))).Take(count);
                List<OrdersByTotalPriceDto> res = new List<OrdersByTotalPriceDto>();
                foreach (var o in result)
                {
                    OrdersByTotalPriceDto order = new OrdersByTotalPriceDto(northWind,o);
                    res.Add(order);
                }
                report.Data = res;
            }
            catch (Exception ex)
            {
                report.Error = ex;
            }
            return report;
            
        }
    }
}
