using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using GSF.Net.Smtp;
using Mail = GreenFood.Models.Mail;

namespace GreenFood.Areas.Admin.Controllers
{
    public class QuanLyTinNhanController : Controller
    {
        // GET: Admin/QuanLyTinNhan
        dbGreenFoodDataContext db = new dbGreenFoodDataContext();
        public List<TINNHANLIENHE> ListTinNhan()
        {
            return db.TINNHANLIENHEs.ToList();
        }
        public ActionResult QuanLyTinNhan()
        {
            var rs = ListTinNhan();
            return View(rs.ToList());
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rs = db.TINNHANLIENHEs.SingleOrDefault(n => n.MaTinNhan == id);
            ViewBag.TenKH = rs.TenKH;
            ViewBag.TieuDe = rs.TieuDe;
            ViewBag.Email = rs.Email;
            ViewBag.NoiDung = rs.NoiDungTuKH;
            ViewBag.NgayNhan = rs.NgayNhan;
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection f)
        {
            var rs = db.TINNHANLIENHEs.SingleOrDefault(n => n.MaTinNhan == id);
            ViewBag.TenKH = rs.TenKH;
            ViewBag.TieuDe = rs.TieuDe;
            ViewBag.Email = rs.Email;
            ViewBag.NoiDung = rs.NoiDungTuKH;
            ViewBag.NgayNhan = rs.NgayNhan;
            db.TINNHANLIENHEs.DeleteOnSubmit(rs);
            db.SubmitChanges();
            return RedirectToAction("QuanLyTinNhan","QuanLyTinNhan");
        }

        //Trả lời 
        [HttpGet]
        public ActionResult SendMail(int id)
        {
            TINNHANLIENHE tn = db.TINNHANLIENHEs.SingleOrDefault(n => n.MaTinNhan == id);
            ViewBag.TenKH = tn.TenKH;
            ViewBag.TieuDe = tn.TieuDe;
            ViewBag.NoiDung = tn.NoiDungTuKH;
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(int id, Mail model, FormCollection fc)
        {
            TINNHANLIENHE tn = db.TINNHANLIENHEs.SingleOrDefault(n => n.MaTinNhan == id);
            tn.TraLoi = fc["TraLoi"];
            db.SubmitChanges();
            ViewBag.TenKH = tn.TenKH;
            ViewBag.TieuDe = tn.TieuDe;
            ViewBag.NoiDung = tn.NoiDungTuKH;
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("maichancuong2001@gmail.com", "loveyou3007@"),
                EnableSsl = true
            };
            var message = new MailMessage();
            message.From = new MailAddress("maichancuong2001@gmail.com");
            message.ReplyToList.Add("maichancuong2001@gmail.com");
            message.To.Add(new MailAddress(tn.Email));
            message.Subject = tn.TieuDe;
            message.Body = fc["TraLoi"];

            //var f = Request.Files["attachment"];
            //var path = Path.Combine(Server.MapPath("~/UploadFile"), f.FileName);
            //if (!System.IO.File.Exists(path))
            //{
            //    f.SaveAs(path);
            //}
            //Attachment data = new Attachment(Server.MapPath("~/UploadFile/" + f.FileName), MediaTypeNames.Application.Octet);
            mail.Send(message);
            return RedirectToAction("QuanLyTinNhan","QuanLyTinNhan");
        }
    }
}