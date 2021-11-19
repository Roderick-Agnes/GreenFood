using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using Rotativa;

namespace GreenFood.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: Admin/QuanLyDonHang
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        //Hiển thị danh sách đơn hàng
        public List<QUANLYDONHANG> ListDonHang()
        {
            return db.QUANLYDONHANGs.ToList();
        }
        public ActionResult QuanLyDonHang()
        {
            return View(ListDonHang());
        }

        //Thêm mới đơn hàng
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaTV = new SelectList(db.THANHVIENs.ToList(), "MaTV", "HoTenTV");
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs.ToList(), "MaThucPham", "TenThucPham");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection f)
        {
            ViewBag.MaTV = new SelectList(db.THANHVIENs.ToList(), "MaTV", "HoTenTV");
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs.ToList(), "MaThucPham", "TenThucPham");
            if (ModelState.IsValid)
            {
                QUANLYDONHANG dh = new QUANLYDONHANG();
                var tv = db.THANHVIENs.SingleOrDefault(n => n.MaTV.Equals(f["MaTV"]) == true);
                dh.MaKH = tv.MaTV;
                dh.NgayDat = DateTime.Now;
                dh.NgayGiao = Convert.ToDateTime(f["NgayGiao"]);
                dh.GhiChu = f["GhiChu"];
                db.QUANLYDONHANGs.InsertOnSubmit(dh);
                db.SubmitChanges();
                CHITIETDONHANG ct = new CHITIETDONHANG();
                ct.MaDonHang = dh.MaDonHang;
                ct.MaThucPham = int.Parse(f["MaThucPham"]);
                var tp = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == int.Parse(f["MaThucPham"]));
                ct.MaLoaiThucPham = int.Parse(tp.MaLoaiThucPham.ToString());
                ct.TrongLuong = int.Parse(f["TrongLuong"]);
                //Tinh tổng tiền
                var sp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == int.Parse(f["MaThucPham"]));
                ct.TongTien = int.Parse(f["TrongLuong"]) * Convert.ToDecimal(sp.Gia) / Convert.ToInt32(sp.TrongLuong);
                ct.NgayThanhToan = DateTime.Now;
                ct.ThanhToan = 1;
                db.CHITIETDONHANGs.InsertOnSubmit(ct);
                db.SubmitChanges();
                return RedirectToAction("QuanLyDonHang", "QuanLyDonHang");
            }
            return View();
        }

        //Sửa thông tin đơn hàng
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dh = db.QUANLYDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            var ctdh = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            ViewBag.MaTV = new SelectList(db.THANHVIENs, "MaTV", "HoTenTV", dh.MaKH);
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs, "MaThucPham", "TenThucPham", ctdh.MaThucPham);
            ViewBag.TenThucPham = ctdh.THUCPHAM.TenThucPham;
            ViewBag.NgayGiao = dh.NgayGiao;
            ViewBag.GhiChu = dh.GhiChu;
            
            ViewBag.TrongLuong = ctdh.TrongLuong;
            ViewBag.NgayThanhToan = ctdh.NgayThanhToan;
            ViewBag.ThanhToan = ctdh.ThanhToan;
            return View(dh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f)
        {
            var dh = db.QUANLYDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            var ctdh = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            ViewBag.MaTV = new SelectList(db.THANHVIENs, "MaTV", "HoTenTV", dh.MaKH);
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs, "MaThucPham", "TenThucPham", ctdh.MaThucPham);
            ViewBag.TenThucPham = ctdh.THUCPHAM.TenThucPham;
            ViewBag.NgayGiao = dh.NgayGiao;
            ViewBag.GhiChu = dh.GhiChu;
            ViewBag.TrongLuong = ctdh.TrongLuong;
            ViewBag.NgayThanhToan = ctdh.NgayThanhToan;
            ViewBag.ThanhToan = ctdh.ThanhToan;
            if (ModelState.IsValid)
            {
                var tv = db.THANHVIENs.SingleOrDefault(n => n.MaTV.Equals(f["MaTV"]) == true);
                dh.MaKH = tv.MaTV;
                dh.NgayGiao = Convert.ToDateTime(f["NgayGiao"]);
                dh.GhiChu = f["GhiChu"];
                db.SubmitChanges();
                var ct = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
                //ct.MaThucPham = int.Parse(f["MaThucPham"]);
                var tp = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == ct.MaThucPham); //int.Parse(f["MaThucPham"])
                ct.MaLoaiThucPham = int.Parse(tp.MaLoaiThucPham.ToString());
                ct.TrongLuong = int.Parse(f["TrongLuong"]);
                //Tinh tổng tiền
                var sp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == ct.MaThucPham);
                ct.TongTien = int.Parse(f["TrongLuong"]) * Convert.ToDecimal(sp.Gia) / Convert.ToInt32(sp.TrongLuong);
                db.SubmitChanges();
                return RedirectToAction("QuanLyDonHang", "QuanLyDonHang");
            }
            return View(dh);
        }

        //Xóa đơn hàng
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tp = db.QUANLYDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
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
            var tp = db.QUANLYDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            var ct = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CHITIETDONHANGs.DeleteOnSubmit(ct);
            db.SubmitChanges();
            db.QUANLYDONHANGs.DeleteOnSubmit(tp);
            db.SubmitChanges();

            return RedirectToAction("QuanLyDonHang", "QuanLyDonHang");
        }

        //Xem thông tin đơn hàng
        public ActionResult Details(int id)
        {
            var tv = db.CHITIETDONHANGs.SingleOrDefault(n => n.MaDonHang == id);
            ViewBag.MaDonHang = tv.MaDonHang;
            var t = db.THANHVIENs.SingleOrDefault(n => n.MaTV == tv.QUANLYDONHANG.MaKH);
            ViewBag.TenKH = t.HoTenTV;
            ViewBag.TenLoai = tv.LOAITHUCPHAM.TenLoaiThucPham;
            var s = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == tv.MaThucPham);
            ViewBag.TenThucPham = s.TenThucPham;
            if (tv.MaLoaiThucPham == 1 || tv.MaLoaiThucPham == 4)
            {
                ViewBag.TrongLuong = tv.TrongLuong + "Kg";
            }
            else if (tv.MaLoaiThucPham == 2 || tv.MaLoaiThucPham == 3)
            {
                ViewBag.TrongLuong = tv.TrongLuong + "g";
            }
            else if (tv.MaLoaiThucPham == 5)
            {
                ViewBag.TrongLuong = tv.TrongLuong + " lít";
            }
            else
            {
                ViewBag.TrongLuong = "Hộp " + tv.TrongLuong + " trứng";
            }
            
            ViewBag.NgayThanhToan = tv.NgayThanhToan;
            if(tv.ThanhToan == 1)
            {
                ViewBag.ThanhToan = "Đã thanh toán";
            }
            else
            {
                ViewBag.ThanhToan = "Chưa thanh toán";
            }
            

            return View(tv);
        }

        //In hoá đơn cho đơn hàng
        public ActionResult ExportToWord(int id)
        {
            HoaDonViewModel data = (from hd in db.CHITIETDONHANGs
                                    join tv in db.THANHVIENs
                                    on hd.QUANLYDONHANG.MaKH equals tv.MaTV
                                    //join nv in db.NHANVIENs
                                    //on hd.MaNV equals nv.MaNV
                                    join tp in db.THUCPHAMs
                                    on hd.MaThucPham equals tp.MaThucPham
                                    join loai in db.LOAITHUCPHAMs
                                    on tp.MaLoaiThucPham equals loai.MaLoaiThucPham
                                    where hd.MaDonHang == id
                                    select new HoaDonViewModel()
                                    {
                                        MaHD = hd.MaDonHang,
                                        HoTenTV = tv.HoTenTV,
                                        //HoTenNV = nv.HoTenNV,
                                        TenThucPham = tp.TenThucPham,
                                        TongTien = hd.TongTien,
                                        DiaChi = tv.DiaChi,
                                        Email = tv.Email,
                                        TenLoaiThucPham = loai.TenLoaiThucPham,
                                        NgayThanhToan = hd.NgayThanhToan
                                    }).SingleOrDefault();
            Session["id"] = data.MaHD;
            return View(data);
        }
        public ActionResult ExportPDF()
        {

            return new ActionAsPdf("ExportToWord", new { @id = Session["id"].ToString() })
            {
                FileName = Server.MapPath("~/Admin/Content/HoaDon.pdf")
            };
        }
    }
}