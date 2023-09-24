using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class DanhGiaSanPham
{
    public string MaSanPham { get; set; } = null!;

    public string MaNhaBan { get; set; } = null!;

    public double? Rate { get; set; }

    public string? GhiChu { get; set; }

    public byte[]? Img { get; set; }

    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
