using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class NhomKinhDoanhUtils
    {
        public static NhomKinhDoanh UpdateNhomKinhDoanh(NhomKinhDoanh oldNkd, NhomKinhDoanh newNkd)
        {
            oldNkd.TenNhomKinhDoanh = newNkd.TenNhomKinhDoanh;
            oldNkd.KyHieuVietTat = newNkd.KyHieuVietTat;
            oldNkd.YNghia = newNkd.YNghia;
            oldNkd.GhiChu = newNkd.GhiChu;

            return oldNkd;
        }
    }
}
