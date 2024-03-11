using QLCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCP.Controllers
{
    public class Thống_kêController : Controller
    {
        private QLBHEntities db = new QLBHEntities();
        // GET: Thống_kê
        public ActionResult Thống_kê(int month)
        {
            int tongSL = db.Hóa_đơn_bán
                .Where(g => g.Ngày_xuất == month)
                .Sum(g => g.Mã_sản_phẩm);
            ViewBag.Month = month;
            ViewBag.Thống_kê = tongSL;
            return View();
        }
    }
}