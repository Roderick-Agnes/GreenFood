using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using PagedList.Mvc;
using PagedList;

namespace GreenFood.Controllers
{
    public class DanhGiaBinhLuanController : Controller
    {
        // GET: DanhGiaBinhLuan
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FormDanhGiaBinhLuan(int id)
        {
            ViewBag.MaSP = id;
            return View();
        }
        [HttpPost]
        public ActionResult FormDanhGiaBinhLuan(int id, FormCollection f)
        {
            string Email = f["Email"];
            string HoTen = f["HoTen"];
            string NoiDung = f["NoiDung"];
            int MaThucPham = id;
            int DanhGia = Convert.ToInt32(f["Rating"]);
            BINHLUAN bl = new BINHLUAN();
            bl.TenNguoiBL = HoTen;
            bl.NoiDungBL = NoiDung;
            bl.MaThucPham = MaThucPham;
            bl.NgayBL = @DateTime.Now;
            bl.Email = Email;
            bl.DanhGia = DanhGia;
            bl.Duyet = 1;
            db.BINHLUANs.InsertOnSubmit(bl);
            db.SubmitChanges();
            UpdateTrungBinhDanhGia(MaThucPham);
            return RedirectToAction("ChiTietThucPham", "GreenFood", new { id = MaThucPham });
        }
        private void UpdateTrungBinhDanhGia(int MaThucPham)
        {
            THUCPHAM sp = db.THUCPHAMs.Single(n => n.MaThucPham == MaThucPham);
            int SoLuongDanhGia = db.BINHLUANs.Count(n => n.MaThucPham == MaThucPham);
            int TongDanhGia = (int)(from bl in db.BINHLUANs where bl.MaThucPham == MaThucPham select bl).Sum(n => n.DanhGia);
            if (SoLuongDanhGia != 0)
                sp.TrungBinhDanhGia = (TongDanhGia * 10 / SoLuongDanhGia) / 10;
            else
                sp.TrungBinhDanhGia = 0;
            db.SubmitChanges();
        }

        //View bình luận trên trang chi tiết thực phẩm đó
        public ActionResult InfoBinhLuanDanhGia(int id, int ? page)
        {
            int number = 3, iPageNum = (page ?? 1);
            ViewBag.MaThucPham = id;
            //int iPageNum = (Page ?? 1);
            var list = (from bl in db.BINHLUANs where bl.MaThucPham == id select bl).OrderByDescending(n => n.MaBL).ToList();
            return PartialView(list.ToPagedList(iPageNum, number));
        }

        //Tổng hợp đánh giá của khách hàng
        public ActionResult TongHopDanhGia(int id)
        {
            ViewBag.SoLuongDanhGia = db.BINHLUANs.Count(n => n.MaThucPham == id);
            ViewBag.TongDanhGia = (from bl in db.BINHLUANs where bl.MaThucPham == id select bl).Sum(n => n.DanhGia);
            var DanhGia = from bl in db.BINHLUANs
                          where bl.MaThucPham == id
                          group bl by bl.DanhGia into dg
                          select new MiddleClass
                          {
                              SoSao = (int)dg.Key,
                              SoLuongDanhGia = dg.Count()
                          };
            return View(DanhGia);
        }
    }
}