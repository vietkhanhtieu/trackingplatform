using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class NguoiDaiDienPhapLy : BaseModel
{
    public string MaNguoiDaiDien { get; set; } = null!;

    public string? TenNguoiDaiDien { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; } = new List<KhachHangB2b>();
}
