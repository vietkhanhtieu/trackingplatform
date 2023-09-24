using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class CbnvKhachHangUtils
    {
        public static CbnvKhachHang UpadateCbnvKhachHang(CbnvKhachHang oldCbnvKhachHang, CbnvKhachHang newCbnvKhachHang)
        {
            oldCbnvKhachHang.TenCbnv = newCbnvKhachHang.TenCbnv;
            oldCbnvKhachHang.NgaySinh = newCbnvKhachHang.NgaySinh;
            oldCbnvKhachHang.ChucVu = newCbnvKhachHang.ChucVu;
            oldCbnvKhachHang.PhongBan = newCbnvKhachHang.PhongBan;
            oldCbnvKhachHang.Email = newCbnvKhachHang.Email;
            oldCbnvKhachHang.PhongBan = newCbnvKhachHang.PhongBan;
            oldCbnvKhachHang.GioiTinh = newCbnvKhachHang.GioiTinh;
            oldCbnvKhachHang.SoDt = newCbnvKhachHang.SoDt;
            oldCbnvKhachHang.GhiChu = newCbnvKhachHang.GhiChu;
            return oldCbnvKhachHang;
        }
        public static CbnvKhachHang UpadateCbnvKhachHangRequest(CbnvKhachHang oldCbnvKhachHang, KHB2B_CbnvKhachHangRequest newCbnvKhachHang)
        {
            oldCbnvKhachHang.TenCbnv = newCbnvKhachHang.TenCbnv;
            oldCbnvKhachHang.NgaySinh = newCbnvKhachHang.NgaySinh;
            oldCbnvKhachHang.ChucVu = newCbnvKhachHang.ChucVu;
            oldCbnvKhachHang.PhongBan = newCbnvKhachHang.PhongBan;
            oldCbnvKhachHang.Email = newCbnvKhachHang.Email;
            oldCbnvKhachHang.PhongBan = newCbnvKhachHang.PhongBan;
            oldCbnvKhachHang.GioiTinh = newCbnvKhachHang.GioiTinh;
            oldCbnvKhachHang.SoDt = newCbnvKhachHang.SoDt;
            oldCbnvKhachHang.GhiChu = newCbnvKhachHang.GhiChu;
            return oldCbnvKhachHang;
        }
    }
}
