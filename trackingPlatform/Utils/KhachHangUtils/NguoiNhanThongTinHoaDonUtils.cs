

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class NguoiNhanThongTinHoaDonUtils
    {
        public static NguoiNhanTtHdon UpdateNguoiNhanTtHdon(NguoiNhanTtHdon oldNguoiNhanTtHoaDon, NguoiNhanTtHdon newNguoiNhanTtHoaDon)
        {
            oldNguoiNhanTtHoaDon.TenNguoiNhan = newNguoiNhanTtHoaDon.TenNguoiNhan;
            oldNguoiNhanTtHoaDon.SoDt = newNguoiNhanTtHoaDon.SoDt;
            oldNguoiNhanTtHoaDon.Email= newNguoiNhanTtHoaDon.Email;
            return oldNguoiNhanTtHoaDon;
        }
        public static NguoiNhanTtHdon UpdateNguoiNhanTtHdonRequest(NguoiNhanTtHdon oldNguoiNhanTtHoaDon, KHB2B_NguoiNhanTtHdonRequest newNguoiNhanTtHoaDon)
        {
            oldNguoiNhanTtHoaDon.TenNguoiNhan = newNguoiNhanTtHoaDon.TenNguoiNhan;
            oldNguoiNhanTtHoaDon.SoDt = newNguoiNhanTtHoaDon.SoDt;
            oldNguoiNhanTtHoaDon.Email = newNguoiNhanTtHoaDon.Email;
            return oldNguoiNhanTtHoaDon;
        }
    }
}
