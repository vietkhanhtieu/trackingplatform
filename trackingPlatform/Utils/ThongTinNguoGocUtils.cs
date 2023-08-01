using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class ThongTinNguoGocUtils
    {
        public static ThongTinNguonGoc UpdateThongTinNguonGoc(ThongTinNguonGoc oldThongTinNguonGoc, ThongTinNguonGoc newThongTinNguonGoc)
        {
            oldThongTinNguonGoc.SoDangKy = newThongTinNguonGoc.SoDangKy;
            oldThongTinNguonGoc.SoQdGiaHan = newThongTinNguonGoc.SoQdGiaHan;
            oldThongTinNguonGoc.HieuLucSdk = newThongTinNguonGoc.HieuLucSdk;
            oldThongTinNguonGoc.NuocSanXuat = newThongTinNguonGoc.NuocSanXuat;
            oldThongTinNguonGoc.NhaSanXuat = newThongTinNguonGoc.NhaSanXuat;
            oldThongTinNguonGoc.TieuChuanSanXuat = newThongTinNguonGoc.TieuChuanSanXuat;
            oldThongTinNguonGoc.SdkVoThoiHan = newThongTinNguonGoc.SdkVoThoiHan;
            return oldThongTinNguonGoc;
        }
    }
}
