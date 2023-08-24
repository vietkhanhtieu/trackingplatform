using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class KhachHangB2cRequest
    {
        public string MaKhachHangB2c { get; set; } = null!;

        public string? MoTa { get; set; }

        [JsonIgnore]
        public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();
    }
}
