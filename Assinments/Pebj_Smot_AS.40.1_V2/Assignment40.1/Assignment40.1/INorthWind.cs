using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;

namespace Assignment40_1
{
    public interface INorthWind
    {
        void AddOrder(DateTime requiredDate, string name, string address, string city, string region, string postalCode, string country);
        IQueryable<Products> Products();
        IQueryable<Orders> Orders();

        event newOrderEventDelegate newOrderEvent;
    }
}
