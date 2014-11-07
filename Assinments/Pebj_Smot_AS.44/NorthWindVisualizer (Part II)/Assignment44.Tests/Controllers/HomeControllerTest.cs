using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Assignment44.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment44;
using Assignment44.Controllers;

namespace Assignment44.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_OrdersView()
        {
            // Arrange
            MVCController controller = new MVCController();

            // Act
            ViewResult result = controller.OrdersView() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Order_detailsView()
        {
            // Arrange
            MVCController controller = new MVCController();

            // Act
            ViewResult result = controller.Order_detailsView(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, ((IEnumerable<Order_Details>)result.Model).First().OrderID);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            MVCController controller = new MVCController();

            // Act
            ViewResult result = controller.ProductsView(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
