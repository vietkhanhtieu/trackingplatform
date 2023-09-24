using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.Request.SanPhamRequest
{
    public class HubRequest
    {
        public string MaHub { get; set; } = null!;

        public string? MaPhiVanChuyen { get; set; }

        public string? TenHub { get; set; }

        public int? SoNha { get; set; }

        public string? TenDuong { get; set; }

        public string? QuanHuyen { get; set; }

        public string? TinhTp { get; set; }

        public string? Sdt { get; set; }

        public string? TenNguoiDaiDienHub { get; set; }

        public double? PhiVanChuyenNoi { get; set; }

        public double? PhiVanChuyenNgoai { get; set; }

        public virtual ICollection<TonkhoTheohub> TonkhoTheohubs { get; } = new List<TonkhoTheohub>();
    }
}
