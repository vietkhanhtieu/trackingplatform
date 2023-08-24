using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_ThongTinThueRequest
    {
        public string MaTtThue { get; set; } = null!;

        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; }

        public string? MaSoThue { get; set; }

        public int? XacNhanThue { get; set; }

        public int? HoatDong { get; set; }
    }
}
