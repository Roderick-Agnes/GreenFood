using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class NhapKhoController : Controller
    {
        // GET: Admin/NhapKho
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        //Thêm mới thực phẩm
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaLoaiThucPham = new SelectList(db.LOAITHUCPHAMs.ToList().OrderBy(n => n.TenLoaiThucPham), "MaLoaiThucPham", "TenLoaiThucPham");
            //ViewBag.MaLoaiThucPham = new SelectList(db.THUCPHAMs.ToList().OrderBy(n => n.TenThucPham), "MaLoaiThucPham", "TenLoaiThucPham");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection f, HttpPostedFileBase fFileUpload)
        {
            ViewBag.MaLoaiThucPham = new SelectList(db.LOAITHUCPHAMs.ToList().OrderBy(n => n.TenLoaiThucPham), "MaLoaiThucPham", "TenLoaiThucPham");
            if (fFileUpload == null)
            {
                ViewBag.ThongBao = "Hãy chọn ảnh bìa.";
                ViewBag.MaLoaiThucPham = new SelectList(db.LOAITHUCPHAMs.ToList().OrderBy(n => n.TenLoaiThucPham), "MaLoaiThucPham", "TenLoaiThucPham");
                ViewBag.TenThucPham = f["TenThucPham"];
                ViewBag.Gia = decimal.Parse(f["Gia"]);
                ViewBag.Mota = f["Mota"];
                ViewBag.TrongLuong = Convert.ToInt32(f["TrongLuong"]);
                ViewBag.HanSuDung = Convert.ToDateTime(f["HanSuDung"]);
                ViewBag.SoLuongBan = Convert.ToInt32(f["SoLuongBan"]);
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    THUCPHAM t = new THUCPHAM();
                    //t.MaThucPham = int.Parse(f["MaThucPham"]);
                    t.TenThucPham = f["TenThucPham"];
                    t.MaLoaiThucPham = int.Parse(f["MaLoaiThucPham"]);
                    t.UserName = "Thao";
                    t.NgayDang = DateTime.Now;
                    t.Duyet = 1;
                    t.CheckSale = 0;
                    t.TrungBinhDanhGia = 0;
                    t.GiamGia = 0;
                    db.THUCPHAMs.InsertOnSubmit(t);
                    db.SubmitChanges();

                    CHITIETTHUCPHAM tp = new CHITIETTHUCPHAM();
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/img"), sFileName);
                    try
                    {
                        if (!System.IO.File.Exists(path))
                        {
                            fFileUpload.SaveAs(path);
                        }
                        ViewBag.FileStatus = "File uploaded successfully.";
                    }
                    catch(Exception)
                    {
                        ViewBag.FileStatus = "Error while file uploading.";
                    }
                    tp.MaThucPham = t.MaThucPham;
                    tp.TenThucPham = f["TenThucPham"];
                    tp.MaLoaiThucPham = int.Parse(f["MaLoaiThucPham"]);
                    tp.Gia = decimal.Parse(f["Gia"]);
                    tp.Mota = f["Mota"].Replace("<p>", "").Replace("</p>", "\n");
                    tp.TrongLuong = int.Parse(f["TrongLuong"]);
                    tp.AnhBia = sFileName;
                    tp.HanSuDung = Convert.ToDateTime(f["HanSuDung"]);
                    tp.SoLuongBan = int.Parse(f["SoLuongBan"]);
                    tp.SoLuongDaBan = 0;
                    db.CHITIETTHUCPHAMs.InsertOnSubmit(tp);
                    db.SubmitChanges();
                    return RedirectToAction("QuanLyThucPham", "QuanLyChung");
                }
                return View();
            }
        }


        //Thêm loại thực phẩm
        [HttpGet]
        public ActionResult CreateLoaiThucPham()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateLoaiThucPham(FormCollection f)
        {
            if (ModelState.IsValid)
            {
                LOAITHUCPHAM t = new LOAITHUCPHAM();
                t.TenLoaiThucPham = f["sTenLoaiThucPham"];
                db.LOAITHUCPHAMs.InsertOnSubmit(t);
                db.SubmitChanges();
                return RedirectToAction("QuanLyThucPham", "QuanLyChung");
            }
            return View();
            
        }

        //Chỉnh sửa thông tin loại thực phẩm
        [HttpGet]
        public ActionResult ChinhSuaLoaiThucPham(int id)
        {
            var ltp = db.LOAITHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            ViewBag.TenLoaiTP = ltp.TenLoaiThucPham;
            if (ltp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ltp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaLoaiThucPham(int id, FormCollection f)
        {
            var tp = db.LOAITHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            ViewBag.TenLoaiTP = tp.TenLoaiThucPham;
            if (ModelState.IsValid)
            {
                tp.TenLoaiThucPham = f["sTenLoaiThucPham"];
                db.SubmitChanges();
                return RedirectToAction("QuanLyThucPham", "QuanLyChung", new { id = tp.MaLoaiThucPham});
            }
            return View(tp);
        }

        //Xóa loại thực phẩm
        [HttpGet]
        public ActionResult XoaLoaiThucPham(int id)
        {
            var tp = db.LOAITHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost, ActionName("XoaLoaiThucPham")]
        public ActionResult XoaLoaiThucPham(int id, FormCollection f)
        {
            //nếu tồn tịa sản phẩm ở bảng chi tiết khuyến mãi thì xóa
            var ltp = db.LOAITHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            var tp = db.THUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id); //BUG


            var ctkm =db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == tp.MaThucPham);
            if (ctkm != null)
            {
                db.CHITIETKHUYENMAIs.DeleteOnSubmit(ctkm);
                db.SubmitChanges();
            }
            var bl = db.BINHLUANs.SingleOrDefault(n => n.MaThucPham == tp.MaThucPham);
            if(bl != null)
            {
                db.BINHLUANs.DeleteOnSubmit(bl);
                db.SubmitChanges();
            }
            var ctdh = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaThucPham == tp.MaThucPham && n.MaLoaiThucPham == id);
            if(ctdh != null)
            {
                db.CHITIETDONHANGs.DeleteOnSubmit(ctdh);
                db.SubmitChanges();
            }
            var ct = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            if (ct != null)
            {
                db.CHITIETTHUCPHAMs.DeleteOnSubmit(ct);
                db.SubmitChanges();
            }

            db.THUCPHAMs.DeleteOnSubmit(tp);
            db.SubmitChanges();

            
            db.LOAITHUCPHAMs.DeleteOnSubmit(ltp);
            db.SubmitChanges();

            return RedirectToAction("QuanLyThucPham","QuanLyChung");
        }
    }
}