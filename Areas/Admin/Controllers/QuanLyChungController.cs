using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GreenFood.Models;


namespace GreenFood.Areas.Admin.Controllers
{
    public class QuanLyChungController : Controller
    {
        // GET: Admin/QuanLyThucPham
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();

        //Quản lý thực phẩm
        public List<LOAITHUCPHAM> ListLoai()
        {
            return db.LOAITHUCPHAMs.ToList();
        }
        public ActionResult QuanLyThucPham()
        {
            var rs = ListLoai();
            return View(rs);
        }
        public List<CHITIETTHUCPHAM> ListThucPham()
        {
            return db.CHITIETTHUCPHAMs.ToList();
        }
        public ActionResult TatCaThucPham()
        {
            var rs = ListThucPham();
            return View(rs);
        }
        [HttpGet]
        public ActionResult EditThucPham(int id)
        {
            var tp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLoaiThucPham = new SelectList(db.LOAITHUCPHAMs.ToList().OrderBy(n => n.TenLoaiThucPham), "MaLoaiThucPham", "TenLoaiThucPham", tp.MaLoaiThucPham);
            return View(tp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditThucPham(FormCollection f, HttpPostedFileBase fFileUpload)
        {
            var tp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == int.Parse(f["iMaThucPham"]));
            ViewBag.MaLoaiThucPham = new SelectList(db.LOAITHUCPHAMs.ToList().OrderBy(n => n.TenLoaiThucPham), "MaLoaiThucPham", "TenLoaiThucPham", tp.MaLoaiThucPham);
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    var sFileName = System.IO.Path.GetFileName(fFileUpload.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Images/img"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);

                    }
                    tp.AnhBia = sFileName;
                }
                tp.TenThucPham = f["sTenThucPham"];
                tp.Gia = decimal.Parse(f["mGia"]);
                tp.Mota = f["sMoTa"].Replace("<p>", "").Replace("</p>", "\n");
                tp.TrongLuong = int.Parse(f["iTrongLuong"]);
                tp.HanSuDung = Convert.ToDateTime(f["dHanSuDung"]);
                tp.SoLuongBan = int.Parse(f["iSoLuongBan"]);
                tp.SoLuongDaBan = int.Parse(f["iSoLuongDaBan"]);
                tp.MaLoaiThucPham = int.Parse(f["MaLoaiThucPham"]);
                db.SubmitChanges();
                return RedirectToAction("QuanLyThucPham");
            }
            return View(tp);
        }
        [HttpGet]
        public ActionResult DeleteThucPham(int id)
        {
            var tp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
            if(tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost, ActionName("DeleteThucPham")]
        public ActionResult DeleteThucPham(int id, FormCollection f)
        {
            //nếu tồn tịa sản phẩm ở bảng chi tiết khuyến mãi thì xóa
            var t = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
            if (t.CheckSale == 0)
            {
                // xoá sản phẩm ở bảng THUCPHAM
                var tp = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
                if (tp == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.THUCPHAMs.DeleteOnSubmit(tp);

                // xoá sản phẩm ở bảng CHITIETTHUCPHAM
                var cttp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);

                db.CHITIETTHUCPHAMs.DeleteOnSubmit(cttp);

                db.SubmitChanges();

                return RedirectToAction("QuanLyThucPham");
            }
            else if(t.CheckSale == 1)
            {
                var ct = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == id);
                var ctkm = from s in db.CHITIETKHUYENMAIs.Where(n => n.THUCPHAM.MaThucPham == id) select s;
                db.CHITIETKHUYENMAIs.DeleteOnSubmit(ctkm.SingleOrDefault());
                // xoá sản phẩm ở bảng THUCPHAM
                var tp = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
                if (tp == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.THUCPHAMs.DeleteOnSubmit(tp);

                // xoá sản phẩm ở bảng CHITIETTHUCPHAM
                var cttp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.THUCPHAM.MaThucPham == id);

                db.CHITIETTHUCPHAMs.DeleteOnSubmit(cttp);

                db.SubmitChanges();

                return RedirectToAction("QuanLyThucPham");
            }

            return RedirectToAction("QuanLyThucPham");
        }
        public ActionResult DetailsThucPham(int id)
        {
            var tp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }

        public List<CHITIETTHUCPHAM> ListPhanLoaiThucPham(int id)
        {
            return db.CHITIETTHUCPHAMs.Where(n => n.MaLoaiThucPham == id).ToList();
        }
        public ActionResult PhanLoaiThucPham(int id)
        {
            var rs = ListPhanLoaiThucPham(id);
            var s = db.LOAITHUCPHAMs.SingleOrDefault(n => n.MaLoaiThucPham == id);
            ViewBag.TenLoaiThucPham = s.TenLoaiThucPham;
            return View(rs);
        }

        
        //Quản lý khuyến mại
        public ActionResult QuanLyKhuyenMai()
        {
            var rs = from s in db.CHUONGTRINHKHUYENMAIs.ToList() select s;
            return View(rs.ToList());
        }
        [HttpGet]
        public ActionResult CreateKhuyenMai()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateKhuyenMai(CHUONGTRINHKHUYENMAI km, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                km.TenKM = f["sTenKM"];
                km.ThoiGianBD = Convert.ToDateTime(f["dThoiGianBD"]);
                km.ThoiGianKT = Convert.ToDateTime(f["dThoiGianKT"]);
                db.CHUONGTRINHKHUYENMAIs.InsertOnSubmit(km);
                db.SubmitChanges();
                return RedirectToAction("QuanLyKhuyenMai","QuanLyChung");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditKhuyenMai(int id)
        {
            var tp = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            ViewBag.TenKM = tp.TenKM;
            ViewBag.ThoiGianBD = Convert.ToDateTime(tp.ThoiGianBD);
            ViewBag.ThoiGianKT = Convert.ToDateTime(tp.ThoiGianKT);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditKhuyenMai(int id, FormCollection f)
        {
            var tp = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            ViewBag.TenKM = tp.TenKM;
            ViewBag.ThoiGianBD = Convert.ToDateTime(tp.ThoiGianBD);
            ViewBag.ThoiGianKT = Convert.ToDateTime(tp.ThoiGianKT);
            if (ModelState.IsValid)
            {
                tp.TenKM = f["sTenKM"];
                tp.ThoiGianBD = Convert.ToDateTime(f["dThoiGianBD"]);
                tp.ThoiGianKT = Convert.ToDateTime(f["dThoiGianKT"]);
                db.SubmitChanges();
                return RedirectToAction("QuanLyKhuyenMai");
            }
            return View(tp);
        }

        [HttpGet]
        public ActionResult DeleteKhuyenMai(int id)
        {
            var tp = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tp);
        }

        [HttpPost, ActionName("DeleteKhuyenMai")]
        public ActionResult DeleteKhuyenMai(int id, FormCollection f)
        {
            var tp = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.CHUONGTRINHKHUYENMAIs.DeleteOnSubmit(tp);
            db.SubmitChanges();

            return RedirectToAction("QuanLyKhuyenMai");
        }
        public List<CHITIETKHUYENMAI> ListSanPhamKhuyenMai(int id)
        {
            return db.CHITIETKHUYENMAIs.Where(n => n.MaKM == id).ToList();
        }
        public ActionResult DetailsKhuyenMai(int id)
        {
            var rs = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            ViewBag.MaKM = rs.MaKM;
            ViewBag.TenKM = rs.TenKM.ToString();
            var tp = ListSanPhamKhuyenMai(id);
            return View(tp);
        }


        //trang con chi tiết của từng loại khuyến mãi
        [HttpGet]
        public ActionResult CreateSanPhamKhuyenMai(int id)
        {
            var rs = from s in db.CHUONGTRINHKHUYENMAIs.Where(n => n.MaKM == id) select s.MaKM;
            ViewBag.MaKM = rs;
            ViewBag.MaThucPham = new SelectList(db.CHITIETTHUCPHAMs.ToList().OrderBy(n => n.THUCPHAM.NgayDang), "MaThucPham", "TenThucPham");
            //ViewBag.Check = new SelectList(db.CHITIETTHUCPHAMs.ToList().OrderBy(n => n.THUCPHAM.NgayDang), "MaThucPham", "MaThucPham");
            //ViewBag.CheckSales = new SelectList(db.THUCPHAMs.ToList().OrderBy(n => n.CheckSale), "MaThucPham", "CheckSale", new { @value = "1"});
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateSanPhamKhuyenMai(int id, FormCollection f)
        {
            //var ten = db.THUCPHAMs.SingleOrDefault(n => n.TenThucPham.Equals(Request.Form["TenThucPham"]));

            ViewBag.MaThucPham = new SelectList(db.CHITIETTHUCPHAMs.ToList().OrderBy(n => n.THUCPHAM.NgayDang), "MaThucPham", "TenThucPham");
            //ViewBag.Check = new SelectList(db.CHITIETTHUCPHAMs.ToList().OrderBy(n => n.THUCPHAM.NgayDang), "MaThucPham", "MaThucPham");

            //var rs = db.CHUONGTRINHKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);
            //var km = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaKM == id);

            if (ModelState.IsValid)
            {
                CHITIETKHUYENMAI km = new CHITIETKHUYENMAI();
                km.MaKM = id;
                km.MaThucPham = Convert.ToInt32(f["MaThucPham"]);
                km.GiamGia = Convert.ToInt32(f["iGiamGia"]);
                var tp2 = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == km.MaThucPham);
                var ctth = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == km.MaThucPham);
                km.TenThucPham = tp2.TenThucPham;
                km.Gia = Convert.ToDecimal(ctth.Gia);
                km.Up = 1;
                km.AnhBia = ctth.AnhBia;
                db.CHITIETKHUYENMAIs.InsertOnSubmit(km);
                             
                if(tp2.CheckSale == 1)
                {
                    return RedirectToAction("DetailsKhuyenMai", "QuanLyChung", new { id = id });
                }
                tp2.CheckSale = int.Parse(f["CheckSales"]);
                tp2.GiamGia = Convert.ToInt32(f["iGiamGia"]);

                db.SubmitChanges();
                return RedirectToAction("DetailsKhuyenMai", "QuanLyChung", new { id = id });
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSanPhamKhuyenMai(int idMTP, int idMKM)
        {
            
            var tp = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == idMTP && n.MaKM == idMKM);//id
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs.ToList().Where(n => n.MaThucPham == idMTP), "MaThucPham", "TenThucPham");
            if (tp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //ViewBag.TenThucPham = db.THUCPHAMs.ToList().OrderBy(n => n.MaThucPham = idMTP);
            return View(tp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSanPhamKhuyenMai(int idMTP, int idMKM, FormCollection f)
        {
            var tp = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == idMTP && n.MaKM == idMKM);
            ViewBag.MaThucPham = new SelectList(db.THUCPHAMs.ToList().Where(n => n.MaThucPham == idMTP), "MaThucPham", "TenThucPham");
            if (ModelState.IsValid)
            {
                
                tp.GiamGia = int.Parse(f["iGiamGia"]);
                tp.MaThucPham = idMTP;
                //Thêm % giảm giá vào Bảng THUCPHAM
                var t = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == idMTP);
                var cttp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == idMTP);
                tp.TenThucPham = t.TenThucPham;
                tp.Gia = Convert.ToDecimal(cttp.Gia);
                t.GiamGia = int.Parse(f["iGiamGia"]);
                db.SubmitChanges();
                return RedirectToAction("DetailsKhuyenMai", "QuanLyChung", new { id = tp.MaKM});
            }
            return View(tp);
        }
        [HttpGet]
        public ActionResult DeleteSanPhamKhuyenMai(int idMTP, int idMKM, int idMaCT)
        {
            var tp = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == idMTP && n.MaKM == idMKM && n.MaCT == idMaCT);//id
            if (tp == null)
            {
                return RedirectToAction("QuanLyKhuyenMai", "QuanLyChung");
            }
            return View(tp);
        }
        [HttpPost, ActionName("DeleteSanPhamKhuyenMai")]
        public ActionResult DeleteSanPhamKhuyenMai(int idMTP, int idMKM, int idMaCT, FormCollection f)
        {
            //var tp = db.CHITIETTHUCPHAMs.SingleOrDefault(n => n.MaThucPham == idMTP);
            //tp.CheckSale = 0;

            var tp2 = db.THUCPHAMs.SingleOrDefault(n => n.MaThucPham == idMTP);
            tp2.CheckSale = 0;
            tp2.GiamGia = 0;

            db.SubmitChanges();

            var ct = db.CHITIETKHUYENMAIs.SingleOrDefault(n => n.MaThucPham == idMTP && n.MaKM == idMKM && n.MaCT == idMaCT);
            
            if (ct == null)
            {
                return RedirectToAction("QuanLyKhuyenMai", "QuanLyChung");
            }
            
            db.CHITIETKHUYENMAIs.DeleteOnSubmit(ct);
            db.SubmitChanges();

            return RedirectToAction("DetailsKhuyenMai", "QuanLyChung", new { id = ct.MaKM});
        }

        

    }
}