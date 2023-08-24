using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class NguoiDaiDienPhapLyRequest
    {
        public string MaNguoiDaiDien { get; set; } = null!;

        public string? TenNguoiDaiDien { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }
        [JsonIgnore]
        public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; set; } = new List<KhachHangB2b>();
    }
}
