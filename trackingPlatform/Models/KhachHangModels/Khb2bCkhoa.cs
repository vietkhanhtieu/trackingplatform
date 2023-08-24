using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class Khb2bCkhoa 
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string MaChuyenKhoa { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ChuyenKhoa MaChuyenKhoaNavigation { get; set; } = null!;

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
