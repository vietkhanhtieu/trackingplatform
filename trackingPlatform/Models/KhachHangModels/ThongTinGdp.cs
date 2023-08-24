using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class ThongTinGdp : BaseModel
{
    public string MaTtGdp { get; set; } = null!;

    public string? SoChungNhanGdp { get; set; }

    public DateOnly? NgayCap { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public int? HoatDong { get; set; }

    public string? HinhAnh { get; set; }

    public string? FilePdf { get; set; }

    public string? MaKhachHangB2b { get; set; }

    public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
}
