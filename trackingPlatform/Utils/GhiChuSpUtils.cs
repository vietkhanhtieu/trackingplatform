using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class GhiChuSpUtils
    {
        public static GhiChuSp UpdateGhiChuSp(GhiChuSp oldGhiChuSp, GhiChuSp newGhiChuSp)
        {
            oldGhiChuSp.GhiChu1 = newGhiChuSp.GhiChu1;
            oldGhiChuSp.GhiChu2 = newGhiChuSp.GhiChu2;
            oldGhiChuSp.GhiChu3 = newGhiChuSp.GhiChu3;
            return oldGhiChuSp;

        }
    }
}
