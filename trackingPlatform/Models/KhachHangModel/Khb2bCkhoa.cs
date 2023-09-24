using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class Khb2bCkhoa
{
    public string MaKhachHang { get; set; } = null!;

    public string MaChuyenKhoa { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ChuyenKhoa MaChuyenKhoaNavigation { get; set; } = null!;

    public virtual Khachhang MaKhachHangNavigation { get; set; } = null!;
}
