using System;
using Assignment40_1.Tests.TestStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment40_1.Tests
{
    /// <summary>
    /// This UnitTest is responsible for chekking if the importer do import the right things.
    /// </summary>
    [TestClass]
    public class UnitTestOfReportingModule
    {
        ReportingModule reportingModule;

        /// <summary>
        /// Sets up the respiratory.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            RespiratoryTestStub respiratoryTestStub = new RespiratoryTestStub();
            NorthWindTestStub northWindTestStub = new NorthWindTestStub(respiratoryTestStub);
            reportingModule = new ReportingModule(northWindTestStub);
        }
        /// <summary>
        /// Tests if count makes the method return the correct number of entries.
        /// </summary>
        [TestMethod]
        public void TestTopOrdersByTotalPrice()
        {
            Assert.AreEqual(0, reportingModule.TopOrdersByTotalPrice(0).Data.Count);
            Assert.AreEqual(1, reportingModule.TopOrdersByTotalPrice(1).Data.Count);
        }
        /// <summary>
        /// Tests TestOrdersByTotalPriceDto CustomerContactName property
        /// </summary>
        [TestMethod]
        public void TestOrdersByTotalPriceDto_CustomerContactName()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual("Niels", dto.CustomerContactName);
        }

        /// <summary>
        /// Tests TestOrdersByTotalPriceDto OrderDate property
        /// </summary>
        [TestMethod]
        public void TestOrdersByTotalPriceDto_OrderDate()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual(new DateTime(2014, 10, 2).Ticks, dto.OrderDate.Ticks);
        }

        /// <summary>
        /// Tests TestOrdersByTotalPriceDto OrderId property
        /// </summary>
        [TestMethod]
        public void TestOrdersByTotalPriceDto_OrderId()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual(1, dto.OrderId);
        }
        /// <summary>
        /// Tests TestOrdersByTotalPriceDto TotalPrice property
        /// </summary>
        [TestMethod]
        public void TestOrdersByTotalPriceDto_TotalPrice()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual(4000, dto.TotalPrice);
        }
        /// <summary>
        /// Tests TestOrdersByTotalPriceDto TotalPriceWithDiscount property
        /// </summary>
        [TestMethod]
        public void TestOrdersByTotalPriceDto_TotalPriceWithDiscount()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual(3500, dto.TotalPriceWithDiscount);
        }
        /// <summary>
        /// Tests if count makes the method return the correct number of entries.
        /// </summary>
        [TestMethod]
        public void TestTopProductsBySale()
        {
            OrdersByTotalPriceDto dto = reportingModule.TopOrdersByTotalPrice(1).Data[0];
            Assert.AreEqual(0, dto.TopProductsBySale(0).Data.Count);
            Assert.AreEqual(1, dto.TopProductsBySale(1).Data.Count);
        }



    }
}
