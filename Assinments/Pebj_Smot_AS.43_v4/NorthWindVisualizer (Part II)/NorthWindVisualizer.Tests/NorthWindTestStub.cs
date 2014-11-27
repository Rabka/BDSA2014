using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWindVisualizer;
using NorthWindVisualizer.Model;
namespace NorthWindVisualizer.Tests
{
    class NorthWindTestStub : INorthWind
    {
        List<Orders> orders = new List<Orders>();
        List<Products> products = new List<Products>();
        public newOrderEventDelegate newOrderEvent { get; set; }

        public NorthWindTestStub()
        {
            //Add content
            AddOrder(DateTime.Now, "Patrick", "Road1", "Copenhagen", "None", "2300", "Denmark");
            AddOrder(DateTime.Now, "Stinus", "Road2", "Copenhagen", "None", "2300", "Denmark");
            Categories testCategory = new Categories(0, "General", "Visual effects", null);
            Products testProduct = new Model.Products(0, "ITU Wall LED Display", null, null, "", null, null, null, null, false, testCategory);
            testCategory.Products.Add(testProduct);
            Order_Details order_Details = new Order_Details(0, -1, 7000, 4, 35.5f, orders[0], testProduct);
            orders[0].Order_Details.Add(order_Details);
            testProduct.Order_Details.Add(order_Details);
            products.Add(testProduct);
        }
        /// <summary>
        ///     Adds a new order to the Respiratory
        /// </summary>
        /// <param name="requiredDate">The data the oder is required</param>
        /// <param name="name">The name of the ship containing the order</param>
        /// <param name="address">The ships address</param>
        /// <param name="city">The ships city</param>
        /// <param name="region">The ships region</param>
        /// <param name="postalCode">The ships postalCode</param>
        /// <param name="country">The ships country</param>
        public void AddOrder(DateTime requiredDate, string name, string address, string city, string region,
            string postalCode, string country)
        {
            var order = new Orders(orders.Count - 1, requiredDate, name, address, city, region, postalCode, country);
            orders.Add(order);
            if (newOrderEvent != null)
                newOrderEvent(order);
        }

        /// <summary>
        ///     Gets and returns the products from the Respiratory
        /// </summary>
        /// <returns>All products in the Respiratory (Product[])</returns>
        public IQueryable<Products> Products()
        {
            return ((IEnumerable<Products>)products).Select(x => x).AsQueryable();
        }

        /// <summary>
        ///     Gets and returns the orders from the Respiratory
        /// </summary>
        /// <returns>All orders in the Respiratory (Order[])</returns>
        public IQueryable<Orders> Orders()
        {
            return ((IEnumerable<Orders>)orders).Select(x => x).AsQueryable();
        }
    }
}
