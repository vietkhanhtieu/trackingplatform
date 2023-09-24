using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class PhanNganh
{
    public string MaPhanNganh { get; set; } = null!;

    public string? PhanNganh1 { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
