using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class LoaiTheThanhVienRequest
    {
        public string MaLoaiThe { get; set; } = null!;

        public string? TenLoaiThe { get; set; }

        public string? KyHieuVietTat { get; set; }


        [JsonIgnore]
        public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();
    }
}
