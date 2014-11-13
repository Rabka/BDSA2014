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
        /// Tests if ther is the rigth number of Categorys.
        /// </summary>
        [TestMethod]
        public void TestForNumberOfCategorys()
        {
            Assert.AreEqual(8, respiratory.Categories().Count());
        }

        /// <summary>
        /// Tests if ther is the rigth number of Orders.
        /// </summary>
        [TestMethod]
        public void TestForNumberOfOrders()
        {
            Assert.AreEqual(830, respiratory.Orders().Count());
        }

        /// <summary>
        /// Tests if ther is the rigth number of OrderDetails.
        /// </summary>
        [TestMethod]
        public void TestForNumberOfOrderDetails()
        {
            Assert.AreEqual(2155, respiratory.Orders().Sum(x => x.Order_Details.Count));
        }

        /// <summary>
        /// Tests if ther is the rigth number of Products.
        /// </summary>
        [TestMethod]
        public void TestForNumberOfProducts()
        {
            Assert.AreEqual(77, respiratory.Products().Count());
        }

        /// <summary>
        /// Tests if alle the data classes, class referenceses is set right.
        /// </summary>
        [TestMethod]
        public void TestClassReferenceses()
        {
            foreach (Order_Details item in respiratory.Orders().Select(x => x.Order_Details))
            {
                Assert.IsNotNull(item.OrderID);
                Assert.IsNotNull(item.ProductID);
                Assert.IsNotNull(item.Products.CategoryID);
            }
        }

        /// <summary>
        /// Tests if a specific order have been inportet correct.
        /// </summary>
        [TestMethod]
        public void TestIfClassVariableAreCorrect()
        {
            foreach (Orders item in respiratory.Orders())
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
