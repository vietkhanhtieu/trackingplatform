using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class PhuongThucLienLacRequest
    {
        public string MaPhuongThuc { get; set; } = null!;

        public string? PhuongThuc { get; set; }

        public string? MoTa { get; set; }

        [JsonIgnore]
        public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();
    }
}
