namespace trackingPlatform.Models.Request.CreateUpdate
{
    public class GhiChuSpRequest
    {
        public string MaSanPham { get; set; } = null!;

        public string MaGhiChu { get; set; } = null!;

        public string? GhiChu1 { get; set; }

        public string? GhiChu2 { get; set; }

        public string? GhiChu3 { get; set; }

    }
}
