using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class ThongTinXuatHoaDon
{
    public string MaTtXuatHd { get; set; } = null!;

    public string? TenNguoiMuaHang { get; set; }

    public string? TenDonVi { get; set; }

    public string? TenKhachHangXuatHoaDon { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? LuuY { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; } = new List<Khachhang>();
}
