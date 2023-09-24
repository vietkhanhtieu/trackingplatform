
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ThongTinGdpUtils
    {
       public static ThongTinGdp UpdateThongTinGdp(ThongTinGdp oldThongTinGdp, ThongTinGdp newThongTinGdp)
        {
            oldThongTinGdp.NgayCap = newThongTinGdp.NgayCap;
            oldThongTinGdp.NgayHetHan = newThongTinGdp.NgayHetHan;
            oldThongTinGdp.HoatDong = newThongTinGdp.HoatDong;
            oldThongTinGdp.HinhAnh = newThongTinGdp.HinhAnh;
            oldThongTinGdp.FilePdf = newThongTinGdp.FilePdf;
            oldThongTinGdp.SoChungNhanGdp = newThongTinGdp.SoChungNhanGdp;
            return oldThongTinGdp;
        }
        public static ThongTinGdp UpdateThongTinGdpRequest(ThongTinGdp oldThongTinGdp, KHB2B_ThongTinGdpRequest newThongTinGdp)
        {
            oldThongTinGdp.NgayCap = newThongTinGdp.NgayCap;
            oldThongTinGdp.NgayHetHan = newThongTinGdp.NgayHetHan;
            oldThongTinGdp.HoatDong = newThongTinGdp.HoatDong;
            oldThongTinGdp.HinhAnh = newThongTinGdp.HinhAnh;
            oldThongTinGdp.FilePdf = newThongTinGdp.FilePdf;
            oldThongTinGdp.SoChungNhanGdp = newThongTinGdp.SoChungNhanGdp;
            return oldThongTinGdp;
        }
    }
}
