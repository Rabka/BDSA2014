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
        public void TestBoundaryListOrders()
        {
            Assert.AreEqual(2, ordersModelView.ListOrders.Count);
        }
        [TestMethod]
        public void TestStateBasedTotalPriceWithNoCurrentOrder()
        {
            Assert.AreEqual(0, ordersModelView.TotalPrice);
        }
        [TestMethod]
        public void TestEquilenceTotalPrice()
        {
            ordersModelView.CurrentOrder = northWindTestStub.Orders().First();
            Assert.AreEqual(27964.5, ordersModelView.TotalPrice);
        }
        [TestMethod]
        public void TestPathCurrentOrderChangeCausesPropertyChange()
        {
            ordersModelView.PropertyChanged += PropertyChanged;
            ordersModelView.CurrentOrder = northWindTestStub.Orders().First();
            Assert.AreEqual(true, delegateCalled);
        }
        [TestMethod]
        public void TestPathModelChangeEvent()
        {
            ordersModelView.PropertyChanged += PropertyChanged;
            ordersModelView.modelChangeEvent();
            Assert.AreEqual(true, delegateCalled);
        }
        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            delegateCalled = true;
        }
    }
}
