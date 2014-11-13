using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;
namespace Assignment40_1
{
    /// <summary>
    /// The Respiratory usesing IRespiratory interface and for contaning the data classes.
    /// </summary>
    public class CSVRespiratory : IRespiratory
    {
        /// <summary>
        /// Contains the data classes
        /// </summary>
        List<Products> products;
        List<Categories> categories;
        List<Orders> orders;

        /// <summary>
        /// Set up the dataclasses to be containd.
        /// </summary>
        /// <param name="products">A array of the Products</param>
        /// <param name="categories">A array of the Categories</param>
        /// <param name="orders">A array of the Orders</param>
        /// <param name="ordersDetails">A array of the OrdersDetails</param>
        public CSVRespiratory(Products[] products, Categories[] categories, Orders[] orders)
        {
            this.products = products.ToList();
            this.categories = categories.ToList();
            this.orders = orders.ToList();
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
