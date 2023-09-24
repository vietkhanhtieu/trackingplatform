using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class KhachHangB2CUtils
    {
        public static KhachHangB2c UpdateKhachHangB2c(KhachHangB2c oldKhachHangB2c, KhachHangB2c newKhachHangB2c)
        {
            oldKhachHangB2c.MoTa = newKhachHangB2c.MoTa;
            return oldKhachHangB2c;
        }
    }
}
