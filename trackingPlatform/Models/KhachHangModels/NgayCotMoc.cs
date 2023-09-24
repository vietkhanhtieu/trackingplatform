using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class NgayCotMoc : BaseModel
{
    public string MaCotMoc { get; set; } = null!;

    public string? NoiDung { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<KhNgayCotMoc> KhNgayCotMocs { get; } = new List<KhNgayCotMoc>();
}
