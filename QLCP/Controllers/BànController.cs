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
    public class BànController : Controller
    {
        private QLBHEntities db = new QLBHEntities();

        // GET: Bàn
        public ActionResult Index()
        {
            return View(db.Bàn.ToList());
        }

        // GET: Bàn/Details/5
        public ActionResult Details(int? id)
        {
            Bàn p = db.Bàn.FirstOrDefault(s => s.Số_bàn == id);
            return View(p);
        }

        // GET: Bàn/Create
        public ActionResult Create()
        {
            var TT = db.Bàn; //Khai báo
            List<Bàn> btt = TT.ToList();
            //Tạo
            SelectList lbtt = new SelectList(btt, "Trạng_Thái", "Trạng_thái");
            //Set
            ViewBag.dssTT = lbtt;
            return View();
        }
        //public void SetViewBag(long? selectedSố_bàn = null)
        //{
        //  var TT = new BanTT();
        //  ViewBag.Số_bàn = new SelectList (TT.ListAll(), "Trạng_thái", "Số_bàn", selectedSố_bàn) ;
        //}

        // POST: Bàn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bàn B, FormCollection collection/*[Bind(Include = "Số_bàn")] Bàn bàn*/)
        {
            try
            {
                //Tạo một bàn mới
                Bàn p = new Bàn();
                //Gán
                p = B;
                //Thêm vào
                db.Bàn.Add(p);
                //Lưu
                db.SaveChanges();
                //Gọi
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Bàn.Add(bàn);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(bàn);
        }

        // GET: Bàn/Edit/5
        public ActionResult Edit(int? id)
        {
            var TT = db.Bàn; //Khai báo
            List<Bàn> btt = TT.ToList();
            //Tạo
            SelectList lbtt = new SelectList(btt, "Trạng_Thái", "Trạng_thái");
            //Set
            ViewBag.dssTT = lbtt;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bàn bàn = db.Bàn.Find(id);
            if (bàn == null)
            {
                return HttpNotFound();
            }
            return View(bàn);
        }

        // POST: Bàn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bàn B, FormCollection collection)
        {
            //try
            //{
            //    //Lấy sp muốn sửa
            //    Bàn p = db.Bàn.First(s => s.Số_bàn == B.Số_bàn);
            //    //Gán thuộc tính
            //    //p.Số_bàn = B.Số_bàn;
            //    p.Trạng_thái = B.Trạng_thái;
            //    p.Tên_bàn = B.Tên_bàn;
            //    //Lưu db
            //    db.SaveChanges();
            //    //Hiển thị lại
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            try
            {
                //Lấy sp muốn sửa
                Bàn p = db.Bàn.First(s => s.Số_bàn == B.Số_bàn);
                //Gán thuộc tính
                p.Trạng_thái = B.Trạng_thái;
                //p.Tên_bàn = B.Tên_bàn;
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

        // GET: Bàn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bàn bàn = db.Bàn.Find(id);
            if (bàn == null)
            {
                return HttpNotFound();
            }
            return View(bàn);
        }

        // POST: Bàn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bàn bàn = db.Bàn.Find(id);
            db.Bàn.Remove(bàn);
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
