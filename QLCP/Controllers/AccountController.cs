using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QLCP.Models;

namespace QLCP.Controllers
{
    public class AccController : Controller
    {
        QLBHEntities da = new QLBHEntities();
        // GET: Acc
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = da.Admins.Any(s => s.User == credentials.Username && s.Password == credentials.Password);
            Admin u = da.Admins.FirstOrDefault(s => s.User == credentials.Username && s.Password == credentials.Password);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.User, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Admin userinfo)
        {
            da.Admins.Add(userinfo);
            da.SaveChanges();
            return RedirectToAction("Login");
        }


        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
