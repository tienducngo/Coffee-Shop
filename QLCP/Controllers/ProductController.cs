﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ListProduct()
        {
            return View();
        }
    }
}