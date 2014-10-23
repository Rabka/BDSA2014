using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_PartIII.Model;
namespace Assignment40_PartIII
{
    public class Respiratory : IRespiratory
    {
        NORTHWNDEntities1 context;
        public Respiratory(NORTHWNDEntities1 context)
        {
            this.context = context;
        }

        public IQueryable<Products> Products()
        {
            return from b in context.Products select b;
        }

        public  IQueryable<Categories> Categories()
        {
            return from b in context.Categories select b;
        }

        public  IQueryable<Orders> Orders()
        {
            return from b in context.Orders select b;
        }

        public  IQueryable<Order_Details> OrderDetails()
        {
            return from b in context.Order_Details select b;
        }

        public void CreateOrder(Orders newOrder)
        {
            //get highest id using LINQ
            int newID = Orders().Max(a => a.OrderID)+1;
            newOrder.OrderID = newID;
            context.Orders.Add(newOrder);
            context.SaveChanges(); 
        }
    }
}
