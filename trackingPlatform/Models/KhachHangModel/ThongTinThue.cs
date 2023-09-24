using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class ThongTinThue
{
    public string MaTtThue { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string? MaSoThue { get; set; }

    public int? XacNhanThue { get; set; }

    public int? HoatDong { get; set; }

    public virtual Khachhang MaKhachHangNavigation { get; set; } = null!;
}
