using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: Admin/QuanLyNhanVien
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public ActionResult QuanLyNhanVien()
        {
            var nv = db.NHANVIENs.ToList();
            return View(nv);
        }

        //Xóa nhân viên
        public ActionResult Delete(int id)
        {
            var nv = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
            db.NHANVIENs.DeleteOnSubmit(nv);
            db.SubmitChanges();
            return RedirectToAction("QuanLyNhanVien", "QuanLyNhanVien");
        }
        // Sửa thông tin nhân viên
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tp = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
            ViewBag.MaPQ = new SelectList(db.PHANQUYENs.ToList(), "MaPQ", "TenPQ");
            ViewBag.HotenNV = tp.HoTenNV;
            if (tp.MaPQ == 1)
            {
                ViewBag.ChucVu = "Admin";
            }
            else if (tp.MaPQ == 2)
            {
                ViewBag.ChucVu = "Nhân viên";
            }
            else if (tp.MaPQ == 3)
            {
                ViewBag.ChucVu = "Shipper";
            }
            ViewBag.DienThoai = tp.DienThoai;
            ViewBag.GioiTinh = tp.GioiTinh;
            ViewBag.DiaChi = tp.DiaChi;
            ViewBag.Email = tp.Email;
            ViewBag.TaiKhoan = tp.UserName;
            ViewBag.MatKhau = tp.Pw;
            if (tp.Facebook == "")
            {
                ViewBag.Facebook = "Chưa cập nhật";
            }
            else
            {
                ViewBag.Facebook = tp.Facebook;
            }
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f)
        {
            var tp = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
            ViewBag.MaPQ = new SelectList(db.PHANQUYENs.ToList(), "MaPQ", "TenPQ", tp.MaPQ);
            ViewBag.HotenNV = tp.HoTenNV;
            if(tp.MaPQ == 1)
            {
                ViewBag.ChucVu = "Admin";
            }
            else if(tp.MaPQ == 2)
            {
                ViewBag.ChucVu = "Nhân viên";
            }
            else if(tp.MaPQ == 3)
            {
                ViewBag.ChucVu = "Shipper";
            }
            ViewBag.DienThoai = tp.DienThoai;
            ViewBag.GioiTinh = tp.GioiTinh;
            ViewBag.DiaChi = tp.DiaChi;
            ViewBag.Email = tp.Email;
            ViewBag.TaiKhoan = tp.UserName;
            ViewBag.MatKhau = tp.Pw;
            ViewBag.Facebook = tp.Facebook;
            
            if (ModelState.IsValid)
            {
                tp.HoTenNV = f["sTenNhanVien"];
                tp.ChucVu = f["sChucVu"];
                tp.DienThoai = f["sDienThoai"];
                tp.GioiTinh = f["GioiTinh"];
                tp.DiaChi = f["sDiaChi"];
                tp.Email = f["sEmail"];
                tp.UserName = f["sTaiKhoan"];
                tp.Pw = f["sMatKhau"];
                tp.MaPQ = int.Parse(f["MaPQ"]);
                if (tp.Facebook == null)
                {
                    tp.Facebook = "Chưa cập nhật";
                }
                else
                {
                    tp.Facebook = f["sFacebook"];
                }
                db.SubmitChanges();
                return RedirectToAction("QuanLyNhanVien", "QuanLyNhanVien");
            }
            return View(tp);
        }

        //Xem thông tin nhân viên
        public ActionResult Details(int id)
        {
            var tp = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
            //ViewBag.MaPQ = new SelectList(db.PHANQUYENs.ToList(), "MaPQ", "TenPQ", tp.MaPQ);
            ViewBag.MaNV = tp.MaNV;
            ViewBag.HotenNV = tp.HoTenNV;
            if (tp.MaPQ == 1)
            {
                ViewBag.ChucVu = "Admin";
            }
            else if (tp.MaPQ == 2)
            {
                ViewBag.ChucVu = "Nhân viên";
            }
            else if (tp.MaPQ == 3)
            {
                ViewBag.ChucVu = "Shipper";
            }
            ViewBag.DienThoai = tp.DienThoai;
            ViewBag.GioiTinh = tp.GioiTinh;
            ViewBag.DiaChi = tp.DiaChi;
            ViewBag.Email = tp.Email;
            ViewBag.TaiKhoan = tp.UserName;
            ViewBag.MatKhau = tp.Pw;
            if(tp.Facebook == "" || tp.Facebook == null)
            {
                ViewBag.Facebook = "Chưa cập nhật";
            }
            else
            {
                ViewBag.Facebook = tp.Facebook;
            }
            return View(tp);
        }

        //Thêm nhân viên
        [HttpGet]
        public ActionResult Create()
        {
            NHANVIEN tp = new NHANVIEN();
            ViewBag.MaPQ = new SelectList(db.PHANQUYENs.ToList(), "MaPQ", "TenPQ");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection f)
        {
            if (ModelState.IsValid)
            {
                NHANVIEN tp = new NHANVIEN();
                ViewBag.MaPQ = new SelectList(db.PHANQUYENs.ToList(), "MaPQ", "MaPQ");
                tp.HoTenNV = f["sTenNhanVien"];
                tp.ChucVu = "";
                tp.DienThoai = f["sDienThoai"];
                tp.GioiTinh = f["GioiTinh"];
                tp.DiaChi = f["sDiaChi"];
                tp.Email = f["sEmail"];
                tp.UserName = f["sTaiKhoan"];
                tp.Pw = f["sMatKhau"];
                tp.MaPQ = int.Parse(f["MaPQ"]);
                db.NHANVIENs.InsertOnSubmit(tp);
                db.SubmitChanges();
                return RedirectToAction("QuanLyNhanVien", "QuanLyNhanVien");
            }
            return View();
        }
    }
}