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
            IRespiratory respiratory = new Respiratory(new Product[0], new Category[0], new Order[0], new OrderDetails[0]);

            for (int i = 0; i < 10; i++)
            {
                Orders order = new Orders(0,
                                    null, null,
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    1, 2d,
                                    "name", "address", "city", "region", "pcode", "country");

                respiratory.CreateOrder(order);

                Assert.AreEqual(i+1, order.OrderID);
            }
        }

        /// <summary>
        /// Tests the linq for finding the first 5 products, by hvaing 6 test products and only finding the first 5.
        /// </summary>
        [TestMethod]
        public void TestFirst5Products()
        {
            Program.ConsoleLock.Clear();

            Products[] products = new Products[6];
            for (int i = 0; i < 6; i++)
            {
                products[i] = new Products("name" + i,null,null,""+i,i,i,i,i,i);
            }

            IRespiratory respiratory = new Respiratory(products, new Category[0], new Order[0], new OrderDetails[0]);
            NorthWind northWind = new NorthWind(respiratory);

            Program.First5Products(northWind);

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

            Order[] orders = new Order[5];

            for (int i = 0; i < 3; i++)
            {
                orders[i] = new Order(0,
                                    null, null,
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    1, 2d,
                                    "name", "address", "city", "region", "pcode", "DK");
            }

            for (int i = 0; i < 2; i++)
            {
                orders[i+3] = new Order(0,
                                    null, null,
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    DateTime.Parse("1996-07-08 00:00:00"),
                                    1, 2d,
                                    "name", "address", "city", "region", "pcode", "ENG");
            }

            Respiratory respiratory = new Respiratory(new Product[0], new Category[0], orders, new OrderDetails[0]);
            NorthWind northWind = new NorthWind(respiratory);

            Program.OrdersByShippingCountry(northWind);

            Assert.AreEqual("ENG : 2", Program.ConsoleLock[0]);
            Assert.AreEqual("DK : 3", Program.ConsoleLock[1]);
        }
    }
}
