using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class LoSanPham
{
    public string MaLo { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public DateOnly? NgayNhap { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public string? GhiChu { get; set; }

    public virtual SanPhamKinhDoanh? MaSanPhamNavigation { get; set; }
}
