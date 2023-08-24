using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class ThongTinThue : BaseModel
{
    public string MaTtThue { get; set; } = null!;

    public string MaKhachHangB2b { get; set; } = null!;

    public string? MaSoThue { get; set; }

    public int? XacNhanThue { get; set; }

    public int? HoatDong { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
