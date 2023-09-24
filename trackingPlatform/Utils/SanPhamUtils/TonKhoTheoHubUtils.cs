using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
{
    public class TonKhoTheoHubUtils
    {
        public static TonkhoTheohub UpdateTonKhoTheoHub(TonkhoTheohub oldTonkhoTheohub, TonkhoTheohub newTonkhoTheohub)
        {
            oldTonkhoTheohub.NgayCapNhatTonKho = newTonkhoTheohub.NgayCapNhatTonKho;
            oldTonkhoTheohub.SoLuongTonKho = newTonkhoTheohub.SoLuongTonKho;
            oldTonkhoTheohub.GhiChu = newTonkhoTheohub.GhiChu;
            return oldTonkhoTheohub;

        }
    }
}
