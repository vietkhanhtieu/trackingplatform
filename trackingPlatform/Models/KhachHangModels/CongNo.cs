using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class CongNo : BaseModel
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string MaCongNo { get; set; } = null!;

    public DateOnly? ThoiHanCongNo { get; set; }

    public double? HanMucCongNo { get; set; }

    public string? DanhGia { get; set; }

    public string? GhiChu { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
