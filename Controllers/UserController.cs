using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using Facebook;
using GreenFood.DAO;
using GreenFood.Common;

namespace GreenFood.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: User
        dbGreenFoodDataContext data = new dbGreenFoodDataContext();
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, THANHVIEN tv)
        {
            var sHoTenTV = collection["HoTenTV"];
            var sUserName = collection["UserName"];
            var sPw = collection["Pw"];
            var sPwNL = collection["PwNL"];
            var sDiaChi = collection["DiaChi"];
            var sEmail = collection["Email"];
            var sDienThoai = collection["DienThoai"];
            var sGioiTinh = collection["GioiTinh"];
            //var dNgayDK = String.Format("{0:MM/dd/yyyy}", getDate());
            if (String.IsNullOrEmpty(sHoTenTV))
            {
                ViewData["err1"] = "Họ tên không được rỗng";
            }
            else if (String.IsNullOrEmpty(sUserName))
            {
                ViewData["err2"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sPw))
            {
                ViewData["err3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(sPwNL))
            {
                ViewData["err4"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(sEmail))
            {
                ViewData["err5"] = "Email không được rỗng";
            }
            else if (String.IsNullOrEmpty(sDiaChi))
            {
                ViewData["err6"] = "Địa không được rỗng";
            }
            else if (String.IsNullOrEmpty(sDienThoai))
            {
                ViewData["err7"] = "Số điện thoại không được rỗng";
            }
            else if (String.IsNullOrEmpty(sGioiTinh))
            {
                ViewData["err8"] = "Vui lòng chọn giới tính";
            }
            else if (data.THANHVIENs.SingleOrDefault(n => n.UserName == sUserName) != null)
            {
                ViewBag.ThongBao = "Tên đăng nhập đã tồn tại";
            }
            else if (data.THANHVIENs.SingleOrDefault(n => n.Email == sEmail) != null)
            {
                ViewBag.ThongBao = "Email đã được sử dụng";
            }
            else
            {
                tv.HoTenTV = sHoTenTV;
                tv.UserName = sUserName;
                tv.Pw = sPw;
                tv.Email = sEmail;
                tv.DiaChi = sDiaChi;
                tv.DienThoai = sDienThoai;
                tv.GioiTinh = sGioiTinh;
                tv.NgayDK = @DateTime.Now;
                data.THANHVIENs.InsertOnSubmit(tv);
                data.SubmitChanges();
                ViewBag.Thongbao = "Đăng ký hoàn tất.";
                return RedirectToAction("DangNhap", "User");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            int state = Convert.ToInt32(Request.QueryString["id"]);
            var sUserName = f["UserName"];
            var sPw = f["Pw"];
            if (String.IsNullOrEmpty(sUserName))
            {
                ViewData["Err1"] = "Vui lòng nhập tên đăng nhập!";
            }
            else if (String.IsNullOrEmpty(sPw))
            {
                ViewData["Err2"] = "Vui lòng nhập mật khẩu!";
            }
            else
            {
                THANHVIEN tv = data.THANHVIENs.SingleOrDefault(n => n.UserName == sUserName && n.Pw == sPw);
                if (tv != null)
                {
                    //ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                    Session["UserName"] = tv;
                    if (f["remember"].Contains("true"))
                    {
                        Response.Cookies["UserName"].Value = sUserName;
                        Response.Cookies["Pw"].Value = sPw;
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Pw"].Expires = DateTime.Now.AddDays(-1);
                    }
                    if (state == 1)
                    {
                        return RedirectToAction("Index", "GreenFood");
                    }
                    else
                    {
                        return RedirectToAction("DatHang", "GioHang"); // edit
                    }
                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return this.DangNhap();
        }
        public ActionResult DangXuat()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "GreenFood");
        }
        public ActionResult LoginPartial()
        {
            return View();
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
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {

                client_id = "898265251060927",//"564162594721745",//ConfigurationManager.AppSettings["FbAppId"],//"898265251060927",//
                client_secret = "20a41e0b24a8fcc4d77587241ddc35ed",//"3943b447aa889b3facb8fa363718235e",// ConfigurationManager.AppSettings["FbAppSecret"],//"20a41e0b24a8fcc4d77587241ddc35ed",//
                //redirect_uri = Redirect.AbsoluteUri,
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "898265251060927",//"564162594721745",//ConfigurationManager.AppSettings["FbAppId"],//"898265251060927",//
                client_secret = "20a41e0b24a8fcc4d77587241ddc35ed",//"3943b447aa889b3facb8fa363718235e",// ConfigurationManager.AppSettings["FbAppSecret"],//"20a41e0b24a8fcc4d77587241ddc35ed",//
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!String.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new THANHVIEN();
                user.Email = email;
                user.UserName = email;
                user.HoTenTV = firstname + " " + middlename + " " + lastname;
                user.NgayDK = DateTime.Now;
                var resultInsert = new ThanhVienDAO().InsertForFacebook(user);

                if (resultInsert > 0)
                {
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.MaTV;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                    
                }

            }
            return RedirectToAction("Index", "GreenFood");
        }


        //Trang liên hệ
        [HttpGet]
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LienHe(FormCollection f)
        {
            TINNHANLIENHE tn = new TINNHANLIENHE();
            tn.TenKH = f["HoTen"];
            tn.Email = f["Email"];
            tn.TieuDe = f["TieuDe"];
            tn.NoiDungTuKH = f["NoiDung"];
            tn.TraLoi = "";
            tn.MaNhanVien = 0;
            tn.NgayNhan = DateTime.Now;
            data.TINNHANLIENHEs.InsertOnSubmit(tn);
            data.SubmitChanges();
            return RedirectToAction("Index", "GreenFood");
        }

    }
}