using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ThongTinXuatHoaDonUtils
    {
        public static ThongTinXuatHoaDon UpdateThongTinXuatHoaDon(ThongTinXuatHoaDon oldThongTinXuatHoaDon, ThongTinXuatHoaDon newThongTinXuatHoaDon)
        {
            oldThongTinXuatHoaDon.TenNguoiMuaHang = newThongTinXuatHoaDon.TenNguoiMuaHang;
            oldThongTinXuatHoaDon.TenDonVi = newThongTinXuatHoaDon.TenDonVi;
            oldThongTinXuatHoaDon.TenKhachHangXuatHoaDon = newThongTinXuatHoaDon.TenKhachHangXuatHoaDon;
            oldThongTinXuatHoaDon.Email = newThongTinXuatHoaDon.Email;
            oldThongTinXuatHoaDon.SoDt = newThongTinXuatHoaDon.SoDt;
            oldThongTinXuatHoaDon.LuuY = newThongTinXuatHoaDon.LuuY;
            oldThongTinXuatHoaDon.DiaChi = newThongTinXuatHoaDon.DiaChi;
            return oldThongTinXuatHoaDon;
        }
    }
}
