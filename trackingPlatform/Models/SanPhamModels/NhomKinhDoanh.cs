using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class NhomKinhDoanh : BaseModel
{
    public string MaNhomKinhDoanh { get; set; } = null!;

    public string? TenNhomKinhDoanh { get; set; }

    public string? KyHieuVietTat { get; set; }

    public string? YNghia { get; set; }

    public string? GhiChu { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
