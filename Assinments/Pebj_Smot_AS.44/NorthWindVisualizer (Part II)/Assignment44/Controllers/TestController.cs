﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment44.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/ 

        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Test/Welcome/
        // GET: /Test/Welcome?name=Scott&numtimes=4

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}