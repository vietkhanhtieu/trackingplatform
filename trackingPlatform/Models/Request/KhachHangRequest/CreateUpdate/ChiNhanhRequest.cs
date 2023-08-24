using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class ChiNhanhRequest
    {
        public string MaChiNhanh { get; set; } = null!;

        public string? TenChiNhanh { get; set; }

        public int? ChiNhanhMe { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public string? MoiQuanHe { get; set; }

        public string? MaKhachHangB2b { get; set; }

        public string? DiaChi { get; set; }
        [JsonIgnore]
        public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
    }
}
