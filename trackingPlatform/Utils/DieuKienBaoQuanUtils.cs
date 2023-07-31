using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class DieuKienBaoQuanUtils
    {
        public static DieuKienBaoQuan UpdateDieuKienBaoQuan(DieuKienBaoQuan oldDkbq, DieuKienBaoQuan newDkbq)
        {
            oldDkbq.DieuKienBaoQuan1 = newDkbq.DieuKienBaoQuan1;
            oldDkbq.MoTa = newDkbq.MoTa;
            return oldDkbq;
        }
    }
}
