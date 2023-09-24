using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_NguoiNhanTtHdonRequest
    {
        
        public string MaNguoiNhan { get; set; } = null!;

        public string? TenNguoiNhan { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }
        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; }
    }
}
