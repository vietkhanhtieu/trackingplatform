using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class DangBaoCheUtils
    {
        public static DangBaoChe UpdateDangBaoChe(DangBaoChe oldDbc, DangBaoChe newDbc)
        {
            oldDbc.DangBaoChe1 = newDbc.DangBaoChe1;
            oldDbc.DangBaoCheDacBiet = newDbc.DangBaoCheDacBiet;
            oldDbc.MoTa = newDbc.MoTa;
            return oldDbc;
        }
    }
}
