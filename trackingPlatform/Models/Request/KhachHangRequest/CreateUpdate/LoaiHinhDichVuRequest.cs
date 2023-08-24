using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class LoaiHinhDichVuRequest
    {
        public string MaLoaiHinhDv { get; set; } = null!;

        public string? LoaiHinhDv { get; set; }

        public string? KyHieuVietTat { get; set; }

        public string? PhiDichVu { get; set; }

        public string? MoTa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Khb2bLhdvu> Khb2bLhdvus { get; set; } = new List<Khb2bLhdvu>();
    }
}
