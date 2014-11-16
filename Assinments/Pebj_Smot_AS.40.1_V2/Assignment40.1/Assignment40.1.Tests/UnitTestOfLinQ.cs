using System;
using System.Linq;
using Assignment40_1.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment40_1.Model;

namespace Assignment40_1.Tests
{

    /// <summary>
    /// This UnitTest is resposible for chekking if the linq in this project is working correct.
    /// </summary>
    [TestClass]
    public class UnitTestOfLinQ
    {
        IRespiratory respiratory;
        private NorthWind northWind;

        /// <summary>
        /// Sets up the respiratory.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            respiratory = CSVimporter.ImportCSV(Resources.TestCategories, Resources.TestProducts, Resources.TestOrders, Resources.TestOrder_details);

            Program.ConsoleLock.Clear();

            northWind = new NorthWind(respiratory);
        }

        /// <summary>
        /// Tests the linq for making new order IDs, by adding and testing 10 new orders.
        /// </summary>
        [TestMethod]
        public void TestOrderIdPlus1()
        {
            for (int i = 0; i < 10; i++)
            {
                Orders order = new Orders(0,
                                    null, null,
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    1, 2,
                                    "name", "address", "city", "region", "pcode", "country");

                respiratory.CreateOrder(order);

                Assert.AreEqual(i + 4, order.OrderID);
            }
        }

        /// <summary>
        /// Tests the linq for finding the first 5 products, by hvaing 6 test products and only finding the first 5.
        /// </summary>
        [TestMethod]
        public void TestFirst5Products()
        {
            Program.First5Products(northWind);

            Assert.AreEqual("TestChai", Program.ConsoleLock[0]);
            Assert.AreEqual("TestChai2", Program.ConsoleLock[1]);
            Assert.AreEqual("TestChai3", Program.ConsoleLock[2]);
            Assert.AreEqual("TestChai4", Program.ConsoleLock[3]);
            Assert.AreEqual("TestChai5", Program.ConsoleLock[4]);
            try
            {
                Assert.AreNotEqual("TestChai6", Program.ConsoleLock[5]);
                Assert.Fail("Error: exception not thrown");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Tests the linq for "Write the counting of orders by shipping country. Order the output by descending count",
        /// by having 5 orders divided to 2 countrys, and tests if thay com out ind the right order.
        /// </summary>
        [TestMethod]
        public void TestOrdersByShippingCountry()
        {
            Program.OrdersByShippingCountry(northWind);

            Assert.AreEqual("TestGermany : 1", Program.ConsoleLock[0]);
            Assert.AreEqual("TestFrance : 2", Program.ConsoleLock[1]);
        }
    }
}
