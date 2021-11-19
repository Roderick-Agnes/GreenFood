using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenFood.Models;
using GreenFood.nganluongAPI;
using Newtonsoft.Json.Linq;
using NWebsec.Helpers;

namespace GreenFood.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        dbGreenFoodDataContext data = new dbGreenFoodDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //khoi tao gio hang rong
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Them san pham vao gio
        public ActionResult ThemGioHang(int mtp, string url)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Find(n => n.iMaThucPham == mtp);
            if (sp == null)
            {
                sp = new GioHang(mtp);
                lstGioHang.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }
            return Redirect(url);
        }
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
        //Tinh tong tien
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
        //Action tra ve view GioHang
        public ActionResult GioHang()
        {
            CHITIETTHUCPHAM ct = new CHITIETTHUCPHAM();
            int a = Convert.ToInt32(ct.TrongLuong);
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "GreenFood");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTrongLuong = TongSoLuong() * a;
            ViewBag.TongTien = TongTien();
            return View();
        }
        public ActionResult GioHangPartial()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "GreenFood");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        //Xoa san pham khoi gio hang
        public ActionResult XoaSPKhoiGioHang(int iMaThucPham)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.iMaThucPham == iMaThucPham);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.iMaThucPham == iMaThucPham);
                if (lstGioHang.Count == 0)
                {
                    return RedirectToAction("Index", "GreenFood");
                }
            }
            return RedirectToAction("GioHang");
        }
        //Cap nhat gio hang
        public ActionResult CapNhatGioHang(int iMaThucPham, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.iMaThucPham == iMaThucPham);
            //neu ton tai thi cho sua so luong
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //Xoa gio hang
        public ActionResult XoaGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("Index", "GreenFood"); //edit rong

        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                return Redirect("~/User/DangNhap?id=2");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "GreenFood"); //edit rong
            }

            List<GioHang> lstGiohang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGiohang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            var valuePayment = f["valueMd"].ToString();
            var _bankCode = "BIDV";
            QUANLYDONHANG qldh = new QUANLYDONHANG();

            THANHVIEN kh = (THANHVIEN)Session["UserName"];
            List<GioHang> listGioHang = LayGioHang();

            foreach (var item in listGioHang)///////////////bien doi
            {
                qldh.MaKH = kh.MaTV;
                qldh.NgayDat = DateTime.Now;
                var NgayGiao = String.Format("{0:MM/dd/yyyy}", Request.Form["NgayGiao"]);
                qldh.NgayGiao = DateTime.Parse(NgayGiao);
                qldh.GhiChu = Request.Form["GhiChu"];
                data.QUANLYDONHANGs.InsertOnSubmit(qldh);
                data.SubmitChanges();


                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MaDonHang = qldh.MaDonHang;
                ctdh.MaThucPham = item.iMaThucPham;
                ctdh.MaLoaiThucPham = item.iMaLoaiThucPham;
                ctdh.TrongLuong = item.iTrongLuong;
                ctdh.TongTien = (decimal)item.dThanhTien;
                ctdh.NgayThanhToan = DateTime.Now;
                ctdh.ThanhToan = 0; // edit thanh toan o day

                data.CHITIETDONHANGs.InsertOnSubmit(ctdh);
                data.SubmitChanges();

                var tmp = data.CHITIETTHUCPHAMs.Where(n => n.MaThucPham == item.iMaThucPham).SingleOrDefault();
                tmp.SoLuongDaBan = tmp.SoLuongDaBan + TongSoLuong();
                tmp.SoLuongBan = tmp.SoLuongBan - TongSoLuong();
                data.SubmitChanges();

                if (valuePayment.Equals("CASH"))
                {

                    Session["GioHang"] = null;
                    return RedirectToAction("XacNhanDonHang", "GioHang");
                }
                else
                {
                    var merchantId = "50875";
                    var merchantPassword = "13b8827767c2cb721202d385272aea06";
                    var merchantEmail = "m.contactqc@gmail.com";
                    var currentLink = "https://localhost:44342/";

                    RequestInfo info = new RequestInfo();
                    info.Merchant_id = merchantId;//"50855";
                    info.Merchant_password = merchantPassword;// "6e48134196f2a34962e6ae276bedccfb";
                    info.Receiver_email = merchantEmail;// "1924801030112@student.tdmu.edu.vn";



                    info.cur_code = "vnd";
                    info.bank_code = _bankCode.ToString();

                    info.Order_code = qldh.MaDonHang.ToString();
                    info.Total_amount = item.dThanhTien.ToString();
                    info.fee_shipping = "0";
                    info.Discount_amount = "0";
                    info.order_description = "Thanh toán đơn hàng tại GreenFood";
                    info.return_url = currentLink.ToString() + "/GioHang/XacNhanDonHang";
                    info.cancel_url = currentLink.ToString() + "/GioHang/HuyDonHang";

                    info.Buyer_fullname = qldh.THANHVIEN.HoTenTV;
                    info.Buyer_email = qldh.THANHVIEN.Email;
                    info.Buyer_mobile = qldh.THANHVIEN.DienThoai;

                    APICheckoutV3 objNLChecout = new APICheckoutV3();
                    ResponseInfo result = objNLChecout.GetUrlCheckout(info, valuePayment.ToString()/*pm.paymentMethod*/);

                    if (result.Error_code == "00")
                    {
                        

                        return Redirect(result.Checkout_url);// Response.Redirect(result.Checkout_url);
                    }
                    else
                    {
                        string res = result.Description;
                        //string res = result.Error_code;

                        return RedirectToAction("LoiDonHang", "GioHang", new { res }); //Json(res.ToString());//
                    }
                }
            }
            return View();
        }





            //Thanh toán bằng MOMO
            //string endpoint = ConfigurationManager.AppSettings["endpoint"].ToString();
            //string partnerCode = ConfigurationManager.AppSettings["partnerCode"].ToString();
            //string accessKey = ConfigurationManager.AppSettings["accessKey"].ToString();
            //string serectkey = ConfigurationManager.AppSettings["serectkey"].ToString();
            //string orderInfo = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //string returnUrl = ConfigurationManager.AppSettings["returnUrl"].ToString();
            //string notifyurl = ConfigurationManager.AppSettings["notifyurl"].ToString();

            //string amount = ((decimal)item.dThanhTien).ToString();
            //string orderid = Guid.NewGuid().ToString();
            //string requestId = Guid.NewGuid().ToString();
            //string extraData = "";

            //string rawHash = "partnerCode=" +
            //    partnerCode + "&accessKey=" +
            //    accessKey + "&requestId=" +
            //    requestId + "&amount=" +
            //    amount + "&orderId=" +
            //    orderid + "&orderInfo=" +
            //    orderInfo + "&returnUrl=" +
            //    returnUrl + "&notifyUrl=" +
            //    notifyurl + "&extraData=" +
            //    extraData;
            //MoMoSecurity crypto = new MoMoSecurity();
            //string signature = crypto.signSHA256(rawHash, serectkey);
            //JObject message = new JObject
            //{
            //    {"partnerCode", partnerCode },
            //    {"accessKey", accessKey },
            //    {"requestId", requestId },
            //    {"amount", amount },
            //    {"orderId", orderid },
            //    {"orderInfo", orderInfo },
            //    {"returnUrl", returnUrl },
            //    {"notifyUrl", notifyurl },
            //    {"requestType", "captureMoMoWallet" },
            //    //{"signature", signature }
            //};


        public ActionResult XacNhanDonHang()
        {
            return View();
        }
        public ActionResult LoiDonHang(string res)
        {
            ViewBag.ErrorMessage = res.ToString();
            return View();
        }
        public ActionResult HuyDonHang()
        {
            return View();
        }
    }
}