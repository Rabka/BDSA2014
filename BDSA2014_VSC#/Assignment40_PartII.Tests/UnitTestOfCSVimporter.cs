using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment40_PartII.Tests
{
    /// <summary>
    /// This UnitTest is resposible for chekking if the importer do import the right things.
    /// </summary>
    [TestClass]
    public class UnitTestOfCSVimporter
    {
        Respiratory respiratory;

        /// <summary>
        /// Sets up the respiratory.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            respiratory = CSVimporter.ImportCSV();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestForNumberOfCategorys()
        {
            Assert.AreEqual(8, respiratory.Categories().Length);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestForNumberOfOrders()
        {
            Assert.AreEqual(830, respiratory.Orders().Length);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestForNumberOfOrderDetails()
        {
            Assert.AreEqual(2155, respiratory.OrderDetails().Length);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestForNumberOfProducts()
        {
            Assert.AreEqual(77, respiratory.Products().Length);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestClassreferenceses()
        {
            foreach (OrderDetails item in respiratory.OrderDetails())
            {
                Assert.IsNotNull(item.OrderID);
                Assert.IsNotNull(item.ProductID);
                Assert.IsNotNull(item.ProductID.CategoryID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestIfClassVariableAreCorrect()
        {
            foreach (Order item in respiratory.Orders())
            {
                if(item.OrderID != 10250)
                    continue;
                Assert.AreEqual(DateTime.Parse("1996-07-08 00:00:00"), item.OrderDate);
                Assert.AreEqual(DateTime.Parse("1996-08-05 00:00:00"), item.RequiredDate);
                Assert.AreEqual(DateTime.Parse("1996-07-12 00:00:00"), item.ShippedDate);
                Assert.AreEqual(2, item.ShipVia);
                Assert.AreEqual(65.83d, item.Freight);
                Assert.AreEqual("Hanari Carnes", item.ShipName);
                Assert.AreEqual("Rua do Pa‡o, 67", item.ShipAddress);
                Assert.AreEqual("Rio de Janeiro", item.ShipCity);
                Assert.AreEqual("RJ", item.ShipRegion);
                Assert.AreEqual("05454-876", item.ShipPostalCode);
                Assert.AreEqual("Brazil", item.ShipCountry);
            }
        }
    }
}
