using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models.Request.CreateUpdateSanPham;

namespace trackingPlatform.Utils
{
    public class UpdateCanhGiacDuocUtils
    {
        public static CanhGiacDuoc UpdateCanhGiacDuoc(CanhGiacDuoc oldCanhGiacDuoc, CanhGiacDuoc newCanhGiacDuoc)
        {
            oldCanhGiacDuoc.TuongTacThuoc = newCanhGiacDuoc.TuongTacThuoc;
            oldCanhGiacDuoc.TacDungPhu = newCanhGiacDuoc .TacDungPhu;
            oldCanhGiacDuoc.CanhGiacDuoc1 = newCanhGiacDuoc.CanhGiacDuoc1;
            oldCanhGiacDuoc.CongDung = newCanhGiacDuoc.CongDung;
            return oldCanhGiacDuoc;
        }

        public static CanhGiacDuoc UpdateCanhGiacDuocRequest(CanhGiacDuoc oldCanhGiacDuoc, SP_CanhGiacDuocRequest newCanhGiacDuoc)
        {
            oldCanhGiacDuoc.TuongTacThuoc = newCanhGiacDuoc.TuongTacThuoc;
            oldCanhGiacDuoc.TacDungPhu = newCanhGiacDuoc.TacDungPhu;
            oldCanhGiacDuoc.CanhGiacDuoc1 = newCanhGiacDuoc.CanhGiacDuoc1;
            oldCanhGiacDuoc.CongDung = newCanhGiacDuoc.CongDung;
            return oldCanhGiacDuoc;
        }
    }
}
