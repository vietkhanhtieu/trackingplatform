using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class ChuyenKhoa : BaseModel
{
    public string MaChuyenKhoa { get; set; } = null!;

    public string? TenChuyenKhoa { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; } = new List<Khb2bCkhoa>();
}
