using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
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
        public static ThongTinNguonGoc UpdateThongTinNguonGocRequest(ThongTinNguonGoc oldThongTinNguonGoc, SP_ThongTinNguonGocRequest newThongTinNguonGoc)
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
