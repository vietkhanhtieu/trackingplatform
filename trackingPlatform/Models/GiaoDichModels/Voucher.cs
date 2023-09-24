using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class Voucher
{
    public string MaVoucher { get; set; } = null!;

    public double? GiaGiam { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();
}
