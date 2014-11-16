using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;

namespace Assignment40_1.Tests.TestStubs
{
    public class RespiratoryTestStub : IRespiratory
    {
         /// <summary>
        /// Contains the data classes
        /// </summary>
        List<Products> products;
        List<Categories> categories;
        List<Orders> orders;

        /// <summary>
        /// Set up the dataclasses to be contained.
        /// </summary>
        public RespiratoryTestStub()
        {
            Categories category_electronics = new Categories();
            category_electronics.CategoryID = 0;
            Orders order = new Orders();            
            Products product_computer = new Products();
            product_computer.ProductID = 1;
            Order_Details order_details = new Order_Details();
            order_details.Discount = 500;
            order_details.OrderID = 1;
            order_details.Orders = order;
            order_details.ProductID = product_computer.ProductID;
            order_details.Products = product_computer;
            Customers custommer = new Customers();
            custommer.ContactName = "Niels";
            custommer.CustomerID = "1";
            order.CustomerID = custommer.CustomerID;
            order.Customers = custommer;
            order.OrderID = 1;       
            order.Order_Details.Add(order_details);
            product_computer.CategoryID = category_electronics.CategoryID;
            product_computer.Categories = category_electronics;
            product_computer.Order_Details.Add(order_details);
            product_computer.ProductID = 1;
            product_computer.ProductName = "Laptop";
            product_computer.QuantityPerUnit = "0";
            product_computer.ReorderLevel = 0;
            product_computer.UnitPrice = 4000;
            product_computer.UnitsInStock = 2;
            product_computer.UnitsOnOrder = 0;
            products.Add(product_computer);
            orders.Add(order);
            categories.Add(category_electronics);
        }

        /// <summary>
        /// Returns the products containd by this Respiratory.
        /// </summary>
        /// <returns>all products in products (Product[])</returns>
        public IQueryable<Products> Products()
        {
            return products.AsQueryable();
        }

        /// <summary>
        /// Returns the categories containd by this Respiratory.
        /// </summary>
        /// <returns>all categories in categories (Category[])</returns>
        public IQueryable<Categories> Categories()
        {
            return categories.AsQueryable();
        }

        /// <summary>
        /// Returns the orders containd by this Respiratory.
        /// </summary>
        /// <returns>all orders in orders (Order[])</returns>
        public IQueryable<Orders> Orders()
        {
            return orders.AsQueryable();
        }

        /// <summary>
        /// Adds a new order to the orders list, with its own new orderID.
        /// </summary>
        /// <param name="newOrder">The oder to be added</param>
        public void CreateOrder(Orders newOrder)
        {
            //get highest id using LINQ
            orders.Add(newOrder);
            int newID = orders.Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
        }
    }
}
