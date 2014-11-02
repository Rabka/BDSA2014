using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWindVisualizer.Model;
namespace NorthWindVisualizer
{
    public interface INorthWind
    {  
        newOrderEventDelegate newOrderEvent {get;set;}


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
       void AddOrder(DateTime requiredDate, string name, string address, string city, string region,
            string postalCode, string country);

        /// <summary>
        ///     Gets and returns the products from the Respiratory
        /// </summary>
        /// <returns>All products in the Respiratory (Product[])</returns>
       IQueryable<Products> Products();

        /// <summary>
        ///     Gets and returns the orders from the Respiratory
        /// </summary>
        /// <returns>All orders in the Respiratory (Order[])</returns>
        IQueryable<Orders> Orders();
    }
}
