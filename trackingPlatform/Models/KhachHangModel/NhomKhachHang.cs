using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class NhomKhachHang
{
    public string MaNhom { get; set; } = null!;

    public string? TenNhom { get; set; }

    public string? KyHieuVietTat { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
