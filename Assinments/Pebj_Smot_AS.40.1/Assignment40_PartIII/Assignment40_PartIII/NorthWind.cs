using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_PartIII.Model;

namespace Assignment40_PartIII
{

    public delegate void newOrderEventDelegate(Orders addedOrder);

    /// <summary>
    /// A NorthWind class ther represent the top-level of the system.
    /// </summary>
    public class NorthWind
    {
        Respiratory respiratory;
        public newOrderEventDelegate newOrderEvent;

        /// <summary>
        /// Sets the Respiratory
        /// </summary>
        /// <param name="respiratory">A Respiratory containing data classes</param>
        public NorthWind(Respiratory respiratory)
        {
            this.respiratory = respiratory;
        }

        /// <summary>
        /// Adds a new order to the Respiratory
        /// </summary>
        /// <param name="requiredDate">The data the oder is required</param>
        /// <param name="name">The name of the ship containing the order</param>
        /// <param name="address">The ships address</param>
        /// <param name="city">The ships city</param>
        /// <param name="region">The ships region</param>
        /// <param name="postalCode">The ships postalCode</param>
        /// <param name="country">The ships country</param>
        public void AddOrder(DateTime requiredDate, string name, string address, string city, string region, string postalCode, string country)
        {
            Orders order = new Orders();
            order.RequiredDate = requiredDate;
            order.ShipName = name;
            order.ShipAddress = address;
            order.ShipCity = city;
            order.ShipRegion = region;
            order.ShipPostalCode = postalCode;
            order.ShipCountry = country;
            order.OrderDate = DateTime.Now;
            respiratory.CreateOrder(order);
                newOrderEvent(order);
        }

        /// <summary>
        /// Gets and returns the products from the Respiratory
        /// </summary>
        /// <returns>All products in the Respiratory (Product[])</returns>
        public IQueryable<Products> Products()
        {
            return respiratory.Products();
        }

        /// <summary>
        /// Gets and returns the orders from the Respiratory
        /// </summary>
        /// <returns>All orders in the Respiratory (Order[])</returns>
        public  IQueryable<Orders> Orders()
        {
            return respiratory.Orders();
        }
    }
}
