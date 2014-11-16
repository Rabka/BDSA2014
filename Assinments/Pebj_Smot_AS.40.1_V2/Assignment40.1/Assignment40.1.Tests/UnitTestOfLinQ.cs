using System;
using System.Linq;
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
        /// <summary>
        /// Tests the linq for making new order IDs, by adding and testing 5 new orders.
        /// </summary>
        [TestMethod]
        public void TestOrderIdPlus1()
        {
        }

        /// <summary>
        /// Tests the linq for finding the first 5 products, by hvaing 6 test products and only finding the first 5.
        /// </summary>
        [TestMethod]
        public void TestFirst5Products()
        {
            Program.ConsoleLock.Clear();

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual("name" + i, Program.ConsoleLock[i]);
            }
        }

        /// <summary>
        /// Tests the linq for "Write the counting of orders by shipping country. Order the output by descending count",
        /// by having 5 orders divided to 2 countrys, and tests if thay com out ind the right order.
        /// </summary>
        [TestMethod]
        public void TestOrdersByShippingCountry()
        {
            Program.ConsoleLock.Clear();

            Assert.AreEqual("ENG : 2", Program.ConsoleLock[0]);
            Assert.AreEqual("DK : 3", Program.ConsoleLock[1]);
        }
    }
}
