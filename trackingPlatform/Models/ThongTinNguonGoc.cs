using System;
using System.Collections.Generic;

namespace trackingPlatform.Models;

public partial class ThongTinNguonGoc
{
    public string MaSanPham { get; set; } = null!;

    public string MaTtng { get; set; } = null!;

    public string? SoDangKy { get; set; }

    public string? SoQdGiaHan { get; set; }

    public DateOnly? HieuLucSdk { get; set; }

    public string? NuocSanXuat { get; set; }

    public string? NhaSanXuat { get; set; }

    public string? XuatXu { get; set; }

    public string? TieuChuanSanXuat { get; set; }

    public short? SdkVoThoiHan { get; set; }

    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
