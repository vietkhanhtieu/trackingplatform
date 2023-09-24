using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class LoaiTheThanhVien
{
    public string MaLoaiThe { get; set; } = null!;

    public string? TenLoaiThe { get; set; }

    public string? KyHieuVietTat { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
