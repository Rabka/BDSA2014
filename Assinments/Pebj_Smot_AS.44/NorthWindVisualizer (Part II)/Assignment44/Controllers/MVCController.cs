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
        private NORTHWNDdataset db = new NORTHWNDdataset();

        // GET: Orders
        public ActionResult OrdersView()
        {
            var orders = db.Orders.Include(o => o.Customers).Include(o => o.Employees);
            return View(orders.ToList());
        }

        // GET: Order_Details
        public ActionResult Order_detailsView(int? orderId)
        {
            if (orderId != null)
            {
                var order_Details2 = db.Order_Details.Select(x => x).Where(x => x.OrderID == orderId).Include(o => o.Orders).Include(o => o.Products);
                ViewBag.Id = orderId;
                return View(order_Details2.ToList());
            }

            var order_Details = db.Order_Details.Include(o => o.Orders).Include(o => o.Products);
            return View(order_Details.ToList());
        }

        // GET: Products
        public ActionResult ProductsView(int? productId)
        {
            if (productId != null)
            {
                var products2 = db.Products.Select(x => x).Where(x => x.ProductID == productId).Include(p => p.Categories);
                return View(products2.ToList());
            }

            var products = db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }
    }
}
