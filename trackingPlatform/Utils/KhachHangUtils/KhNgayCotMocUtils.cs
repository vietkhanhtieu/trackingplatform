using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class KhNgayCotMocUtils
    {
        public static KhNgayCotMoc UpdateKhNgayCotMoc (KhNgayCotMoc oldKhNgayCotMoc, KhNgayCotMoc newKhNgayCotMoc)
        {
            oldKhNgayCotMoc.TenCotMoc = newKhNgayCotMoc.TenCotMoc;
            oldKhNgayCotMoc.NgayDatMoc = newKhNgayCotMoc.NgayDatMoc;
            return oldKhNgayCotMoc;
        }
    }
}
