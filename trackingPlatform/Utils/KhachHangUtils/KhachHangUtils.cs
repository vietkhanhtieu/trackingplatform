using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class KhachHangUtils
    {
        public static KhachHang UpdateKhachHang(KhachHang oldKhachHang, KhachHang newKhachHang)
        {
            oldKhachHang.TenKhachHang = newKhachHang.TenKhachHang;
            oldKhachHang.DuocDuyet = newKhachHang.DuocDuyet;
            oldKhachHang.Email = newKhachHang.Email;
            oldKhachHang.SoDt = newKhachHang.SoDt;
            oldKhachHang.TrangThaiHoatDong = newKhachHang.TrangThaiHoatDong;
            oldKhachHang.CodeMonet = newKhachHang.CodeMonet;
            oldKhachHang.MaKhachHangB2b = newKhachHang.MaKhachHangB2b;
            oldKhachHang.MaKhachHangB2c = newKhachHang.MaKhachHangB2c;
            oldKhachHang.MaPhuongThuc = newKhachHang.MaPhuongThuc;
            oldKhachHang.MaKhoQuaTang = newKhachHang.MaKhoQuaTang;
            oldKhachHang.MaLoaiThe = newKhachHang.MaLoaiThe;
            oldKhachHang.MaTtXuatHd = newKhachHang.MaTtXuatHd;
            oldKhachHang.MaKhachHangGonsa = newKhachHang.MaKhachHangGonsa;
            oldKhachHang.DoUuTien = newKhachHang.DoUuTien;
            oldKhachHang.GhiChu = newKhachHang.GhiChu;
            oldKhachHang.TenChuNhaThuoc = newKhachHang.TenChuNhaThuoc;
            oldKhachHang.DiaChi = newKhachHang.DiaChi;
            return oldKhachHang;
        }
    }
}
