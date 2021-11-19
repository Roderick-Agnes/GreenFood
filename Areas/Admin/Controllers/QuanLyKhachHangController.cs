using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: Admin/QuanLyKhachHang
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        //View danh sách khách hàng lên màn hình
        public List<THANHVIEN> ListKhachHang()
        {
            return db.THANHVIENs.OrderByDescending(n => n.MaTV).ToList();
        }
        public ActionResult QuanLyKhachHang()
        {
            return View(ListKhachHang());
        }


        //Tạo mới khách hàng
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                THANHVIEN tv = new THANHVIEN();
                tv.HoTenTV = collection["HoTen"];
                tv.UserName = collection["UserName"];
                tv.Pw = collection["Pw"];
                tv.DiaChi = collection["DiaChi"];
                tv.Email = collection["Email"];
                tv.DienThoai = collection["DienThoai"];
                tv.GioiTinh = collection["GioiTinh"];
                tv.NgayDK = @DateTime.Now;
                db.THANHVIENs.InsertOnSubmit(tv);
                db.SubmitChanges();
                return RedirectToAction("QuanLyKhachHang", "QuanLyKhachHang");
            }
            return View();
        }

        //Sửa thông tin khách hàng
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tv = db.THANHVIENs.SingleOrDefault(n => n.MaTV == id);
            ViewBag.HoTen = tv.HoTenTV;
            ViewBag.UserName = tv.UserName;
            ViewBag.Pw = tv.Pw;
            ViewBag.DiaChi = tv.DiaChi;
            ViewBag.Email = tv.Email;
            ViewBag.DienThoai = tv.DienThoai;
            ViewBag.GioiTinh = tv.GioiTinh;
            ViewBag.NgayDK = tv.NgayDK;

            if (tv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tv);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f)
        {
            var tv = db.THANHVIENs.SingleOrDefault(n => n.MaTV == id);
            ViewBag.HoTen = tv.HoTenTV;
            ViewBag.UserName = tv.UserName;
            ViewBag.Pw = tv.Pw;
            ViewBag.DiaChi = tv.DiaChi;
            ViewBag.Email = tv.Email;
            ViewBag.DienThoai = tv.DienThoai;
            ViewBag.GioiTinh = tv.GioiTinh;
            ViewBag.NgayDK = tv.NgayDK;

            if (ModelState.IsValid)
            {
                tv.HoTenTV = f["HoTen"];
                tv.UserName = f["UserName"];
                tv.Pw = f["Pw"];
                tv.DiaChi = f["DiaChi"];
                tv.Email = f["Email"];
                tv.DienThoai = f["DienThoai"];
                tv.GioiTinh = f["GioiTinh"];
                tv.NgayDK = @DateTime.Now;
                db.SubmitChanges();
                return RedirectToAction("QuanLyKhachHang");
            }
            return View(tv);
        }

        //Xóa khách hàng
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tp = db.THANHVIENs.SingleOrDefault(n => n.MaTV == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection f)
        {
            var tp = db.THANHVIENs.SingleOrDefault(n => n.MaTV == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if(tp != null)
            {
                var kh = db.QUANLYDONHANGs.SingleOrDefault(n => n.MaKH == id);
                if (kh == null)
                {
                    db.THANHVIENs.DeleteOnSubmit(tp);
                    db.SubmitChanges();
                    return RedirectToAction("QuanLyKhachHang", "QuanLyKhachHang");
                }
                else if (kh != null)
                {
                    var ctdh = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == kh.MaDonHang);
                    if (ctdh == null)
                    {
                        db.QUANLYDONHANGs.DeleteOnSubmit(kh);
                        db.THANHVIENs.DeleteOnSubmit(tp);
                        db.SubmitChanges();
                        return RedirectToAction("QuanLyKhachHang", "QuanLyKhachHang");
                    }
                    else
                    {
                        db.CHITIETDONHANGs.DeleteOnSubmit(ctdh);
                        db.QUANLYDONHANGs.DeleteOnSubmit(kh);
                        db.THANHVIENs.DeleteOnSubmit(tp);
                        db.SubmitChanges();
                        return RedirectToAction("QuanLyKhachHang", "QuanLyKhachHang");
                    }
                }
            }
            return RedirectToAction("QuanLyKhachHang", "QuanLyKhachHang");
        }

        //Xem thông tin khách hàng
        public ActionResult Details(int id)
        {
            var tv = db.THANHVIENs.SingleOrDefault(n => n.MaTV == id);
            ViewBag.HoTen = tv.HoTenTV;
            ViewBag.UserName = tv.UserName;
            ViewBag.Pw = tv.Pw;
            ViewBag.DiaChi = tv.DiaChi;
            ViewBag.Email = tv.Email;
            ViewBag.DienThoai = tv.DienThoai;
            ViewBag.GioiTinh = tv.GioiTinh;
            ViewBag.NgayDK = tv.NgayDK;

            return View(tv);
        }
    }
}