using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using PagedList;

namespace GreenFood.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int ? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<CHITIETTHUCPHAM> lstKQTK = db.CHITIETTHUCPHAMs.Where(n => n.TenThucPham.Contains(sTuKhoa) || n.Mota.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult TimKiemPartial()
        {
            return View();
        }
    }
}