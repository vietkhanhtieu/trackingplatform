using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class PhuongThucThanhToan
{
    public string MaPhuongThuc { get; set; } = null!;

    public string? TenPhuongThuc { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();
}
