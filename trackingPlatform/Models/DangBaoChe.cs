using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class DangBaoChe : BaseModel
{
    public string MaDangBaoChe { get; set; } = null!;

    public string? DangBaoChe1 { get; set; } = null!;

    public string? DangBaoCheDacBiet { get; set; }

    public string? MoTa { get; set; }
    [JsonIgnore]
    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
