using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
{
    public class HubUtils
    {
        public static Hub UpdateHub(Hub oldHub, Hub newHub)
        {
            oldHub.TenHub = newHub.TenHub;
            oldHub.SoNha = newHub.SoNha;
            oldHub.TenDuong = newHub.TenDuong;
            oldHub.QuanHuyen = newHub.QuanHuyen;
            oldHub.TinhTp = newHub.TinhTp;
            oldHub.Sdt = newHub.Sdt;
            oldHub.PhiVanChuyenNoi = newHub.PhiVanChuyenNoi;
            oldHub.PhiVanChuyenNgoai = newHub.PhiVanChuyenNgoai;
            return oldHub;
        }
    }
}
