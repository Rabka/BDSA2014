using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class OrderDetails
    {
        public Orders OrderID;
        public Products ProductID;
        public int UnitPrice;
        public int Quantity;
        public int Discount;

        public OrderDetails(Orders OrderID, Products ProductID, int UnitPrice, int Quantity, int Discount)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Discount = Discount;
        }
    }
}
