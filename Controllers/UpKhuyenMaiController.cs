using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;

namespace GreenFood.Controllers
{
    public class UpKhuyenMaiController : Controller
    {
        // GET: UpKhuyenMai
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        public List<CHUONGTRINHKHUYENMAI> List()
        {
            return db.CHUONGTRINHKHUYENMAIs.Where(a => a.Up == 1).ToList();
        }
        public ActionResult ChuongTrinhKhuyenMai()
        {
            var ct = List();
            return View(ct);
        }
        public List<CHITIETKHUYENMAI> ListTP()
        {
            return db.CHITIETKHUYENMAIs.Where(a => a.Up == 1 && a.CHUONGTRINHKHUYENMAI.MaKM == a.MaKM).ToList();
        }
        public ActionResult SanPhamKhuyenMaiPartial()
        {
            var ct = ListTP();
            
            return View(ct);
        }
    }
}