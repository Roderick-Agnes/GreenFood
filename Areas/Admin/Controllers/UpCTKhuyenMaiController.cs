using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Areas.Admin.Controllers
{
    public class UpCTKhuyenMaiController : Controller
    {
        // GET: Admin/UpCTKhuyenMai
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public ActionResult OnChuongTrinh(int id, int idCTKM)
        {
            var rs = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == idCTKM);
            rs.Up = id;
            db.SubmitChanges();
            return RedirectToAction("QuanLyKhuyenMai", "QuanLyChung");
        }
        public ActionResult OffChuongTrinh(int id, int idCTKM)
        {
            var rs = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == idCTKM);
            rs.Up = id;
            db.SubmitChanges();
            return RedirectToAction("QuanLyKhuyenMai", "QuanLyChung");
        }
    }
    
}