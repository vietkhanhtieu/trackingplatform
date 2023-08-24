using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class NhomKhachHangB2BUtils
    {
        public static NhomKhachHangB2b UpdateNhomKhachHangB2B(NhomKhachHangB2b oldNhomKhachHangB2b, NhomKhachHangB2b newNhomKhachHangB2b)
        {
            oldNhomKhachHangB2b.TenNhom = newNhomKhachHangB2b.TenNhom;
            oldNhomKhachHangB2b.KyHieuVietTat = newNhomKhachHangB2b.KyHieuVietTat;
            oldNhomKhachHangB2b.MoTa = newNhomKhachHangB2b.MoTa;
            return oldNhomKhachHangB2b;
        }
    }
}
