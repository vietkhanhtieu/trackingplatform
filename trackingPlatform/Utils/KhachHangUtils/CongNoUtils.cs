
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class CongNoUtils
    {
        public static CongNo UpdateCongNo(CongNo oldCongNo, CongNo newCongNo)
        {
            oldCongNo.ThoiHanCongNo = newCongNo.ThoiHanCongNo;
            oldCongNo.HanMucCongNo = newCongNo.HanMucCongNo;
            oldCongNo.DanhGia = newCongNo.DanhGia;
            oldCongNo.GhiChu = newCongNo.GhiChu;
            return oldCongNo;

        }
        public static CongNo UpdateCongNoRequest(CongNo oldCongNo, KHB2B_CongNoRequest newCongNo)
        {
            oldCongNo.ThoiHanCongNo = newCongNo.ThoiHanCongNo;
            oldCongNo.HanMucCongNo = newCongNo.HanMucCongNo;
            oldCongNo.DanhGia = newCongNo.DanhGia;
            oldCongNo.GhiChu = newCongNo.GhiChu;
            return oldCongNo;

        }
    }
}
