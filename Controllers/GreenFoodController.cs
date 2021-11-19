using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using PagedList;
using PagedList.Mvc;
namespace GreenFood.Controllers
{
    public class GreenFoodController : Controller
    {
        dbGreenFoodDataContext data = new dbGreenFoodDataContext();
        // GET: GreenFood
        //Tinh tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        public List<CHITIETTHUCPHAM> ListSPTraiCay(int count)
        {
            return data.CHITIETTHUCPHAMs.Where(a => a.THUCPHAM.MaLoaiThucPham == 2).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var listTc = ListSPTraiCay(4);
            ViewBag.TongSoLuong = TongSoLuong();
            return View(listTc);
        }
        public ActionResult ChiTietThucPham()
        {
            return View();
        }
        public ActionResult ChiTietPartial (int id)
        {
            ViewBag.SoLuongDanhGia = data.BINHLUANs.Count(n => n.MaThucPham == id);
            ViewBag.TongDanhGia = (from bl in data.BINHLUANs where bl.MaThucPham == id select bl).Sum(n => n.DanhGia);
            var tp = from s in data.CHITIETTHUCPHAMs
                     where s.MaThucPham == id
                     select s;
            return View(tp.Single());
        }

        public List<CHITIETTHUCPHAM> ListSPRCQ(int count)
        {
            return data.CHITIETTHUCPHAMs.Where(a => a.THUCPHAM.MaLoaiThucPham == 3).Take(count).ToList();
        }
        public ActionResult SessionRCQ_Partial()
        {
            var list = ListSPRCQ(4);
            return View(list);
        }

        public List<CHITIETTHUCPHAM> ListSPTPT(int count)
        {
            return data.CHITIETTHUCPHAMs.Where(a => a.THUCPHAM.MaLoaiThucPham == 1).Take(count).ToList();
        }
        public ActionResult SessionTPT_Partial()
        {
            var list = ListSPTPT(4);
            return View(list);
        }

        public List<CHITIETTHUCPHAM> ListGrid(int count)
        {

            return data.CHITIETTHUCPHAMs.OrderByDescending(a => a.THUCPHAM.NgayDang).Take(count).ToList();
        }
        public ActionResult SanPhamGrid(int ? page)
        {
            int iSize = 9;
            int iPageNum = (page ?? 1);
            var list = from s in data.CHITIETTHUCPHAMs.OrderByDescending(s => s.THUCPHAM.NgayDang) select s;
            return View(list.ToPagedList(iPageNum, iSize));
        }
        public ActionResult DanhMucPartial()
        {
            var list = from s in data.LOAITHUCPHAMs select s;
            return View(list);
        }
        public ActionResult DanhMuc(int iMaLoaiTP, int ? page)
        {
            ViewBag.MaLoaiTP = iMaLoaiTP;
            int iSize = 9;
            int iPageNum = (page ?? 1);
            var list = from s in data.CHITIETTHUCPHAMs where s.MaLoaiThucPham == iMaLoaiTP select s;
            return View(list.ToPagedList(iPageNum, iSize));
        }
        public List<CHITIETTHUCPHAM> ListNew(int count)
        {
            return data.CHITIETTHUCPHAMs.OrderByDescending(a => a.THUCPHAM.NgayDang).Take(count).ToList();
        }
        public ActionResult SanPhamMoiNhat()
        {
            var list = ListNew(6);
            return View(list);
        }
        public ActionResult LayoutPartial1()
        {
            return View();
        }


        public ActionResult GioHangSL()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return View();
        }
    }
}