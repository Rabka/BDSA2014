using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    public class Respiratory : IRespiratory
    {
        List<Product> products;
        List<Category> categories;
        List<Order> orders;
        List<OrderDetails> ordersDetails;
        public Respiratory(Product[] products, Category[] categories, Order[] orders, OrderDetails[] ordersDetails)
        {
            this.products = products.ToList();
            this.categories = categories.ToList();
            this.orders = orders.ToList();
            this.ordersDetails = ordersDetails.ToList();
        }
        public Product[] Products()
        {
            return products.ToArray();
        }
        public Category[] Categories()
        {
            return categories.ToArray();
        }
        public Order[] Orders()
        {
            return orders.ToArray();
        }
        public OrderDetails[] OrderDetails()
        {
            return ordersDetails.ToArray();
        }
        public void CreateOrder(Order newOrder)
        {
            //get highest id using LINQ
            orders.Add(newOrder);
            int newID = orders.Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
        }
    }
}
