using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class DinhHuongSanPham : BaseModel
{
    public string MaDinhHuong { get; set; } = null!;

    public string? TenDinhHuong { get; set; }

    public string? MoTa { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
