using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWindVisualizer.ModelView;
using NorthWindVisualizer;
using System.Linq;
using System.ComponentModel;
namespace NorthWindVisualizer.Tests
{
    [TestClass]
    public class ModelViewTest
    {
        NorthWindTestStub northWindTestStub;
        OrdersModelView ordersModelView;
        bool delegateCalled = false;
        [TestInitialize]
        public void SetUp()
        {
            //NorthWind teststub has by default 2 orders, 1 category and 1 product preloaded in its constructor.
            northWindTestStub = new NorthWindTestStub();
            ordersModelView = new OrdersModelView(northWindTestStub);
        }

        [TestMethod]
        public void ListOrdersTest()
        {
            //Boundary test
            Assert.AreEqual(2, ordersModelView.ListOrders.Count);
        }

        [TestMethod]
        public void ListOrdersTest()
        {
            //Boundary test
            Assert.AreEqual(2, ordersModelView.ListOrders.Count);
        }
        [TestMethod]
        public void TotalPriceWithNoCurrentOrderTest()
        {
            //State-based test
            Assert.AreEqual(0, ordersModelView.TotalPrice);
        }
        [TestMethod]
        public void TotalPriceTest()
        {
            //Equilence test
            ordersModelView.CurrentOrder = northWindTestStub.Orders().First();
            Assert.AreEqual(27964.5, ordersModelView.TotalPrice);
        }
        [TestMethod]
        public void TestCurrentOrderChangeCausesPropertyChange()
        {
            //Path test
            ordersModelView.PropertyChanged += PropertyChanged;
            ordersModelView.CurrentOrder = northWindTestStub.Orders().First();
            Assert.AreEqual(true, delegateCalled);
        }
        [TestMethod]
        public void TestModelChangeEvent()
        {
            //Path test
            ordersModelView.PropertyChanged += PropertyChanged;
            ordersModelView.modelChangeEvent();
            Assert.AreEqual(true, delegateCalled);
        }
        private void PropertyChanged(object sender,  PropertyChangedEventArgs e)
        {
            delegateCalled = true;
        }
    }
}
