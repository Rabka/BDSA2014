using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignment44.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment44.Controllers;

namespace Assignment44.Tests.Controllers
{
    [TestClass]
    public class MvcControllerTest
    {
        [TestMethod]
        public void Test_OrdersView()
        {
            // Arrange
            MVCController controller = new MVCController(new RespiratoryStub());

            // Act
            ViewResult result = controller.OrdersView() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IEnumerable<Orders>)result.Model).First().OrderID);
        }

        [TestMethod]
        public void Test_Order_detailsView()
        {
            // Arrange
            MVCController controller = new MVCController(new RespiratoryStub());

            // Act
            ViewResult result = controller.Order_detailsView(null) as ViewResult;
            ViewResult result2 = controller.Order_detailsView(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IEnumerable<Order_Details>)result.Model).First().OrderID);
            Assert.AreEqual(1, ((IEnumerable<Order_Details>)result2.Model).First().OrderID);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            MVCController controller = new MVCController(new RespiratoryStub());

            // Act
            ViewResult result = controller.ProductsView(null) as ViewResult;
            ViewResult result2 = controller.ProductsView(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IEnumerable<Products>)result.Model).First().ProductID);
            Assert.AreEqual(1, ((IEnumerable<Products>)result2.Model).First().ProductID);
        }
    }
}
