using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class LoaiHinhDichVu : BaseModel
{
    public string MaLoaiHinhDv { get; set; } = null!;

    public string? LoaiHinhDv { get; set; }

    public string? KyHieuVietTat { get; set; }

    public string? PhiDichVu { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khb2bLhdvu> Khb2bLhdvus { get; } = new List<Khb2bLhdvu>();
}
