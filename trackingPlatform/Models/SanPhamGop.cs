using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class SanPhamGop : BaseModel
{
    public string MaGop { get; set; } = null!;

    public string? GhiChu { get; set; }
    [JsonIgnore]
    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
