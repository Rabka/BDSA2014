using System.Linq;
using System;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    public class Respiratory : IRespiratory
    {
        private readonly NORTHWNDEntities context;

        public Respiratory(NORTHWNDEntities context)
        {
            this.context = context;
        }

        public IQueryable<Products> Products()
        {
            return from b in context.Products select b;
        }

        public IQueryable<Categories> Categories()
        {
            return from b in context.Categories select b;
        }

        public IQueryable<Orders> Orders()
        {
            return from b in context.Orders select b;
        }

        public Orders CreateOrder(DateTime requiredDate, string shipName, string shipAddress,string shipCity,string shipRegion,string shipPostalCode,string shipCountry)
        {
            //get highest id using LINQ
            int newID = Orders().Max(a => a.OrderID) + 1;
            Orders order = new Model.Orders(newID,requiredDate,shipName,shipAddress,shipCity,shipRegion,shipPostalCode,shipCountry);
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public IQueryable<Order_Details> OrderDetails()
        {
            return from b in context.Order_Details select b;
        }
    }
}