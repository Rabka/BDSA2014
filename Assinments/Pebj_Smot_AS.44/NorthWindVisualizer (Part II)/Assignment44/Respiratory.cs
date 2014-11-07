using System.Linq;
using Assignment44.Models;

namespace Assignment44
{
    /// <summary>
    /// Respiratory is an implementation of IRespiratory that connects a database connected by EntityFramework.
    /// It handles direct communcation between database and the rest of the program.
    /// </summary>
    public class Respiratory : IRespiratory
    {
        private readonly NORTHWNDdataset context;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context">The connected NORTHWNDdataset DataContext to use</param>
        public Respiratory(NORTHWNDdataset context)
        {
            this.context = context;
        }


        /// <summary>
        /// Returns a list of IQueryable Products.
        /// </summary>
        /// <returns>IQueryable<Products> Products</returns>
        public IQueryable<Products> Products()
        {
            return from b in context.Products select b;
        }

        /// <summary>
        /// Returns a list of IQueryable Orders.
        /// </summary>
        /// <returns>IQueryable<Categories> Categories</returns>
        public IQueryable<Categories> Categories()
        {
            return from b in context.Categories select b;
        }

        /// <summary>
        /// Returns a list of IQueryable Orders.
        /// </summary>
        /// <returns>IQueryable<Orders> Orders</returns>
        public IQueryable<Orders> Orders()
        {
            return from b in context.Orders select b;
        }

        /// <summary>
        /// Returns a list of IQueryable OrderDetails.
        /// </summary>
        /// <returns>IQueryable<Order_Details> Order_Details</returns>
        public IQueryable<Order_Details> OrderDetails()
        {
            return from b in context.Order_Details select b;
        }
    }
}