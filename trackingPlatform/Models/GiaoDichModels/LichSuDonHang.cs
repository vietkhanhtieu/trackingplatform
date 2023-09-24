using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class LichSuDonHang
{
    public string MaLichSuDonHang { get; set; } = null!;

    public string? MaSoDonHang { get; set; }

    public string? TrangThaiDonHang { get; set; }

    public DateOnly? GioCapNhat { get; set; }

    public TimeOnly? NgayCapNhat { get; set; }

    public virtual DonHang? MaSoDonHangNavigation { get; set; }
}
