using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using GreenFood.Models;
namespace GreenFood.Areas.Admin.Controllers
{
    public class InAndOutController : Controller
    {
        // GET: Admin/InAndOut
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public ActionResult Index()
        {
            if (Session["NHANVIEN"] != null)
            {
                return RedirectToAction("ReturnLogin", "Home");
            }
            return View();
        }
        public ActionResult ReturnLogin()
        {
            if (Session["NHANVIEN"] == null)
            {
                return RedirectToAction("Index", "InAndOut");
            }
            return View();
        }

        // Chức năng đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var userName = f["UserName"];
            var pw = f["Pw"];
            NHANVIEN qt = db.NHANVIENs.SingleOrDefault(n => n.UserName == userName && n.Pw == (pw));
            if (qt != null)
            {
                Session["NHANVIEN"] = qt;
                if(qt.UserName.Equals(f["UserName"]) == true && qt.Pw.Equals(f["Pw"]) == true)
                {
                    if (f["remember"].Contains("true"))
                    {
                        Response.Cookies["UserName"].Value = userName;
                        Response.Cookies["Pw"].Value = pw;
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(-1);
                    }
                    return RedirectToAction("ReturnLogin", "InAndOut");
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(-1);
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
                    return View();
                }

            }
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(-1);
            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }
        public ActionResult AreaInfo()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["NHANVIEN"] = null;
            return RedirectToAction("Index", "InAndOut");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

        //Đổi mật khẩu
        [HttpGet]
        public ActionResult DoiMatKhau(int id)
        {
            var tp = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);//id
            //ViewBag.MaThucPham = new SelectList(db.THUCPHAMs.ToList().Where(n => n.MaThucPham == idMTP), "MaThucPham", "TenThucPham");
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DoiMatKhau(int id, FormCollection f)
        {
            String tmpPwc, tmpPw1, tmpPw2;
            var tp = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);//id
            if (ModelState.IsValid)
            {
                tmpPwc = f["Pw"];
                tmpPw1 = f["Pwm"];
                tmpPw2 = f["xnpw"];
                if(tmpPw1.Equals(tmpPw2) == true && tp.Pw.Equals(tmpPwc) == true)
                {
                    tp.Pw = f["xnpw"];
                    db.SubmitChanges();
                    return RedirectToAction("DoiMatKhauTC", "InAndOut");
                }
                else if (tp.Pw.Equals(tmpPwc) == false)
                {
                    ViewBag.ThongBao1 = "Mật khẩu cũ không đúng!";
                    return View();
                }
                else if(tmpPw1.Equals(tmpPw2) == false)
                {
                    ViewBag.ThongBao2 = "Mật khẩu mới không trùng khớp!";
                    return View();
                }
                
                
            }
            return View(tp);
        }
        //Thông báo đổi mật khẩu thành công
        public ActionResult DoiMatKhauTC()
        {
            return View();
        }
    }
}