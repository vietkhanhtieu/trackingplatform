using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class NhomKiemSoat : BaseModel
{
    public string MaNhomKiemSoat { get; set; } = null!;

    public string? TenNhomKiemSoat { get; set; }

    public string? YNghia { get; set; }

    public string? GhiChu { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
