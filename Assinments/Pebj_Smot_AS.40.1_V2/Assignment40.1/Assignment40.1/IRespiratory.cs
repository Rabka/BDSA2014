using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment40_1.Model;

namespace Assignment40_1
{

    /// <summary>
    /// IRespiratory interface describes the methods for handling 
    /// manipolation of required objects between the database and software.
    /// </summary>
    public interface IRespiratory
    {
         IQueryable<Products> Products();
         IQueryable<Categories> Categories();
         IQueryable<Orders> Orders();    
        void CreateOrder(Orders order);
    }
}
