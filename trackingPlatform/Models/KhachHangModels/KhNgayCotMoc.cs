using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class KhNgayCotMoc
{
    public string MaCotMoc { get; set; } = null!;

    public DateOnly? NgayDatMoc { get; set; }

    public string? TenCotMoc { get; set; }

    public string MaKhachHangB2b { get; set; } = null!;

    public virtual NgayCotMoc MaCotMocNavigation { get; set; } = null!;

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
