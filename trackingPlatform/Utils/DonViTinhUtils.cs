using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class DonViTinhUtils
    {
        public static DonViTinh UpdateDonViTinh(DonViTinh oldDvt, DonViTinh newDvt)
        {
            oldDvt.DvtCoSo = newDvt.DvtCoSo;
            return oldDvt;
        }
    }
}
