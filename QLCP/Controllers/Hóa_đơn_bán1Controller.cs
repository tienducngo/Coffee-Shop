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
    public class Hóa_đơn_bán1Controller : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Hóa_đơn_bán1
        public ActionResult Index()
        {
            var hóa_đơn_bán = db.Hóa_đơn_bán/*.Include(h => h.Bàn)*/.Include(h => h.Nhân_viên).Include(h => h.Sản_phẩm);
            return View(hóa_đơn_bán.ToList());
        }

        // GET: Hóa_đơn_bán1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn_bán hóa_đơn_bán = db.Hóa_đơn_bán.Find(id);
            if (hóa_đơn_bán == null)
            {
                return HttpNotFound();
            }
            return View(hóa_đơn_bán);
        }

        // GET: Hóa_đơn_bán1/Create
        public ActionResult Create()
        {
            //ViewBag.Số_bàn = new SelectList(db.Bàn, "Số_bàn", "Tên_bàn");
            ViewBag.Mã_nhân_viên = new SelectList(db.Nhân_viên, "Mã_nhân_viên", "Tên_nhân_viên");
            ViewBag.Mã_sản_phẩm = new SelectList(db.Sản_phẩm, "Mã_sản_phẩm", "Tên_sản_phẩm");
            return View();
        }

        // POST: Hóa_đơn_bán1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_HĐ,Mã_sản_phẩm,Số_bàn,Ngày_xuất_HĐ,Mã_nhân_viên")] Hóa_đơn_bán hóa_đơn_bán)
        {
            if (ModelState.IsValid)
            {
                db.Hóa_đơn_bán.Add(hóa_đơn_bán);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Số_bàn = new SelectList(db.Bàn, "Số_bàn", "Tên_bàn", hóa_đơn_bán.Số_bàn);
            ViewBag.Mã_nhân_viên = new SelectList(db.Nhân_viên, "Mã_nhân_viên", "Tên_nhân_viên", hóa_đơn_bán.Mã_nhân_viên);
            ViewBag.Mã_sản_phẩm = new SelectList(db.Sản_phẩm, "Mã_sản_phẩm", "Tên_sản_phẩm", hóa_đơn_bán.Mã_sản_phẩm);
            return View(hóa_đơn_bán);
        }

        // GET: Hóa_đơn_bán1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn_bán hóa_đơn_bán = db.Hóa_đơn_bán.Find(id);
            if (hóa_đơn_bán == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Số_bàn = new SelectList(db.Bàn, "Số_bàn", "Tên_bàn", hóa_đơn_bán.Số_bàn);
            ViewBag.Mã_nhân_viên = new SelectList(db.Nhân_viên, "Mã_nhân_viên", "Tên_nhân_viên", hóa_đơn_bán.Mã_nhân_viên);
            ViewBag.Mã_sản_phẩm = new SelectList(db.Sản_phẩm, "Mã_sản_phẩm", "Tên_sản_phẩm", hóa_đơn_bán.Mã_sản_phẩm);
            return View(hóa_đơn_bán);
        }

        // POST: Hóa_đơn_bán1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_HĐ,Mã_sản_phẩm,Số_bàn,Ngày_xuất_HĐ,Mã_nhân_viên")] Hóa_đơn_bán hóa_đơn_bán)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hóa_đơn_bán).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Số_bàn = new SelectList(db.Bàn, "Số_bàn", "Tên_bàn", hóa_đơn_bán.Số_bàn);
            ViewBag.Mã_nhân_viên = new SelectList(db.Nhân_viên, "Mã_nhân_viên", "Tên_nhân_viên", hóa_đơn_bán.Mã_nhân_viên);
            ViewBag.Mã_sản_phẩm = new SelectList(db.Sản_phẩm, "Mã_sản_phẩm", "Tên_sản_phẩm", hóa_đơn_bán.Mã_sản_phẩm);
            return View(hóa_đơn_bán);
        }

        // GET: Hóa_đơn_bán1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn_bán hóa_đơn_bán = db.Hóa_đơn_bán.Find(id);
            if (hóa_đơn_bán == null)
            {
                return HttpNotFound();
            }
            return View(hóa_đơn_bán);
        }

        // POST: Hóa_đơn_bán1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hóa_đơn_bán hóa_đơn_bán = db.Hóa_đơn_bán.Find(id);
            db.Hóa_đơn_bán.Remove(hóa_đơn_bán);
            db.SaveChanges();
            return RedirectToAction("Index");
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
