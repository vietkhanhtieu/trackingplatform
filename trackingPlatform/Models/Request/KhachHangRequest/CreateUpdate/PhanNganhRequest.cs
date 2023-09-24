using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class PhanNganhRequest
    {
        public string MaPhanNganh { get; set; } = null!;

        public string? PhanNganh1 { get; set; }

        public string? MoTa { get; set; }
        [JsonIgnore]
        public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; set; } = new List<KhachHangB2b>();
    }
}
