//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment40_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public Orders()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }

        public Orders(int orderID, string customerID, Nullable<int> employeeID, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, int shipVia, Nullable<decimal> freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.OrderDate = orderDate;
            this.RequiredDate = requiredDate;
            this.ShippedDate = shippedDate;
            this.ShipVia = shipVia;
            this.Freight = freight;
            this.ShipName = shipName;
            this.ShipAddress = shipAddress;
            this.ShipCity = shipCity;
            this.ShipRegion = shipRegion;
            this.ShipPostalCode = shipPostalCode;
            this.ShipCountry = shipCountry;
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }    
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}
