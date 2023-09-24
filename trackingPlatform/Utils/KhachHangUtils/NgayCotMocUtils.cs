using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class NgayCotMocUtils
    {
        public static NgayCotMoc UpdateNgayCotMoc(NgayCotMoc oldNgayCotMoc, NgayCotMoc newNgayCotMoc)
        {
            oldNgayCotMoc.NoiDung = newNgayCotMoc.NoiDung;
            oldNgayCotMoc.MoTa = newNgayCotMoc.MoTa;
            return oldNgayCotMoc;

        }
    }
}
