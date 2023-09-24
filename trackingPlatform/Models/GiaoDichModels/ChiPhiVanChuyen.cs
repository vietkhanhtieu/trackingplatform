using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class ChiPhiVanChuyen
{
    public string MaChiPhiVanChuyen { get; set; } = null!;

    public string? TinhGiao { get; set; }

    public string? TinhNhan { get; set; }

    public DateOnly? ThoiGianDuKien { get; set; }

    public double? ChiPhiDuKien { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();
}
