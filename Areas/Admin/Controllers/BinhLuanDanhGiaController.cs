using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class BinhLuanDanhGiaController : Controller
    {
        // GET: Admin/BinhluanDanhgia
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();


        public ActionResult BinhLuanDanhGia()
        {
            var rs = ListThucPham();
            return View(rs);
        }
        public List<CHITIETTHUCPHAM> ListThucPham()
        {
            return db.CHITIETTHUCPHAMs.ToList();
        }
        public ActionResult TatCaBinhLuan()
        {
            var rs = ListThucPham();
            return View(rs);
        }
        public ActionResult ThongTinBinhLuan(int id)
        {
            //var tt = db.BINHLUANs.SingleOrDefault(n => n.MaThucPham == id);
            var tp = ListBinhLuan(id);
            return View(tp);
        }
        public List<BINHLUAN> ListBinhLuan(int id)
        {
            var tb = db.BINHLUANs.Where(m => m.MaThucPham == id).OrderByDescending(n => n.MaBL).ToList();
            return tb;
        }
        public ActionResult BinhLuanSP(int id)
        {
            var tp = ListBinhLuan(id);
            return View(tp);
        }


        [HttpGet]
        public ActionResult XoaBinhLuan(int id)
        {
            var tp = db.BINHLUANs.SingleOrDefault(n => n.MaBL == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost]
        public ActionResult XoaBinhLuan(int id, FormCollection f)
        {
            var tp = db.BINHLUANs.SingleOrDefault(n => n.MaBL == id);
            db.BINHLUANs.DeleteOnSubmit(tp);
            db.SubmitChanges();
            return RedirectToAction("ThongTinBinhLuan", "BinhLuanDanhGia", new { id = tp.MaThucPham });
        }
    }
}