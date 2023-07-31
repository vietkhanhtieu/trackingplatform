using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class SanPhamGopUtils
    {
        public static SanPhamGop UpdateSanPhamGop(SanPhamGop oldsanPhamGop, SanPhamGop newsanPhamGop)
        {

            oldsanPhamGop.GhiChu = newsanPhamGop.GhiChu;

            return oldsanPhamGop;
        }
    }
}
