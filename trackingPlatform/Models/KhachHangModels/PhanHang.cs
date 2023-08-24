using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class PhanHang : BaseModel
{
    public string MaPhanHang { get; set; } = null!;

    public string? Hang { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; } = new List<KhachHangB2b>();
}
