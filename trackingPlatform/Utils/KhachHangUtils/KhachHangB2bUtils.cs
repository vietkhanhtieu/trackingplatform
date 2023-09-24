using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class KhachHangB2bUtils
    {
        public static KhachHangB2b UpdateKhachHangB2b(KhachHangB2b oldKhachHangB2b, KhachHangB2b newKhachHangB2b)
        {
            oldKhachHangB2b.GiayPhepKinhDoanh = newKhachHangB2b.GiayPhepKinhDoanh;
            oldKhachHangB2b.NgayThanhLap = newKhachHangB2b.NgayThanhLap;
            oldKhachHangB2b.BaoHiemThanhToan = newKhachHangB2b.BaoHiemThanhToan;
            oldKhachHangB2b.MaPhanHang = newKhachHangB2b.MaPhanHang;
            oldKhachHangB2b.MaPhanNganh = newKhachHangB2b.MaPhanNganh;
            oldKhachHangB2b.MaNhom = newKhachHangB2b.MaNhom;
            oldKhachHangB2b.MaNguoiDaiDien = newKhachHangB2b.MaNguoiDaiDien;
            oldKhachHangB2b.MaKhachHangGonsa = newKhachHangB2b.MaKhachHangGonsa;
            oldKhachHangB2b.LaNcc = newKhachHangB2b.LaNcc;
            oldKhachHangB2b.LaCsh = newKhachHangB2b.LaCsh;
            oldKhachHangB2b.LaKhdv = newKhachHangB2b.LaKhdv;
            oldKhachHangB2b.LaPartner = newKhachHangB2b.LaPartner;
            return oldKhachHangB2b;
        }
    }
}
