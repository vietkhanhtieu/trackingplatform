using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_CongNoRequest
    {
        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; }

        public string MaCongNo { get; set; } = null!;

        public DateOnly? ThoiHanCongNo { get; set; }

        public double? HanMucCongNo { get; set; }

        public string? DanhGia { get; set; }

        public string? GhiChu { get; set; }
    }
}
