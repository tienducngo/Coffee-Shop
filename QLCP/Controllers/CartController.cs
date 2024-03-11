using cp.Models;
using QLCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        private List<CartModel> GetListCarts()
        {
            List<CartModel> carts = Session["CartModel"] as List<CartModel>; //Lấy DS giỏ hàng từ biến SS, biến SS để lưu trữ db, ép kiểu nó thành "CartModel"
            if (carts == null) // chưa có sp nào trong giỏ hàng
            {
                carts = new List<CartModel>(); //tạo DS giỏ hàng
                Session["CartModel"] = carts; // Lưu sp vào ds mới đó
            }
            return carts;
        }
        public ActionResult ListCarts() //Tạo giỏ hàng
        {
            List<CartModel> carts = GetListCarts(); //Lấy sp trong giỏ hàng, danh sách đó đc lưu trong "Carts"
            //view.bag là truyền dữ liệu trừ controll qua view
            ViewBag.CoutSP = carts.Sum(s => s.Số_lượng);
            ViewBag.Total = carts.Sum(s => s.Thành_tiền);
            return View(carts);
        }
     
        public ActionResult AddCarts(int id) //Thêm SP vào giỏ
        {
            //Lấy được  DS SP trong list
            List<CartModel> carts = GetListCarts();
            //Tìm SP
            CartModel sp = carts.Find(s => s.Mã_sản_phẩm == id);
            if (sp == null)
            {
                //Tạo mới 1 SP trong giỏ
                sp = new CartModel(id);
                //Thêm nó vào
                carts.Add(sp);
            }
            else
            {
                sp.Số_lượng++;
            }
            //Hiển thị
            return RedirectToAction("ListCarts");
        }
        public ActionResult Order() 
        {
            //Tạo đơn hàng
            Hóa_đơn_bán hoadon = new Hóa_đơn_bán();
            hoadon.Ngày_xuất_HĐ = DateTime.Now;
            db.Hóa_đơn_bán.Add(hoadon);
            db.SaveChanges();
            foreach (CartModel item in GetListCarts())
            {
                Hóa_đơn_bán hdb = new Hóa_đơn_bán();
                hdb.Mã_sản_phẩm = hoadon.Mã_sản_phẩm;
                hdb.Sản_phẩm = hoadon.Sản_phẩm;
                hdb.Ngày_xuất_HĐ = hoadon.Ngày_xuất_HĐ;
            }
            db.SaveChangesAsync();
            //Hiển thị 
            return RedirectToAction("ListOrders");
        }
        QLBHEntities db = new QLBHEntities();
        public ActionResult ListOrder() 
        {
            var danhsach = db.Hóa_đơn_bán.OrderByDescending(s => s.Ngày_xuất_HĐ).ToList(); //sắp sếp HĐ theo thứ tự giảm dần
            return View(danhsach);
        }
    }

}