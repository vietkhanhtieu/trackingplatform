using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class ChiNhanh
{
    public string MaChiNhanh { get; set; } = null!;

    public string? TenChiNhanh { get; set; }

    public int? ChiNhanhMe { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? MoiQuanHe { get; set; }

    public string? MaKhachHang { get; set; }

    public string? SonhaTenduong { get; set; }

    public string? PhuongxaQuanhuyen { get; set; }

    public string? ThanhphoTinh { get; set; }

    public virtual Khachhang? MaKhachHangNavigation { get; set; }
}
