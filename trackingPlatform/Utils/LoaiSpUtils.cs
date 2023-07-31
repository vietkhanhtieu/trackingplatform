using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class LoaiSpUtils
    {
        public static LoaiSp UpdateLoaiSp(LoaiSp oldLsp, LoaiSp newLsp)
        {
            oldLsp.TenLoaiSp = newLsp.TenLoaiSp;
            oldLsp.DinhNghia = newLsp.DinhNghia;
            oldLsp.MaDanhMucLsp = newLsp.MaDanhMucLsp;
            return oldLsp;
        }
    }
}
