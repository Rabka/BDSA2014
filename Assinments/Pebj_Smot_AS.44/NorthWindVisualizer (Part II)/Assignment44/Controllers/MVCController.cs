using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment44.Models;

namespace Assignment44.Controllers
{
    public class MVCController : Controller
    {
        private readonly IRespiratory db;

        /// <summary>
        /// Default Constructor. Will create a respiratory rather than reuse it.
        /// </summary>
        public MVCController()
        {
            db = new Respiratory(new NORTHWNDdataset());
        }

        /// <summary>
        /// Default Constructor. Will reuse provided respiratory.
        /// </summary>
        /// <param name="respiratory">Respiratory to reuse</param>
        public MVCController(IRespiratory respiratory)
        {
            db = respiratory;
        }

        /// <summary>
        /// Returns a list of orders to the view only including Customers and Employees.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult OrdersView()
        {
            var orders = db.Orders().Include(o => o.Customers).Include(o => o.Employees);
            return View(orders.ToList());
        }

        /// <summary>
        /// Returns a list of Order_Details for a given orderId that includes the Order_Details' associated Order and Products.
        /// </summary>
        /// <param name="orderId">OrderId of the Order to get the details of</param>
        /// <returns>View</returns>
        public ActionResult Order_detailsView(int? orderId)
        {
            if (orderId != null)
            {
                var order_Details2 = db.OrderDetails().Select(x => x).Where(x => x.OrderID == orderId).Include(o => o.Orders).Include(o => o.Products);
                ViewBag.Id = orderId;
                return View(order_Details2.ToList());
            }

            var order_Details = db.OrderDetails().Include(o => o.Orders).Include(o => o.Products);
            return View(order_Details.ToList());
        }

        /// <summary>
        /// Returns a list of products that has the given productId and will include Categories.
        /// </summary>
        /// <param name="productId">productId of the Product</param>
        /// <returns>View</returns>
        public ActionResult ProductsView(int? productId)
        {
            if (productId != null)
            {
                var products2 = db.Products().Select(x => x).Where(x => x.ProductID == productId).Include(p => p.Categories);
                return View(products2.ToList());
            }

            var products = db.Products().Include(p => p.Categories);
            return View(products.ToList());
        }
    }
}
