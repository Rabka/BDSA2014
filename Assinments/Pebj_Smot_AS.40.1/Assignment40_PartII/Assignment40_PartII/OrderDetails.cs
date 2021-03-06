﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    /// <summary>
    /// A data class to contain information from order_details.txt
    /// </summary>
    public class OrderDetails
    {
        public Order OrderID;
        public Product ProductID;
        public double UnitPrice;
        public int Quantity;
        public double Discount;

        public OrderDetails(Order OrderID, Product ProductID, double UnitPrice, int Quantity, double Discount)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Discount = Discount;
        }
    }
}
