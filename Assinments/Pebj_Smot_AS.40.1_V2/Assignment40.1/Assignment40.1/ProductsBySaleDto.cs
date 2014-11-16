using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;
namespace Assignment40_1
{
    /// <summary>
    /// An entity class returned by ReportingModule.
    /// Represents a stripped down Product with additional query functionality.
    /// </summary>
    public class ProductsBySaleDto
    {
        private Products product;
        public ProductsBySaleDto(Products product)
        {
            this.product = product;
        }
        public int ProductId
        {
            get { return product.ProductID; }
        }
        public string ProductName
        {
            get { return product.ProductName; }
        }

        /// <summary>
        /// Returns a list of UnitsSold : int, Count : int, Month : int, Year : int
        /// </summary>
        /// <returns>List<int></int></returns>
        public List<int> UnitsSoldByMonth()
        {
            List<int> result = new List<int>();
            //[list of UnitsSold : int, Count : int, Month : int, Year : int
            List<int> years = product.Order_Details.Select(x => x.Orders.OrderDate.Value.Year).Distinct().ToList();
            years.Sort();
            foreach (int year in years)
            {
                List<int> months = product.Order_Details.Where (x=>x.Orders.OrderDate.Value.Year == year).Select(x => x.Orders.OrderDate.Value.Month).Distinct().ToList();
                months.Sort();
                foreach (int month in months)
                {
                    int unitsSold = product.Order_Details.Select(x => x).Where(x => x.Orders.OrderDate.Value.Year == year && x.Orders.OrderDate.Value.Month == month).Sum(x => x.Quantity);
                    int count = product.Order_Details.Select(x => x).Where(x => x.Orders.OrderDate.Value.Year == year && x.Orders.OrderDate.Value.Month == month).Count();
                    result.AddRange(new int[] { unitsSold, count, month, year });
                }
            }
            return result;
        }
    }
}
