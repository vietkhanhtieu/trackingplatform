using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class GhiChuSp : BaseModel
{
    public string MaSanPham { get; set; } = null!;

    public string MaGhiChu { get; set; } = null!;

    public string? GhiChu1 { get; set; }

    public string? GhiChu2 { get; set; }

    public string? GhiChu3 { get; set; }
    [JsonIgnore]
    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
