using Microsoft.EntityFrameworkCore.Update.Internal;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class Khb2bCkhoaUtils
    {
        public static Khb2bCkhoa UpdateKhb2bCkhoaUtils(Khb2bCkhoa oldKh, Khb2bCkhoa newKh)
        {
            oldKh.GhiChu = newKh.GhiChu;
            return oldKh;
        }
    }
}
