using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class ThongTinChinhUtils
    {
        public static ThongTinChinh UpdateThongTinChinh(ThongTinChinh oldThongTinChinh, ThongTinChinh newThongTinChinh)
        {
            oldThongTinChinh.HoatChat = newThongTinChinh.HoatChat;
            oldThongTinChinh.HamLuong = newThongTinChinh.HamLuong;
            oldThongTinChinh.PhamViPhanPhoi = newThongTinChinh.PhamViPhanPhoi;
            oldThongTinChinh.DuongDung = newThongTinChinh.DuongDung;
            oldThongTinChinh.NhomDieuTri = newThongTinChinh.NhomDieuTri;
            oldThongTinChinh.LieuDung = newThongTinChinh.LieuDung;
            oldThongTinChinh.HanDung = newThongTinChinh.HanDung;
            oldThongTinChinh.KeToa = newThongTinChinh.KeToa;
            return oldThongTinChinh;
        }
    }
}
