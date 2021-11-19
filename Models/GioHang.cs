using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenFood.Models
{
    public class GioHang
    {
        dbGreenFoodDataContext data = new dbGreenFoodDataContext();
        public int iMaThucPham { get; set; }
        public int iMaLoaiThucPham { get; set; }
        public string sTenThucPham { get; set; }
        public double dGia { get; set; }
        public double dGiaGoc { get; set; }
        public int iSoLuong { get; set; }
        public int iSoLuongToiDa { get; set; }
        public int iSoLuongDaBan { get; set; }
        public int iTrongLuong { get; set; }
        public int ccheck { get; set; }
        public int iGiamGia { get; set; }
        public int iSLCL { get { return iSoLuong - iSoLuongDaBan; } }
        /// <summary>
        /// Thanh toán bằng ngân lượng
        /// </summary>
        public string PaymentMethod { get; set; }
        public string BankCode { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dGia; }
        }
        public string sAnhBia { get; set; }
        public GioHang(int mtp)
        {
            iMaThucPham = mtp;
            CHITIETTHUCPHAM s = data.CHITIETTHUCPHAMs.Single(n => n.MaThucPham == iMaThucPham);
            if(s.THUCPHAM.CheckSale == 0)
            {
                sTenThucPham = s.TenThucPham;
                dGia = Convert.ToDouble(s.Gia);
                iSoLuong = 1;
                iSoLuongToiDa = (int)s.SoLuongBan;
                sAnhBia = s.AnhBia;
                iTrongLuong = Convert.ToInt32(s.TrongLuong);
                THUCPHAM t = data.THUCPHAMs.Single(m => m.MaThucPham == iMaThucPham);
                iMaLoaiThucPham = (int)t.MaLoaiThucPham;
                ccheck = (int)t.CheckSale;
                iGiamGia = (int)t.GiamGia;
            }
            else
            {
                sTenThucPham = s.TenThucPham;
                dGia = Convert.ToDouble(s.Gia - (s.THUCPHAM.GiamGia*s.Gia/100));
                dGiaGoc = Convert.ToDouble(s.Gia);
                iSoLuong = 1;
                iSoLuongToiDa = (int)s.SoLuongBan;
                sAnhBia = s.AnhBia;
                iTrongLuong = Convert.ToInt32(s.TrongLuong);
                THUCPHAM t = data.THUCPHAMs.Single(m => m.MaThucPham == iMaThucPham);
                iMaLoaiThucPham = (int)t.MaLoaiThucPham;
                ccheck = (int)t.CheckSale;
                iGiamGia = (int)t.GiamGia;
            }
        }
    }
}