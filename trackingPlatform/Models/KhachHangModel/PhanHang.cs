using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class PhanHang
{
    public string MaPhanHang { get; set; } = null!;

    public string? Hang { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
