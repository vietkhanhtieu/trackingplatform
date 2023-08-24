using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class NhomKhachHangB2BRequest
    {
        public string MaNhom { get; set; } = null!;

        public string? TenNhom { get; set; }

        public string? KyHieuVietTat { get; set; }

        public string? MoTa { get; set; }


        [JsonIgnore]
        public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; set; } = new List<KhachHangB2b>();
    }
}
