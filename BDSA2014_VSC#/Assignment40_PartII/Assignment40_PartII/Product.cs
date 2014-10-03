using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class Product
    {
        public string ProductName;
        public object SupplierID;
        public Category CategoryID;
        public string QuantityPerUnit;
        public double UnitPrice;
        public int UnitsInStock;
        public int UnitsOnOrder;
        public int ReorderLevel;
        public int Discontinued;

        public Product(string ProductName, object SupplierID, Category CategoryID, string QuantityPerUnit, double UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, int Discontinued)
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
