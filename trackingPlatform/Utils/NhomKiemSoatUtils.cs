using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class NhomKiemSoatUtils
    {
        public static NhomKiemSoat UpdateNhomKiemSoat(NhomKiemSoat oldNks, NhomKiemSoat newNks)
        {
            oldNks.TenNhomKiemSoat = newNks.TenNhomKiemSoat;
            oldNks.YNghia = newNks.YNghia;
            oldNks.GhiChu = newNks.GhiChu;

            return oldNks;
        }
    }
}
