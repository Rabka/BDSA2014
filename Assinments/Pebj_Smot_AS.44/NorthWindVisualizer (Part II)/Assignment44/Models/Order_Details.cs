//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment44.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Details
    {
        public Order_Details()
        {

        }
        public Order_Details(int newID,int productID,decimal unitPrice,short quantity,float discount,Orders order, Products product)
        {
            this.OrderID = newID;
            this.ProductID = productID;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Discount = discount;
            this.Orders = order;
            this.Products = product;
        }
        public int OrderID { get; private set; }
        public int ProductID { get; private set; }
        public decimal UnitPrice { get; private set; }
        public short Quantity { get; private set; }
        public float Discount { get; private set; }
    
        public virtual Orders Orders { get; private set; }
        public virtual Products Products { get; private set; }
    }
}
