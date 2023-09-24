using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class NguoiNhanTtHdon : BaseModel
{
    public string MaNguoiNhan { get; set; } = null!;

    public string? TenNguoiNhan { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? MaKhachHangB2b { get; set; }

    public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
}
