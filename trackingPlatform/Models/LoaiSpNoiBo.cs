using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class LoaiSpNoiBo : BaseModel
{
    public string MaLoaiSpNoiBo { get; set; } = null!;

    public string? TenLoaiSpNoiBo { get; set; }

    public string? KyHieuVietTat { get; set; }

    public string? GhiChu { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
