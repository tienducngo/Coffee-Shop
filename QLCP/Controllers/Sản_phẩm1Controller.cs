using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCP.Models;

namespace QLCP.Controllers
{
    [Authorize]
    public class Sản_phẩm1Controller : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Sản_phẩm1
        public ActionResult Index()
        {
            return View(db.Sản_phẩm.ToList());
        }

        // GET: Sản_phẩm1/Details/5
        public ActionResult Details(int? id)
        {
            Sản_phẩm p = db.Sản_phẩm.FirstOrDefault(s => s.Mã_sản_phẩm == id);
            return View(p);

        }

        // GET: Sản_phẩm1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sản_phẩm1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_sản_phẩm,Tên_sản_phẩm,Giá_gốc,Giá_bán,Hình")] Sản_phẩm sản_phẩm)
        {
            if (ModelState.IsValid)
            {
                db.Sản_phẩm.Add(sản_phẩm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sản_phẩm);
        }

        // GET: Sản_phẩm1/Edit/5
        public ActionResult Edit(int? id)
        {
            Sản_phẩm p = db.Sản_phẩm.FirstOrDefault(s => s.Mã_sản_phẩm == id);
            return View(p);

        }

        // POST: Sản_phẩm1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sản_phẩm DA, FormCollection collection)
        {
            try
            {
                //Lấy sp muốn sửa
                Sản_phẩm p = db.Sản_phẩm.First(s => s.Mã_sản_phẩm == DA.Mã_sản_phẩm);
                //Gán thuộc tính
                p.Mã_sản_phẩm = DA.Mã_sản_phẩm;
                p.Tên_sản_phẩm = DA.Tên_sản_phẩm;
                p.Giá_gốc = DA.Giá_gốc;
                p.Giá_bán = DA.Giá_bán;
                //Lưu db
                db.SaveChanges();
                //Hiển thị lại
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Sản_phẩm1/Delete/5
        public ActionResult Delete(int? id)
        {
            Sản_phẩm p = db.Sản_phẩm.FirstOrDefault(s => s.Mã_sản_phẩm == id);
            return View(p);
        }

        // POST: Sản_phẩm1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Sản_phẩm p = db.Sản_phẩm.FirstOrDefault(s => s.Mã_sản_phẩm == id);
                db.Sản_phẩm.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }

        public ActionResult fdPartial() //Hiện 1 phần danh sách món ăn của trang chủ
        {
            var mon = db.Sản_phẩm.ToList();
            return PartialView(mon);
        }

        public ActionResult Search(string SearchString)
        {
            if (String.IsNullOrWhiteSpace(SearchString)) //kiểm tra strong có null ko hoặc có dấu cách
            {
                return View();
            }
            var lsp = db.Sản_phẩm.Where(n => n.Tên_sản_phẩm.Contains(SearchString)).ToList();
            return View(lsp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
