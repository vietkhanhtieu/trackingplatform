using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class PhanHangUtils
    {
        public static PhanHang UpdatePhanHang(PhanHang oldPhanHang, PhanHang newPhanHang)
        {
            oldPhanHang.Hang = newPhanHang.Hang;
            oldPhanHang.MoTa = newPhanHang.MoTa;
            return oldPhanHang;
        }
    }
}
