using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class NhomApi
{
    public string MaNhomApi { get; set; } = null!;

    public string? TenNhomApi { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<Api> Apis { get; } = new List<Api>();
}
