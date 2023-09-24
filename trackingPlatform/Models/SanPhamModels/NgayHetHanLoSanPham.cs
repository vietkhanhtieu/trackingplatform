using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class NgayHetHanLoSanPham
{
    public string? MaLo { get; set; }

    public string? MaSanPham { get; set; }

    public DateOnly? NgaySanXuat { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public short? HanDung { get; set; }
}
