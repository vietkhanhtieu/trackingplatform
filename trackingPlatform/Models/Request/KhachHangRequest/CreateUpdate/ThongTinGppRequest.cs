using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class ThongTinGppRequest
    {
        public string MaTtGpp { get; set; } = null!;

        public string? SoChungNhanGpp { get; set; }

        public DateOnly? NgayCap { get; set; }

        public DateOnly? NgayHetHan { get; set; }

        public int? HoatDong { get; set; }

        public string? HinhAnh { get; set; }

        public string? FilePdf { get; set; }
        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; }
    }
}
