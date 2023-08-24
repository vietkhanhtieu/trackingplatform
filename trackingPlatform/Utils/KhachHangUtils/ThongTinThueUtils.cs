
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ThongTinThueUtils
    {
        public static ThongTinThue UpdateThongTinThue(ThongTinThue oldThongTinThue, ThongTinThue newThongTinThue)
        {
            oldThongTinThue.MaSoThue = newThongTinThue.MaTtThue;
            oldThongTinThue.XacNhanThue = newThongTinThue.XacNhanThue;
            oldThongTinThue.HoatDong = newThongTinThue.HoatDong;
            return oldThongTinThue;
        }
        public static ThongTinThue UpdateThongTinThueRequest(ThongTinThue oldThongTinThue, KHB2B_ThongTinThueRequest newThongTinThue)
        {
            oldThongTinThue.MaSoThue = newThongTinThue.MaTtThue;
            oldThongTinThue.XacNhanThue = newThongTinThue.XacNhanThue;
            oldThongTinThue.HoatDong = newThongTinThue.HoatDong;
            return oldThongTinThue;
        }
    }
}
