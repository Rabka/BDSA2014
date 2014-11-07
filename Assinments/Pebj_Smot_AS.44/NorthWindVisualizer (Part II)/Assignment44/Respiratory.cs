using System.Linq;
using Assignment44.Models;

namespace Assignment44
{
    public class Respiratory : IRespiratory
    {
        private readonly NORTHWNDdataset context;

        public Respiratory(NORTHWNDdataset context)
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

        public IQueryable<Order_Details> OrderDetails()
        {
            return from b in context.Order_Details select b;
        }
    }
}