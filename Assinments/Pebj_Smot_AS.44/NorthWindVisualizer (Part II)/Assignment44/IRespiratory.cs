using System.Linq;
using Assignment44.Models;

namespace Assignment44
{
    /// <summary>
    /// IRespiratory describes the functionality required by Respiratories in our context of usage needs.
    /// It is intended to be the direct communication link betweeen the database etc. and the rest of the program.
    /// </summary>
    public interface IRespiratory
    {
        /// <summary>
        /// Returns a list of IQueryable Products.
        /// </summary>
        /// <returns>IQueryable<Products> Products</returns>
        IQueryable<Products> Products();
        /// <summary>
        /// Returns a list of IQueryable Categories.
        /// </summary>
        /// <returns>IQueryable<Categories> Categories</returns>
        IQueryable<Categories> Categories();
        /// <summary>
        /// Returns a list of IQueryable Orders.
        /// </summary>
        /// <returns>IQueryable<Orders> Orders</returns>
        IQueryable<Orders> Orders();
        /// <summary>
        /// Returns a list of IQueryable OrderDetails.
        /// </summary>
        /// <returns>IQueryable<Order_Details> Order_Details</returns>
        IQueryable<Order_Details> OrderDetails();
    }
}