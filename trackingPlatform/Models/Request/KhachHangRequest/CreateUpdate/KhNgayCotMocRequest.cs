namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class KhNgayCotMocRequest
    {
        public string MaKhachHangB2b { get; set; } = null!;
        public string MaCotMoc { get; set; } = null!;

        public DateOnly? NgayDatMoc { get; set; }

        public string? TenCotMoc { get; set; }

    }
}
