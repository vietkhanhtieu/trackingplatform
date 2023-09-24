using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class SanPhamDonHang
{
    public string MaSanPhamDonHang { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public string? MaSoDonHang { get; set; }

    public int? SoLuong { get; set; }

    public virtual SanPhamKinhDoanh? MaSanPhamNavigation { get; set; }

    public virtual DonHang? MaSoDonHangNavigation { get; set; }
}
