using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class NguoiDaiDienPhapLy
{
    public string MaNguoiDaiDien { get; set; } = null!;

    public string? TenNguoiDaiDien { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
