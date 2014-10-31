using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    interface IRespiratory
    {
        IQueryable<Products> Products();
         IQueryable<Categories> Categories();
         IQueryable<Orders> Orders();        
        void CreateOrder(Orders order);
    }
}
