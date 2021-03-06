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

    public partial class Orders
    {
        public Orders()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }
        public Orders(int newID, DateTime requiredDate, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            this.Order_Details = new HashSet<Order_Details>();
            this.OrderID = newID;
            this.RequiredDate = requiredDate;
            this.ShipName = shipName;
            this.ShipAddress = shipAddress;
            this.ShipCity = shipCity;
            this.ShipRegion = shipRegion;
            this.ShipPostalCode = shipPostalCode;
            this.ShipCountry = shipCountry;
            OrderDate = DateTime.Now;
        }
        public int OrderID { get; private set; }
        public string CustomerID { get; private set; }
        public Nullable<int> EmployeeID { get; private set; }
        public Nullable<System.DateTime> OrderDate { get; private set; }
        public Nullable<System.DateTime> RequiredDate { get; private set; }
        public Nullable<System.DateTime> ShippedDate { get; private set; }
        public Nullable<int> ShipVia { get; private set; }
        public Nullable<decimal> Freight { get; private set; }
        public string ShipName { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipRegion { get; private set; }
        public string ShipPostalCode { get; private set; }
        public string ShipCountry { get; private set; }

        public virtual Customers Customers { get; private set; }
        public virtual Employees Employees { get; private set; }
        public virtual ICollection<Order_Details> Order_Details { get; private set; }
    }
}
