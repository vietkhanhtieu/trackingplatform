using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class CongNoRequest
    {
        public string MaKhachHangB2b { get; set; } = null!;

        public string MaCongNo { get; set; } = null!;

        public DateOnly? ThoiHanCongNo { get; set; }

        public double? HanMucCongNo { get; set; }

        public string? DanhGia { get; set; }

        public string? GhiChu { get; set; }
    }
}
