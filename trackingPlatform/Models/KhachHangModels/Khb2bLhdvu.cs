using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class Khb2bLhdvu 
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string MaLoaiHinhDv { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;

    public virtual LoaiHinhDichVu MaLoaiHinhDvNavigation { get; set; } = null!;
}
