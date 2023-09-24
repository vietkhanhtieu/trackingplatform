using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class GiaSanPham
{
    public string MaGiaSanPham { get; set; } = null!;

    public double? GiaBan { get; set; }

    public TimeOnly? GioCapNhatGia { get; set; }

    public DateOnly? NgayCapNhatGia { get; set; }

    public string? MaSanPham { get; set; }

    public int? GiamGiaPhanTram { get; set; }

    public string? GhiChu { get; set; }

    public virtual SanPhamKinhDoanh? MaSanPhamNavigation { get; set; }
}
