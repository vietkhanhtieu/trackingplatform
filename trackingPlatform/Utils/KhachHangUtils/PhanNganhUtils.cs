using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class PhanNganhUtils
    {
        public static PhanNganh UpdatePhanNganh(PhanNganh oldPhanNganh, PhanNganh newPhanNganh)
        {
            oldPhanNganh.PhanNganh1 = newPhanNganh.PhanNganh1;
            oldPhanNganh.MoTa = newPhanNganh.MoTa;
            return oldPhanNganh;
        }
    }
}
