using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class TonkhoTheohub : BaseModel
{
    public string MaSanPham { get; set; } = null!;

    public string? MaNhaBan { get; set; }

    public string MaHub { get; set; } = null!;

    public double? SoLuongTonKho { get; set; }

    public DateOnly? NgayCapNhatTonKho { get; set; }

    public TimeOnly? GioCapNhatTonKho { get; set; }

    public string? GhiChu { get; set; }

    public virtual Hub MaHubNavigation { get; set; } = null!;

    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
