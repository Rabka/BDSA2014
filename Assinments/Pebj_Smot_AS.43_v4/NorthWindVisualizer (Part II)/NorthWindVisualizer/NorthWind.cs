using System;
using System.Linq;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    public delegate void newOrderEventDelegate(Orders addedOrder);

    /// <summary>
    ///     A NorthWind class ther represent the top-level of the system.
    /// </summary>
    public class NorthWind : INorthWind
    {
        private readonly IRespiratory respiratory;
        public newOrderEventDelegate newOrderEvent { get; set; }

        /// <summary>
        ///     Sets the Respiratory
        /// </summary>
        /// <param name="respiratory">A Respiratory containing data classes</param>
        public NorthWind(IRespiratory respiratory)
        {
            this.respiratory = respiratory;
        }

        /// <summary>
        ///     Adds a new order to the Respiratory
        /// </summary>
        /// <param name="requiredDate">The data the oder is required</param>
        /// <param name="name">The name of the ship containing the order</param>
        /// <param name="address">The ships address</param>
        /// <param name="city">The ships city</param>
        /// <param name="region">The ships region</param>
        /// <param name="postalCode">The ships postalCode</param>
        /// <param name="country">The ships country</param>
        public void AddOrder(DateTime requiredDate, string name, string address, string city, string region,
            string postalCode, string country)
        {
           Orders order =  respiratory.CreateOrder(requiredDate,name,address,city,region,postalCode,country);
           newOrderEvent(order);
        }

        /// <summary>
        ///     Gets and returns the products from the Respiratory
        /// </summary>
        /// <returns>All products in the Respiratory (Product[])</returns>
        public IQueryable<Products> Products()
        {
            return respiratory.Products();
        }

        /// <summary>
        ///     Gets and returns the orders from the Respiratory
        /// </summary>
        /// <returns>All orders in the Respiratory (Order[])</returns>
        public IQueryable<Orders> Orders()
        {
            return respiratory.Orders();
        }
    }
}