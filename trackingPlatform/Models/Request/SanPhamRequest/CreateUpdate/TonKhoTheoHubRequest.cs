namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class TonKhoTheoHubRequest
    {
        public string MaTonkhotheohub { get; set; } = null!;

        public string? MaSanPham { get; set; }

        public string? MaNhaBan { get; set; }

        public string? MaHub { get; set; }

        public double? SoLuongTonKho { get; set; }

        public DateOnly? NgayCapNhatTonKho { get; set; }

        public TimeOnly? GioCapNhatTonKho { get; set; }

        public string? GhiChu { get; set; }
    }
}
