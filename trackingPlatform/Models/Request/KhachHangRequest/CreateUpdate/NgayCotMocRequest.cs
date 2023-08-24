using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class NgayCotMocRequest
    {
        public string MaCotMoc { get; set; } = null!;

        public string? NoiDung { get; set; }

        public string? MoTa { get; set; }
        [JsonIgnore]
        public virtual ICollection<KhNgayCotMoc> KhNgayCotMocs { get; set; } = new List<KhNgayCotMoc>();
    }
}
