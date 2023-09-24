using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class PhuongThucLienLacUtils
    {
        public static PhuongThucLienLac UpdatePhuongThucLienLac(PhuongThucLienLac oldPhuongThucLienLac, PhuongThucLienLac newPhuongThucLienLac)
        {
            oldPhuongThucLienLac.PhuongThuc = newPhuongThucLienLac.PhuongThuc;
            oldPhuongThucLienLac.MoTa = newPhuongThucLienLac.MoTa;
            return oldPhuongThucLienLac;
        }
    }
}
