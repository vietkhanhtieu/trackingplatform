using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModels;

public partial class CbnvgonsaKhb2b
{
    public string MaNhanVien { get; set; } = null!;

    public string MaKhachHangB2b { get; set; } = null!;

    public DateOnly? NgayLienHe { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;

    public virtual CbnvGonsa MaNhanVienNavigation { get; set; } = null!;
}
