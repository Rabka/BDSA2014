using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    interface IRespiratory
    {
        Product[] Products();
        Category[] Categories();
        Order[] Orders();        
        void CreateOrder(Order order);
    }
}
