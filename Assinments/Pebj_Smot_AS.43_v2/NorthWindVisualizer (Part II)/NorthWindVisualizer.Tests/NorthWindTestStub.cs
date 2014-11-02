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
            Categories testCategory = new Categories();
            testCategory.CategoryID=0;
            testCategory.CategoryName = "General";
            testCategory.Description="Visual effects";
            Products testProduct= new Model.Products();
            testCategory.Products.Add(testProduct);
            testProduct.Categories = testCategory;
            testProduct.ProductID = 0;
            testProduct.ProductName ="ITU Wall LED Display";
            Order_Details order_Details = new Order_Details();
            order_Details.Discount = 35.5f;
            order_Details.OrderID = 0;
            order_Details.Orders = orders[0];
            order_Details.Products = testProduct;
            order_Details.Quantity = 4;
            order_Details.UnitPrice = 7000;
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
            var order = new Orders();
            order.RequiredDate = requiredDate;
            order.ShipName = name;
            order.ShipAddress = address;
            order.ShipCity = city;
            order.ShipRegion = region;
            order.ShipPostalCode = postalCode;
            order.ShipCountry = country;
            order.OrderDate = DateTime.Now;
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
