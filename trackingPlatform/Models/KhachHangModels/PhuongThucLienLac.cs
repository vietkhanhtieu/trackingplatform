
using System.Text.Json.Serialization;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class PhuongThucLienLac : BaseModel
{
    public string MaPhuongThuc { get; set; } = null!;

    public string? PhuongThuc { get; set; }

    public string? MoTa { get; set; }
    [JsonIgnore]
    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();
}
