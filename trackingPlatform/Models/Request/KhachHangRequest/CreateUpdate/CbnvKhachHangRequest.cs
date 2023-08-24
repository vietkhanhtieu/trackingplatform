namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class CbnvKhachHangRequest
    {
        public string MaKhachHangB2b { get; set; } = null!;

        public string MaCbnvKh { get; set; } = null!;

        public string? TenCbnv { get; set; }

        public DateOnly? NgaySinh { get; set; }

        public string? ChucVu { get; set; }

        public string? PhongBan { get; set; }

        public int? GioiTinh { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public string? HinhAnh { get; set; }

        public string? GhiChu { get; set; }
    }
}
