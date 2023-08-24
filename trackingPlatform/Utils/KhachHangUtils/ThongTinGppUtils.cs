

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ThongTinGppUtils
    {
        public static ThongTinGpp UpdateThongTinGpp(ThongTinGpp oldThongTinGpp, ThongTinGpp newThongTinGpp)
        {
            oldThongTinGpp.NgayCap = newThongTinGpp.NgayCap;
            oldThongTinGpp.NgayHetHan = newThongTinGpp.NgayHetHan;
            oldThongTinGpp.HoatDong = newThongTinGpp.HoatDong;
            oldThongTinGpp.HinhAnh = newThongTinGpp.HinhAnh;
            oldThongTinGpp.FilePdf = newThongTinGpp.FilePdf;
            oldThongTinGpp.SoChungNhanGpp = newThongTinGpp.SoChungNhanGpp;
            return oldThongTinGpp;
        }

        public static ThongTinGpp UpdateThongTinGppRequest(ThongTinGpp oldThongTinGpp, KHB2B_ThongTinGppRequest newThongTinGpp)
        {
            oldThongTinGpp.NgayCap = newThongTinGpp.NgayCap;
            oldThongTinGpp.NgayHetHan = newThongTinGpp.NgayHetHan;
            oldThongTinGpp.HoatDong = newThongTinGpp.HoatDong;
            oldThongTinGpp.HinhAnh = newThongTinGpp.HinhAnh;
            oldThongTinGpp.FilePdf = newThongTinGpp.FilePdf;
            oldThongTinGpp.SoChungNhanGpp = newThongTinGpp.SoChungNhanGpp;
            return oldThongTinGpp;
        }
    }
}
