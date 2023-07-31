using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class DieuKienBaoQuan : BaseModel
{
    public string MaDkbq { get; set; } = null!;

    public string? DieuKienBaoQuan1 { get; set; }

    public string? MoTa { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
