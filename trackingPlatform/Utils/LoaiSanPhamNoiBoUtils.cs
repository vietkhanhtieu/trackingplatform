using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class LoaiSanPhamNoiBoUtils
    {
        public static LoaiSpNoiBo UpdateLoaiSpNoiBo(LoaiSpNoiBo oldLspnb, LoaiSpNoiBo newLspnb)
        {
            oldLspnb.TenLoaiSpNoiBo = newLspnb.TenLoaiSpNoiBo;
            oldLspnb.KyHieuVietTat = newLspnb.KyHieuVietTat;
            oldLspnb.GhiChu = newLspnb.GhiChu;
            return oldLspnb;
        }
      
    }
}
