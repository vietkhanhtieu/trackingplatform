using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class CbnvKhachHang : BaseModel
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string MaCbnvKh { get; set; } = null!;

    public string? TenCbnv { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? ChucVu { get; set; }

    public string? PhongBan { get; set; }

    public int? GioiTinh { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? HinhAnh { get; set; }

    public string? GhiChu { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
