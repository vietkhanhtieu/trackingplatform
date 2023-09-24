namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class NguoiNhanTtHoaDonRequest
    {
        public string MaNguoiNhan { get; set; } = null!;

        public string? TenNguoiNhan { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public string? MaKhachHangB2b { get; set; }
    }
}
