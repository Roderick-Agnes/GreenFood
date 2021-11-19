using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public ActionResult Index()
        {
            //Chức năng thống kê

            // Thống kê tháng 1
            var a = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienThittuoi = a.ToList();
            decimal sumThitTuoi = (decimal)tienThittuoi.Sum();
            ViewBag.ThitTuoi = sumThitTuoi;

            var b = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienTraicay = b.ToList();
            decimal sumTraicay = (decimal)tienTraicay.Sum();
            ViewBag.Traicay = sumTraicay;

            var c = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienRaucu = c.ToList();
            decimal sumRaucu = (decimal)tienRaucu.Sum();
            ViewBag.Raucu = sumRaucu;

            var d = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienHaisantuoi = d.ToList();
            decimal sumHaisantuoi = (decimal)tienHaisantuoi.Sum();
            ViewBag.Haisantuoi = sumHaisantuoi;

            var e = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienDauanthucvat = e.ToList();
            decimal sumDauanthucvat = (decimal)tienDauanthucvat.Sum();
            ViewBag.Dauanthucvat = sumDauanthucvat;

            var f = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 1).ToList() select s.TongTien;
            var tienSanphamtutrung = f.ToList();
            decimal sumSanphamtutrung = (decimal)tienSanphamtutrung.Sum();
            ViewBag.Cacloaisanphamtutrung = sumSanphamtutrung;

            // Thống kê tháng 2
            var a2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienThittuoi2 = a2.ToList();
            decimal sumThitTuoi2 = (decimal)tienThittuoi2.Sum();
            ViewBag.ThitTuoi2 = sumThitTuoi2;

            var b2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienTraicay2 = b2.ToList();
            decimal sumTraicay2 = (decimal)tienTraicay2.Sum();
            ViewBag.Traicay2 = sumTraicay2;

            var c2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienRaucu2 = c2.ToList();
            decimal sumRaucu2 = (decimal)tienRaucu2.Sum();
            ViewBag.Raucu2 = sumRaucu2;

            var d2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienHaisantuoi2 = d2.ToList();
            decimal sumHaisantuoi2 = (decimal)tienHaisantuoi2.Sum();
            ViewBag.Haisantuoi2 = sumHaisantuoi2;

            var e2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienDauanthucvat2 = e2.ToList();
            decimal sumDauanthucvat2 = (decimal)tienDauanthucvat2.Sum();
            ViewBag.Dauanthucvat2 = sumDauanthucvat2;

            var f2 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 2).ToList() select s.TongTien;
            var tienSanphamtutrung2 = f2.ToList();
            decimal sumSanphamtutrung2 = (decimal)tienSanphamtutrung2.Sum();
            ViewBag.Cacloaisanphamtutrung2 = sumSanphamtutrung2;

            // Thống kê tháng 3
            var a3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienThittuoi3 = a3.ToList();
            decimal sumThitTuoi3 = (decimal)tienThittuoi3.Sum();
            ViewBag.ThitTuoi3 = sumThitTuoi3;

            var b3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienTraicay3 = b3.ToList();
            decimal sumTraicay3 = (decimal)tienTraicay3.Sum();
            ViewBag.Traicay3 = sumTraicay3;

            var c3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienRaucu3 = c3.ToList();
            decimal sumRaucu3 = (decimal)tienRaucu3.Sum();
            ViewBag.Raucu3 = sumRaucu3;

            var d3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienHaisantuoi3 = d3.ToList();
            decimal sumHaisantuoi3 = (decimal)tienHaisantuoi3.Sum();
            ViewBag.Haisantuoi3 = sumHaisantuoi3;

            var e3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienDauanthucvat3 = e3.ToList();
            decimal sumDauanthucvat3 = (decimal)tienDauanthucvat3.Sum();
            ViewBag.Dauanthucvat3 = sumDauanthucvat3;

            var f3 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 3).ToList() select s.TongTien;
            var tienSanphamtutrung3 = f3.ToList();
            decimal sumSanphamtutrung3 = (decimal)tienSanphamtutrung3.Sum();
            ViewBag.Cacloaisanphamtutrung3 = sumSanphamtutrung3;

            // Thống kê tháng 4
            var a4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienThittuoi4 = a4.ToList();
            decimal sumThitTuoi4 = (decimal)tienThittuoi4.Sum();
            ViewBag.ThitTuoi4 = sumThitTuoi4;

            var b4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienTraicay4 = b4.ToList();
            decimal sumTraicay4 = (decimal)tienTraicay4.Sum();
            ViewBag.Traicay4 = sumTraicay4;

            var c4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienRaucu4 = c4.ToList();
            decimal sumRaucu4 = (decimal)tienRaucu4.Sum();
            ViewBag.Raucu4 = sumRaucu4;

            var d4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienHaisantuoi4 = d4.ToList();
            decimal sumHaisantuoi4 = (decimal)tienHaisantuoi4.Sum();
            ViewBag.Haisantuoi4 = sumHaisantuoi4;

            var e4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienDauanthucvat4 = e4.ToList();
            decimal sumDauanthucvat4 = (decimal)tienDauanthucvat4.Sum();
            ViewBag.Dauanthucvat4 = sumDauanthucvat4;

            var f4 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 4).ToList() select s.TongTien;
            var tienSanphamtutrung4 = f4.ToList();
            decimal sumSanphamtutrung4 = (decimal)tienSanphamtutrung4.Sum();
            ViewBag.Cacloaisanphamtutrung4 = sumSanphamtutrung4;

            // Thống kê tháng 5
            var a5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienThittuoi5 = a5.ToList();
            decimal sumThitTuoi5 = (decimal)tienThittuoi5.Sum();
            ViewBag.ThitTuoi5 = sumThitTuoi5;

            var b5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienTraicay5 = b5.ToList();
            decimal sumTraicay5 = (decimal)tienTraicay5.Sum();
            ViewBag.Traicay5 = sumTraicay5;

            var c5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienRaucu5 = c5.ToList();
            decimal sumRaucu5 = (decimal)tienRaucu5.Sum();
            ViewBag.Raucu5 = sumRaucu5;

            var d5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienHaisantuoi5 = d5.ToList();
            decimal sumHaisantuoi5 = (decimal)tienHaisantuoi5.Sum();
            ViewBag.Haisantuoi5 = sumHaisantuoi5;

            var e5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienDauanthucvat5 = e5.ToList();
            decimal sumDauanthucvat5 = (decimal)tienDauanthucvat5.Sum();
            ViewBag.Dauanthucvat5 = sumDauanthucvat5;

            var f5 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 5).ToList() select s.TongTien;
            var tienSanphamtutrung5 = f5.ToList();
            decimal sumSanphamtutrung5 = (decimal)tienSanphamtutrung5.Sum();
            ViewBag.Cacloaisanphamtutrung5 = sumSanphamtutrung5;

            // Thống kê tháng 6
            var a6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienThittuoi6 = a6.ToList();
            decimal sumThitTuoi6 = (decimal)tienThittuoi6.Sum();
            ViewBag.ThitTuoi6 = sumThitTuoi6;

            var b6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienTraicay6 = b6.ToList();
            decimal sumTraicay6 = (decimal)tienTraicay6.Sum();
            ViewBag.Traicay6 = sumTraicay6;

            var c6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienRaucu6 = c6.ToList();
            decimal sumRaucu6 = (decimal)tienRaucu6.Sum();
            ViewBag.Raucu6 = sumRaucu6;

            var d6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienHaisantuoi6 = d6.ToList();
            decimal sumHaisantuoi6 = (decimal)tienHaisantuoi6.Sum();
            ViewBag.Haisantuoi6 = sumHaisantuoi6;

            var e6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienDauanthucvat6 = e6.ToList();
            decimal sumDauanthucvat6 = (decimal)tienDauanthucvat6.Sum();
            ViewBag.Dauanthucvat6 = sumDauanthucvat6;

            var f6 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 6).ToList() select s.TongTien;
            var tienSanphamtutrung6 = f6.ToList();
            decimal sumSanphamtutrung6 = (decimal)tienSanphamtutrung6.Sum();
            ViewBag.Cacloaisanphamtutrung6 = sumSanphamtutrung6;

            // Thống kê tháng 7
            var a7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienThittuoi7 = a7.ToList();
            decimal sumThitTuoi7 = (decimal)tienThittuoi7.Sum();
            ViewBag.ThitTuoi7 = sumThitTuoi7;

            var b7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienTraicay7 = b7.ToList();
            decimal sumTraicay7 = (decimal)tienTraicay7.Sum();
            ViewBag.Traicay7 = sumTraicay7;

            var c7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienRaucu7 = c7.ToList();
            decimal sumRaucu7 = (decimal)tienRaucu7.Sum();
            ViewBag.Raucu7 = sumRaucu7;

            var d7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienHaisantuoi7 = d7.ToList();
            decimal sumHaisantuoi7 = (decimal)tienHaisantuoi7.Sum();
            ViewBag.Haisantuoi7 = sumHaisantuoi7;

            var e7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienDauanthucvat7 = e7.ToList();
            decimal sumDauanthucvat7 = (decimal)tienDauanthucvat7.Sum();
            ViewBag.Dauanthucvat7 = sumDauanthucvat7;

            var f7 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 7).ToList() select s.TongTien;
            var tienSanphamtutrung7 = f7.ToList();
            decimal sumSanphamtutrung7 = (decimal)tienSanphamtutrung7.Sum();
            ViewBag.Cacloaisanphamtutrung7 = sumSanphamtutrung7;

            // Thống kê tháng 8
            var a8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienThittuoi8 = a8.ToList();
            decimal sumThitTuoi8 = (decimal)tienThittuoi8.Sum();
            ViewBag.ThitTuoi8 = sumThitTuoi8;

            var b8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienTraicay8 = b8.ToList();
            decimal sumTraicay8 = (decimal)tienTraicay8.Sum();
            ViewBag.Traicay8 = sumTraicay8;

            var c8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienRaucu8 = c8.ToList();
            decimal sumRaucu8 = (decimal)tienRaucu8.Sum();
            ViewBag.Raucu8 = sumRaucu8;

            var d8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienHaisantuoi8 = d8.ToList();
            decimal sumHaisantuoi8 = (decimal)tienHaisantuoi8.Sum();
            ViewBag.Haisantuoi8 = sumHaisantuoi8;

            var e8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienDauanthucvat8 = e8.ToList();
            decimal sumDauanthucvat8 = (decimal)tienDauanthucvat8.Sum();
            ViewBag.Dauanthucvat8 = sumDauanthucvat8;

            var f8 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 8).ToList() select s.TongTien;
            var tienSanphamtutrung8 = f8.ToList();
            decimal sumSanphamtutrung8 = (decimal)tienSanphamtutrung8.Sum();
            ViewBag.Cacloaisanphamtutrung8 = sumSanphamtutrung8;

            // Thống kê tháng 9
            var a9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienThittuoi9 = a9.ToList();
            decimal sumThitTuoi9 = (decimal)tienThittuoi9.Sum();
            ViewBag.ThitTuoi9 = sumThitTuoi9;

            var b9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienTraicay9 = b9.ToList();
            decimal sumTraicay9 = (decimal)tienTraicay9.Sum();
            ViewBag.Traicay9 = sumTraicay9;

            var c9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienRaucu9 = c9.ToList();
            decimal sumRaucu9 = (decimal)tienRaucu9.Sum();
            ViewBag.Raucu9 = sumRaucu9;

            var d9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienHaisantuoi9 = d9.ToList();
            decimal sumHaisantuoi9 = (decimal)tienHaisantuoi9.Sum();
            ViewBag.Haisantuoi9 = sumHaisantuoi9;

            var e9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienDauanthucvat9 = e9.ToList();
            decimal sumDauanthucvat9 = (decimal)tienDauanthucvat9.Sum();
            ViewBag.Dauanthucvat9 = sumDauanthucvat9;

            var f9 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 9).ToList() select s.TongTien;
            var tienSanphamtutrung9 = f9.ToList();
            decimal sumSanphamtutrung9 = (decimal)tienSanphamtutrung9.Sum();
            ViewBag.Cacloaisanphamtutrung9 = sumSanphamtutrung9;

            // Thống kê tháng 10
            var a10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienThittuoi10 = a10.ToList();
            decimal sumThitTuoi10 = (decimal)tienThittuoi10.Sum();
            ViewBag.ThitTuoi10 = sumThitTuoi10;

            var b10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienTraicay10 = b10.ToList();
            decimal sumTraicay10 = (decimal)tienTraicay10.Sum();
            ViewBag.Traicay10 = sumTraicay10;

            var c10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienRaucu10 = c10.ToList();
            decimal sumRaucu10 = (decimal)tienRaucu10.Sum();
            ViewBag.Raucu10 = sumRaucu10;

            var d10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienHaisantuoi10 = d10.ToList();
            decimal sumHaisantuoi10 = (decimal)tienHaisantuoi10.Sum();
            ViewBag.Haisantuoi10 = sumHaisantuoi10;

            var e10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienDauanthucvat10 = e10.ToList();
            decimal sumDauanthucvat10 = (decimal)tienDauanthucvat10.Sum();
            ViewBag.Dauanthucvat10 = sumDauanthucvat10;

            var f10 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 10).ToList() select s.TongTien;
            var tienSanphamtutrung10 = f10.ToList();
            decimal sumSanphamtutrung10 = (decimal)tienSanphamtutrung10.Sum();
            ViewBag.Cacloaisanphamtutrung10 = sumSanphamtutrung10;

            // Thống kê tháng 11
            var a11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienThittuoi11 = a11.ToList();
            decimal sumThitTuoi11 = (decimal)tienThittuoi11.Sum();
            ViewBag.ThitTuoi11 = sumThitTuoi11;

            var b11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienTraicay11 = b11.ToList();
            decimal sumTraicay11 = (decimal)tienTraicay11.Sum();
            ViewBag.Traicay11 = sumTraicay11;

            var c11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienRaucu11 = c11.ToList();
            decimal sumRaucu11 = (decimal)tienRaucu11.Sum();
            ViewBag.Raucu11 = sumRaucu11;

            var d11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienHaisantuoi11 = d11.ToList();
            decimal sumHaisantuoi11 = (decimal)tienHaisantuoi11.Sum();
            ViewBag.Haisantuoi11 = sumHaisantuoi11;

            var e11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienDauanthucvat11 = e11.ToList();
            decimal sumDauanthucvat11 = (decimal)tienDauanthucvat11.Sum();
            ViewBag.Dauanthucvat11 = sumDauanthucvat11;

            var f11 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 11).ToList() select s.TongTien;
            var tienSanphamtutrung11 = f11.ToList();
            decimal sumSanphamtutrung11 = (decimal)tienSanphamtutrung11.Sum();
            ViewBag.Cacloaisanphamtutrung11 = sumSanphamtutrung11;

            // Thống kê tháng 12
            var a12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienThittuoi12 = a12.ToList();
            decimal sumThitTuoi12 = (decimal)tienThittuoi12.Sum();
            ViewBag.ThitTuoi12 = sumThitTuoi12;

            var b12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienTraicay12 = b12.ToList();
            decimal sumTraicay12 = (decimal)tienTraicay12.Sum();
            ViewBag.Traicay12 = sumTraicay12;

            var c12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienRaucu12 = c12.ToList();
            decimal sumRaucu12 = (decimal)tienRaucu12.Sum();
            ViewBag.Raucu12 = sumRaucu12;

            var d12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienHaisantuoi12 = d12.ToList();
            decimal sumHaisantuoi12 = (decimal)tienHaisantuoi12.Sum();
            ViewBag.Haisantuoi12 = sumHaisantuoi12;

            var e12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienDauanthucvat12 = e12.ToList();
            decimal sumDauanthucvat12 = (decimal)tienDauanthucvat12.Sum();
            ViewBag.Dauanthucvat12 = sumDauanthucvat12;

            var f12 = from s in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6 && n.NgayThanhToan.Value.Month == 12).ToList() select s.TongTien;
            var tienSanphamtutrung12 = f12.ToList();
            decimal sumSanphamtutrung12 = (decimal)tienSanphamtutrung12.Sum();
            ViewBag.Cacloaisanphamtutrung12 = sumSanphamtutrung12;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Thống kê % bán được
            var tong = from t in db.CHITIETDONHANGs.Select(s => s.TongTien) select t;
            var tongTien = tong.Sum();
            ViewBag.Tongs = tongTien;


            var per_Thittuoi = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1).Select(s => s.TongTien) select t;
            var tongThittuoi = per_Thittuoi.Sum();
            ViewBag.Thittuois = tongThittuoi;

            var per_Traicay = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2).Select(s => s.TongTien) select t;
            var tongTraicay = per_Traicay.Sum();
            ViewBag.Traicays = tongTraicay;

            var per_Raucu = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3).Select(s => s.TongTien) select t;
            var tongRaucu = per_Raucu.Sum();
            ViewBag.Raucus = tongRaucu;

            var per_Haisantuoi = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4).Select(s => s.TongTien) select t;
            var tongHaisantuoi = per_Haisantuoi.Sum();
            ViewBag.Haisantuois = tongHaisantuoi;

            var per_DauTV = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5).Select(s => s.TongTien) select t;
            var tongDauTV = per_DauTV.Sum();
            ViewBag.DauanTVs = tongDauTV;

            var per_SanPhamTuTrung = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6).Select(s => s.TongTien) select t;
            var tongSPTuTrung = per_SanPhamTuTrung.Sum();
            ViewBag.SanPhamTuTrungs = tongSPTuTrung;


            ////Ten loai tp
            var rs = ListLoai();
            return View(rs);
        }
        public List<LOAITHUCPHAM> ListLoai()
        {
            return db.LOAITHUCPHAMs.ToList();
        }
        public ActionResult PieChart()
        {
            //Thống kê % bán được
            var tong = from t in db.CHITIETDONHANGs.Select(s => s.TongTien) select t;
                var tongTien = tong.Sum();
                ViewBag.Tong = tongTien.ToString();
            
            
            var per_Thittuoi = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 1).Select(s => s.TongTien) select t;
                var tongThittuoi = per_Thittuoi.Sum();
                ViewBag.Thittuoi = tongThittuoi.ToString();
            
            var per_Traicay = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 2).Select(s => s.TongTien) select t;
                var tongTraicay = per_Traicay.Sum();
                ViewBag.Traicay = tongTraicay.ToString();
            
            var per_Raucu = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 3).Select(s => s.TongTien) select t;
                var tongRaucu = per_Raucu.Sum();
                ViewBag.Raucu = tongRaucu.ToString();

            var per_Haisantuoi = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 4).Select(s => s.TongTien) select t;
                var tongHaisantuoi = per_Haisantuoi.Sum();
                ViewBag.Haisantuoi = tongHaisantuoi.ToString();
            
            var per_DauTV = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 5).Select(s => s.TongTien) select t;
                var tongDauTV = per_DauTV.Sum();
                ViewBag.DauanTV = tongDauTV.ToString();
            
            var per_SanPhamTuTrung = from t in db.CHITIETDONHANGs.Where(n => n.MaLoaiThucPham == 6).Select(s => s.TongTien) select t;
                var tongSPTuTrung = per_SanPhamTuTrung.Sum();
                ViewBag.SanPhamTuTrung = tongSPTuTrung.ToString();
            
            return View();
        }
    }
}