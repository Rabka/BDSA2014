using System.Linq;
using System;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    public interface IRespiratory
    {
        IQueryable<Products> Products();
        IQueryable<Categories> Categories();
        IQueryable<Orders> Orders();
        Orders CreateOrder(DateTime requiredDate, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry);
    }
}