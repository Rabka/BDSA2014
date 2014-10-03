using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class Products
    {
        public string ProductName;
        public object SupplierID;
        public Categories CategoryID;
        public string QuantityPerUnit;
        public int UnitPrice;
        public int UnitsInStock;
        public int UnitsOnOrder;
        public int ReorderLevel;
        public int Discontinued;

        public Products(string ProductName, object SupplierID, Categories CategoryID, string QuantityPerUnit, int UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, int Discontinued)
        {
            this.ProductName = ProductName;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
            this.Discontinued = Discontinued;
        }
    }
}
