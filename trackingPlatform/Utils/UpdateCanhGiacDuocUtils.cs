using trackingPlatform.Models;

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
    }
}
