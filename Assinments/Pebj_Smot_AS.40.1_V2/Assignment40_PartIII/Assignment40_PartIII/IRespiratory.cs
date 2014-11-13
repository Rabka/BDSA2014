using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_PartIII.Model;

namespace Assignment40_PartIII
{
    interface IRespiratory
    {
        IQueryable<Products> Products();
         IQueryable<Categories> Categories();
         IQueryable<Orders> Orders();        
        void CreateOrder(Orders order);
    }
}
