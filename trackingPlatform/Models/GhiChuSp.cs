using System;
using System.Collections.Generic;

namespace trackingPlatform.Models;

public partial class GhiChuSp
{
    public string MaSanPham { get; set; } = null!;

    public string MaGhiChu { get; set; } = null!;

    public string? GhiChu1 { get; set; }

    public string? GhiChu2 { get; set; }

    public string? GhiChu3 { get; set; }

    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
