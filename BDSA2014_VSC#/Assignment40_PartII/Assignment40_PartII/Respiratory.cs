using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class Respiratory : IRespiratory
    {
        List<Product> products;
        List<Category> categories;
        List<Order> orders;
        public Respiratory(Product[] products, Category[] categories, Order[] orders)
        {
            this.products = products.ToList();
            this.categories = categories.ToList();
            this.orders = orders.ToList();
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
        public void CreateOrder(Order newOrder)
        {
            //get highest id using LINQ
            orders.Add(newOrder);
            int newID = orders.Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
        }
    }
}
