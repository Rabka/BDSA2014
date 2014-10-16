using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    /// <summary>
    /// A interface to a Respiratory
    /// </summary>
    interface IRespiratory
    {
        Product[] Products();
        Category[] Categories();
        Order[] Orders();        
        void CreateOrder(Order order);
    }
}
