using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class CongNo
{
    public string MaKhachHang { get; set; } = null!;

    public string MaCongNo { get; set; } = null!;

    public DateOnly? ThoiHanCongNo { get; set; }

    public double? HanMucCongNo { get; set; }

    public string? DanhGia { get; set; }

    public string? GhiChu { get; set; }

    public virtual Khachhang MaKhachHangNavigation { get; set; } = null!;
}
