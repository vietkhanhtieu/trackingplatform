using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class Khb2bLhdvuUtils
    {
        public static Khb2bLhdvu UdpateKhb2bLhdvu(Khb2bLhdvu oldKh, Khb2bLhdvu newKh)
        {
            oldKh.GhiChu = newKh.GhiChu;
            return oldKh;
        }
    }
}
