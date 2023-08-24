using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class LoaiTheThanhVien : BaseModel
{
    public string MaLoaiThe { get; set; } = null!;

    public string? TenLoaiThe { get; set; }

    public string? KyHieuVietTat { get; set; }
    [JsonIgnore]
    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();
}
