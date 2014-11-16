using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Assignment40_1.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment40_1.Model;
using Assignment40_1.Tests.Properties;

namespace Assignment40_1.Tests
{
    /// <summary>
    /// This UnitTest is resposible for chekking if the importer do import the right things.
    /// </summary>
    [TestClass]
    public class UnitTestOfCSVimporter
    {
        IRespiratory respiratory;

        /// <summary>
        /// Sets up the respiratory.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            respiratory = CSVimporter.ImportCSV(Resources.TestCategories, Resources.TestProducts, Resources.TestOrders, Resources.TestOrder_details);
        }

        /// <summary>
        /// Tests if the data have been correctly imported.
        /// </summary>
        [TestMethod]
        public void TestDataCorrectImported()
        {
            // for the one categori
            Assert.AreEqual(1, respiratory.Categories().First().CategoryID);
            Assert.AreEqual("TestBeverages", respiratory.Categories().First().CategoryName);
            Assert.AreEqual("Test Soft drinks, coffees, teas, beers, and ales", respiratory.Categories().First().Description);

            // for the three order_details
            Assert.AreEqual(1, respiratory.Products().First().Order_Details.Select(x => x).Where((x =>x.OrderID == 1)).First().ProductID);
            Assert.AreEqual(100, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 1)).First().UnitPrice);
            Assert.AreEqual(12, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 1)).First().Quantity);
            Assert.AreEqual(10, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 1)).First().Discount);

            Assert.AreEqual(1, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 2)).First().ProductID);
            Assert.AreEqual(100, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 2)).First().UnitPrice);
            Assert.AreEqual(10, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 2)).First().Quantity);
            Assert.AreEqual(0, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 2)).First().Discount);

            Assert.AreEqual(1, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 3)).First().ProductID);
            Assert.AreEqual(50, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 3)).First().UnitPrice);
            Assert.AreEqual(5, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 3)).First().Quantity);
            Assert.AreEqual(5, respiratory.Products().First().Order_Details.Select(x => x).Where((x => x.OrderID == 3)).First().Discount);

            // for the first two orders
            Assert.AreEqual("VINET", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().CustomerID);
            Assert.AreEqual(5, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().EmployeeID);
            Assert.AreEqual(DateTime.Parse("1996-07-04 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().OrderDate);
            Assert.AreEqual(DateTime.Parse("1996-08-01 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().RequiredDate);
            Assert.AreEqual(DateTime.Parse("1996-07-16 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShippedDate);
            Assert.AreEqual(3, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipVia);
            Assert.AreEqual((decimal)32.38, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().Freight);
            Assert.AreEqual("Vins et alcools Chevalier", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipName);
            Assert.AreEqual("59 rue de l'Abbaye", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipAddress);
            Assert.AreEqual("Reims", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipCity);
            Assert.AreEqual("", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipRegion);
            Assert.AreEqual("51100", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipPostalCode);
            Assert.AreEqual("TestFrance", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 1)).First().ShipCountry);

            Assert.AreEqual("TOMSP", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().CustomerID);
            Assert.AreEqual(6, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().EmployeeID);
            Assert.AreEqual(DateTime.Parse("1996-07-05 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().OrderDate);
            Assert.AreEqual(DateTime.Parse("1996-08-16 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().RequiredDate);
            Assert.AreEqual(DateTime.Parse("1996-07-10 00:00:00"), respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShippedDate);
            Assert.AreEqual(1, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipVia);
            Assert.AreEqual((decimal)11.61, respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().Freight);
            Assert.AreEqual("Toms Spezialit„ten", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipName);
            Assert.AreEqual("Luisenstr. 48", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipAddress);
            Assert.AreEqual("Mnster", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipCity);
            Assert.AreEqual("", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipRegion);
            Assert.AreEqual("44087", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipPostalCode);
            Assert.AreEqual("TestGermany", respiratory.Orders().Select(x => x).Where((x => x.OrderID == 2)).First().ShipCountry);

            //for the one product
            Assert.AreEqual(1, respiratory.Products().First().ProductID);
            Assert.AreEqual("TestChai", respiratory.Products().First().ProductName);
            Assert.AreEqual(1, respiratory.Products().First().SupplierID);
            Assert.AreEqual(1, respiratory.Products().First().CategoryID);
            Assert.AreEqual("10 TestBoxes x 20 TestBags", respiratory.Products().First().QuantityPerUnit);
            Assert.AreEqual(100, respiratory.Products().First().UnitPrice);
            Assert.AreEqual((Int16)10, respiratory.Products().First().UnitsInStock);
            Assert.AreEqual((Int16)0, respiratory.Products().First().UnitsOnOrder);
            Assert.AreEqual((Int16)10, respiratory.Products().First().ReorderLevel);
            Assert.AreEqual(false, respiratory.Products().First().Discontinued);
        }

        /// <summary>
        /// Tests if there is the right number of entries in the respiratory.
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberOfEntries()
        {
            Assert.AreEqual(1, respiratory.Categories().Count());
            Assert.AreEqual(3, respiratory.Products().First().Order_Details.Count());
            Assert.AreEqual(3, respiratory.Orders().Count());
            Assert.AreEqual(6, respiratory.Products().Count());
        }

        /// <summary>
        /// Tests if all the references are correct
        /// </summary>
        [TestMethod]
        public void TestReferences()
        {
            Assert.AreEqual(1, respiratory.Categories().First().Products.First().Categories.CategoryID);
            foreach (var OD in respiratory.Products().First().Order_Details)
            {
                Assert.AreEqual(1, OD.Products.ProductID);
            }
            Assert.AreEqual(1, respiratory.Orders().First().Order_Details.First().Orders.OrderID);

            Assert.AreEqual(3, respiratory.Orders().Last().Order_Details.First().Orders.OrderID);
            foreach (var o in respiratory.Orders())
            {
                Assert.AreEqual(1, o.Order_Details.First().Products.Categories.CategoryID);
            }
        }
    }
}
