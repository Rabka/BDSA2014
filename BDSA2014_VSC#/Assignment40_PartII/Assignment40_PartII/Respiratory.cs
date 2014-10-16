using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    /// <summary>
    /// The Respiratory usesing IRespiratory interface and for contaning the data classes.
    /// </summary>
    public class Respiratory : IRespiratory
    {
        /// <summary>
        /// Contains the data classes
        /// </summary>
        List<Product> products;
        List<Category> categories;
        List<Order> orders;
        List<OrderDetails> ordersDetails;

        /// <summary>
        /// Set up the dataclasses to be containd.
        /// </summary>
        /// <param name="products">A array of the Products</param>
        /// <param name="categories">A array of the Categories</param>
        /// <param name="orders">A array of the Orders</param>
        /// <param name="ordersDetails">A array of the OrdersDetails</param>
        public Respiratory(Product[] products, Category[] categories, Order[] orders, OrderDetails[] ordersDetails)
        {
            this.products = products.ToList();
            this.categories = categories.ToList();
            this.orders = orders.ToList();
            this.ordersDetails = ordersDetails.ToList();
        }

        /// <summary>
        /// Returns the products containd by this Respiratory.
        /// </summary>
        /// <returns>all products in products (Product[])</returns>
        public Product[] Products()
        {
            return products.ToArray();
        }

        /// <summary>
        /// Returns the categories containd by this Respiratory.
        /// </summary>
        /// <returns>all categories in categories (Category[])</returns>
        public Category[] Categories()
        {
            return categories.ToArray();
        }

        /// <summary>
        /// Returns the orders containd by this Respiratory.
        /// </summary>
        /// <returns>all orders in orders (Order[])</returns>
        public Order[] Orders()
        {
            return orders.ToArray();
        }

        /// <summary>
        /// Returns the orderDetails containd by this Respiratory.
        /// </summary>
        /// <returns>all orderDetails in orderDetails (OrderDetails[])</returns>
        public OrderDetails[] OrderDetails()
        {
            return ordersDetails.ToArray();
        }

        /// <summary>
        /// Adds a new order to the orders list, with its own new orderID.
        /// </summary>
        /// <param name="newOrder">The oder to be added</param>
        public void CreateOrder(Order newOrder)
        {
            //get highest id using LINQ
            orders.Add(newOrder);
            int newID = orders.Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
        }
    }
}
