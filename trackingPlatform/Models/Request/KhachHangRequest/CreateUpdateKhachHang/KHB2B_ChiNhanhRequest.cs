namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_ChiNhanhRequest
    {
        public string MaChiNhanh { get; set; } = null!;

        public string? TenChiNhanh { get; set; }

        public int? ChiNhanhMe { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public string? MoiQuanHe { get; set; }

        public string? MaKhachHangB2b { get; set; }

        public string? DiaChi { get; set; }
    }
}
