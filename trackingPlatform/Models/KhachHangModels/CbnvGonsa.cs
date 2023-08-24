using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModels;

public partial class CbnvGonsa
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public string? PhongBan { get; set; }

    public string? ChucVu { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public virtual ICollection<CbnvgonsaKhb2b> CbnvgonsaKhb2bs { get; } = new List<CbnvgonsaKhb2b>();
}
