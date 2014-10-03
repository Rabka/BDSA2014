using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class Orders
    {
        public object CustomerID;
        public object EmployeeID;
        public DateTime OrderDate;
        public DateTime RequiredDate;
        public DateTime ShippedDate;
        public int ShipVia;
        public double Freight;
        public string ShipName;
        public string ShipAddress;
        public string ShipCity;
        public string ShipRegion;
        public int ShipPostalCode;
        public string ShipCountry;

        public Orders(object CustomerID, object EmployeeID, DateTime OrderDate, DateTime RequiredDate, DateTime ShippedDate, int ShipVia, double Freight, string ShipName, string ShipAddress, string ShipCity, string ShipRegion, int ShipPostalCode, string ShipCountry)
        {
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.OrderDate = OrderDate;
            this.RequiredDate = RequiredDate;
            this.ShippedDate = ShippedDate;
            this.ShipVia = ShipVia;
            this.Freight = Freight;
            this.ShipName = ShipName;
            this.ShipAddress = ShipAddress;
            this.ShipCity = ShipCity;
            this.ShipRegion = ShipRegion;
            this.ShipPostalCode = ShipPostalCode;
            this.ShipCountry = ShipCountry;
        }
    }
}
