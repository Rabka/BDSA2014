using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartIII
{
    public class Respiratory : IRespiratory
    {
        NorthWindContext context;
        public Respiratory(NorthWindContext context)
        {
            this.context = context;
        }

        public Product[] Products()
        {
            return (from b in context.Products select b).ToArray();
        }

        public Category[] Categories()
        {
            return (from b in context.Categories select b).ToArray();
        }

        public Order[] Orders()
        {
            return (from b in context.Orders select b).ToArray();
        }

        public OrderDetails[] OrderDetails()
        {
            return (from b in context.OrderDetails select b).ToArray();
        }

        public void CreateOrder(Order newOrder)
        {
            //get highest id using LINQ
            int newID = Orders().Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
            context.Orders.Add(newOrder);
            context.SaveChanges(); 
        }
    }
}
