using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class NhomKhachHangB2b : BaseModel
{
    public string MaNhom { get; set; } = null!;

    public string? TenNhom { get; set; }

    public string? KyHieuVietTat { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; } = new List<KhachHangB2b>();
}
