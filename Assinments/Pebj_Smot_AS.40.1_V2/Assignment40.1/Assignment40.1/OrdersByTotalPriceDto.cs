using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;
namespace Assignment40_1
{
    /// <summary>
    /// An entity class returned by ReportingModule.
    /// Represents a stripped down Order with additional query functionality.
    /// </summary>
    class OrdersByTotalPriceDto
    {
        private Orders order;
        private NorthWind northWind;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="northWind">NorthWind instance</param>
        /// <param name="order">Inherited order</param>
        public OrdersByTotalPriceDto(NorthWind northWind, Orders order)
        {
            this.northWind = northWind;
            this.order = order;
        }

        public int OrderId
        {
            get { return OrderId; }
        }
        public DateTime OrderDate
        {
            get { if (order.OrderDate.HasValue) return order.OrderDate.Value; return DateTime.Now; }
        }
        /*
        public string CustomerContactName
        {
            get { return order.ContactName; }
        }
         */
        public decimal TotalPriceWithDiscount
        {
            get { return Convert.ToDecimal(order.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice) - l.Discount)); }
        }
        public decimal TotalPrice
        {
            get { return Convert.ToDecimal(order.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice))); }
        }
        /// <summary>
        /// Returns a list of Top ProductsBySaleDto ordered by sales.
        /// </summary>
        /// <param name="count">How many results is desired</param>
        /// <returns>Report<IList<ProductsBySaleDto>, Exception></returns>
        public Report<IList<ProductsBySaleDto>, Exception> TopProductsBySale(int count)
        {
            Report<IList<ProductsBySaleDto>, Exception> report = new Report<IList<ProductsBySaleDto>, Exception>();
            try
            {
                var result = northWind.Products()
                           .Select(x => x).Where(x => x.Order_Details.Select( y=> y).Where(z=>z.OrderID == OrderId).Count() > 0).OrderByDescending(x => x.Order_Details.Sum(y=>y.Quantity))
                           .OrderByDescending(x => x.Order_Details.Sum(l => (float)(l.Quantity * l.UnitPrice) - l.Discount)).Take(count);
                List<ProductsBySaleDto> res = new List<ProductsBySaleDto>();
                foreach (var o in result)
                {
                    ProductsBySaleDto product = new ProductsBySaleDto(o);
                    res.Add(product);
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
