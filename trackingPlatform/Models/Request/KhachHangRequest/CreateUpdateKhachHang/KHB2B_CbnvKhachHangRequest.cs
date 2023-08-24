using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_CbnvKhachHangRequest
    {
        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; }

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
        [JsonIgnore]
        public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
    }
}
