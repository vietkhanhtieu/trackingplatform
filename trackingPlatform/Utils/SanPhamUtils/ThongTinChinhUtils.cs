using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;

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
        public static ThongTinChinh UpdateThongTinChinhRequest(ThongTinChinh oldThongTinChinh, SP_ThongTinChinhRequest newThongTinChinh)
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
