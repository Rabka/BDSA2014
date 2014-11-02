using System.Linq;
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

        public void CreateOrder(Orders newOrder)
        {
            //get highest id using LINQ
            int newID = Orders().Max(a => a.OrderID) + 1;
            newOrder.OrderID = newID;
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public IQueryable<Order_Details> OrderDetails()
        {
            return from b in context.Order_Details select b;
        }
    }
}