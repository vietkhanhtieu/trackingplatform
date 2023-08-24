using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class ChiNhanh : BaseModel
{
    public string MaChiNhanh { get; set; } = null!;

    public string? TenChiNhanh { get; set; }

    public int? ChiNhanhMe { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? MoiQuanHe { get; set; }

    public string? MaKhachHangB2b { get; set; }

    public string? DiaChi { get; set; }

    public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
}
