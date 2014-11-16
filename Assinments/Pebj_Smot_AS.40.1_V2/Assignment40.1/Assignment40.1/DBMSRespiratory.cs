using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;
namespace Assignment40_1
{
    /// <summary>
    /// A DBMS Respiratory that implements IRespiratory.
    /// Handles communication with DBMS database.
    /// </summary>
    public class DBMSRespiratory : IRespiratory
    {
        //Entity-Framework powered NORTHWNDEntities1 dataContext
        NORTHWNDEntities1 context;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">Entity-Framework NORTHWNDEntities1 dataContext</param>
        public DBMSRespiratory(NORTHWNDEntities1 context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns the products containd by this Respiratory.
        /// </summary>
        /// <returns>all products in products (Product[])</returns>
        public IQueryable<Products> Products()
        {
            return from b in context.Products select b;
        }

        /// <summary>
        /// Returns the categories containd by this Respiratory.
        /// </summary>
        /// <returns>all categories in categories (Category[])</returns>
        public  IQueryable<Categories> Categories()
        {
            return from b in context.Categories select b;
        }

        /// <summary>
        /// Returns the orders containd by this Respiratory.
        /// </summary>
        /// <returns>all orders in orders (Order[])</returns>
        public  IQueryable<Orders> Orders()
        {
            return from b in context.Orders select b;
        }

        /// <summary>
        /// Adds a new order to the orders list, with its own new orderID.
        /// </summary>
        /// <param name="newOrder">The oder to be added</param>
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
