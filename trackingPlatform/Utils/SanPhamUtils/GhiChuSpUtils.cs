using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
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
        public static GhiChuSp UpdateGhiChuSpRequest(GhiChuSp oldGhiChuSp, SP_GhiChuSanPhamRequest newGhiChuSp)
        {
            oldGhiChuSp.GhiChu1 = newGhiChuSp.GhiChu1;
            oldGhiChuSp.GhiChu2 = newGhiChuSp.GhiChu2;
            oldGhiChuSp.GhiChu3 = newGhiChuSp.GhiChu3;
            return oldGhiChuSp;
        }
    }
}
