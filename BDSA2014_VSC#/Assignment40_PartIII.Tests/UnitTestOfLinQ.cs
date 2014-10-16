using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment40_PartIII.Tests
{

    /// <summary>
    /// This UnitTest is resposible for chekking if the linq in this project is working correct.
    /// </summary>
    [TestClass]
    public class UnitTestOfLinQ
    {
//        /// <summary>
//        /// Tests the linq for making new order IDs, by adding and testing 5 new orders.
//        /// </summary>
//        [TestMethod]
//        public void TestOrderIdPlus1()
//        {
//            Respiratory respiratory = new Respiratory(new Product[0], new Category[0], new Order[0], new OrderDetails[0]);
//
//            for (int i = 0; i < 10; i++)
//            {
//                Order order = new Order(0,
//                                    null, null,
//                                    DateTime.Parse("1996-07-08 00:00:00"),
//                                    DateTime.Parse("1996-07-08 00:00:00"),
//                                    DateTime.Parse("1996-07-08 00:00:00"),
//                                    1, 2d,
//                                    "name", "address", "city", "region", "pcode", "country");
//
//                respiratory.CreateOrder(order);
//
//                Assert.AreEqual(i+1, order.OrderID);
//            }
//        }
//
//        /// <summary>
//        /// Tests the linq for finding the first 5 products, by hvaing 6 test products and only finding the first 5.
//        /// </summary>
//        [TestMethod]
//        public void TestFirst5Products()
//        {
//            Program.ConsoleLock.Clear();
//
//            Product[] products = new Product[6];
//            for (int i = 0; i < 6; i++)
//            {
//                products[i] = new Product("name" + i,null,null,""+i,i,i,i,i,i);
//            }
//
//            Respiratory respiratory = new Respiratory(products, new Category[0], new Order[0], new OrderDetails[0]);
//            NorthWind northWind = new NorthWind(respiratory);
//
//            Program.First5Products(northWind);
//
//            for (int i = 0; i < 5; i++)
//            {
//                Assert.AreEqual("name" + i, Program.ConsoleLock[i]);
//            }
//        }
//
//        /// <summary>
//        /// Tests the linq for "Write the counting of orders by shipping country. Order the output by descending count",
//        /// by having 5 orders divided to 2 countrys, and tests if thay com out ind the right order.
//        /// </summary>
//        [TestMethod]
//        public void TestOrdersByShippingCountry()
//        {
//            Program.ConsoleLock.Clear();
//
//            Respiratory respiratory = new Respiratory(new NorthWindContext());
//                                                        //SKAL VARE EN STUP
//            NorthWind northWind = new NorthWind(respiratory);
//
//            for (int i = 0; i < 3; i++)
//            {
//                northWind.AddOrder(DateTime.Parse("1996-07-08 00:00:00"), "name", "address", "city", "region", "pcode", "DK");
//            }
//
//            for (int i = 0; i < 2; i++)
//            {
//                northWind.AddOrder(DateTime.Parse("1996-07-08 00:00:00"), "name", "address", "city", "region", "pcode", "ENG");
//            }
//
//            Program.OrdersByShippingCountry(northWind);
//
//            Assert.AreEqual("ENG : 2", Program.ConsoleLock[0]);
//            Assert.AreEqual("DK : 3", Program.ConsoleLock[1]);
//        }
    }
}
