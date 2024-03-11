using QLCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private QLBHEntities db = new QLBHEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}