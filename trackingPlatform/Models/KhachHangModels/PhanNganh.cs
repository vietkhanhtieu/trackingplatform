using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class PhanNganh : BaseModel
{
    public string MaPhanNganh { get; set; } = null!;

    public string? PhanNganh1 { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<KhachHangB2b> KhachHangB2bs { get; } = new List<KhachHangB2b>();
}
