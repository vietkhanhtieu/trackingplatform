

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ChiNhanhUtils
    {
        public static ChiNhanh UpdateChiNhanh(ChiNhanh oldChiNhanh, ChiNhanh newChiNhanh)
        {
            oldChiNhanh.TenChiNhanh = newChiNhanh.TenChiNhanh;
            oldChiNhanh.ChiNhanhMe = newChiNhanh.ChiNhanhMe;
            oldChiNhanh.Email = newChiNhanh.Email;
            oldChiNhanh.SoDt = newChiNhanh.SoDt;
            oldChiNhanh.MoiQuanHe = newChiNhanh.MoiQuanHe;
            oldChiNhanh.DiaChi = newChiNhanh.DiaChi;

            return oldChiNhanh;
        }
        public static ChiNhanh UpdateChiNhanhRequest(ChiNhanh oldChiNhanh, KHB2B_ChiNhanhRequest newChiNhanh)
        {
            oldChiNhanh.TenChiNhanh = newChiNhanh.TenChiNhanh;
            oldChiNhanh.ChiNhanhMe = newChiNhanh.ChiNhanhMe;
            oldChiNhanh.Email = newChiNhanh.Email;
            oldChiNhanh.SoDt = newChiNhanh.SoDt;
            oldChiNhanh.MoiQuanHe = newChiNhanh.MoiQuanHe;
            oldChiNhanh.DiaChi = newChiNhanh.DiaChi;

            return oldChiNhanh;
        }
    }
}
