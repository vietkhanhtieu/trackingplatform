using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class PhanHangRequest
    {
        public string MaPhanHang { get; set; } = null!;

        public string? Hang { get; set; }

        public string? MoTa { get; set; }
        [JsonIgnore]
        public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; set; } = new List<KhachHangB2b>();
    }
}
