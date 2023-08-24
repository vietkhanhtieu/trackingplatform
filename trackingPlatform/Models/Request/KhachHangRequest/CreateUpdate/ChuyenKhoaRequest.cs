using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class ChuyenKhoaRequest
    {
        public string MaChuyenKhoa { get; set; } = null!;

        public string? TenChuyenKhoa { get; set; }

        public string? MoTa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; set; } = new List<Khb2bCkhoa>();
    }
}
