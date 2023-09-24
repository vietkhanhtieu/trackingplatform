using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class ThongTinThueRequest
    {
        public string MaTtThue { get; set; } = null!;

        public string MaKhachHangB2b { get; set; } = null!;

        public string? MaSoThue { get; set; }

        public int? XacNhanThue { get; set; }

        public int? HoatDong { get; set; }
    }
}
