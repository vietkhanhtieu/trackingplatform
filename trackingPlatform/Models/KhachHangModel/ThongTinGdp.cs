using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class ThongTinGdp
{
    public string MaTtGdp { get; set; } = null!;

    public string? SoChungNhanGdp { get; set; }

    public DateOnly? NgayCap { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public int? HoatDong { get; set; }

    public string? HinhAnh { get; set; }

    public string? FilePdf { get; set; }

    public string? MaKhachHang { get; set; }

    public virtual Khachhang? MaKhachHangNavigation { get; set; }
}
