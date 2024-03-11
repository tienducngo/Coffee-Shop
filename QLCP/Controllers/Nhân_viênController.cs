using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCP.Models;

namespace QuanLyCaPhe.Controllers
{
    [Authorize]
    public class Nhân_viênController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Nhân_viên
        public ActionResult Index()
        {
            return View(db.Nhân_viên.ToList());
        }

        // GET: Nhân_viên/Details/5
        public ActionResult Details(int id)
        {
            Nhân_viên p = db.Nhân_viên.FirstOrDefault(s => s.Mã_nhân_viên == id);
            return View(p);
        }

        // GET: Nhân_viên/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nhân_viên/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_nhân_viên,Tên_nhân_viên,Ngày_vào_làm,Vị_trí")] Nhân_viên nhân_viên)
        {
            if (ModelState.IsValid)
            {
                db.Nhân_viên.Add(nhân_viên);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhân_viên);
        }

        // GET: Nhân_viên/Edit/5
        public ActionResult Edit(int id)
        {
            Nhân_viên p = db.Nhân_viên.FirstOrDefault(s => s.Mã_nhân_viên == id);
            return View(p);
        }

        // POST: Nhân_viên/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nhân_viên NV, FormCollection collection)
        {
            try
            {
                //Lấy sp muốn sửa
                Nhân_viên p = db.Nhân_viên.FirstOrDefault(s => s.Mã_nhân_viên == NV.Mã_nhân_viên);
                //Gán thuộc tính
                //p.Mã_nhân_viên = NV.Mã_nhân_viên;
                p.Tên_nhân_viên = NV.Tên_nhân_viên;
                //p.Ngày_vào_làm = NV.Ngày_vào_làm;
                p.Vị_trí = NV.Vị_trí;
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

        // GET: Nhân_viên/Delete/5
        public ActionResult Delete(int id)
        {
            Nhân_viên p = db.Nhân_viên.FirstOrDefault(s => s.Mã_nhân_viên == id);
            return View(p);
        }

        // POST: Nhân_viên/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Nhân_viên p = db.Nhân_viên.FirstOrDefault(s => s.Mã_nhân_viên == id);
                db.Nhân_viên.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
