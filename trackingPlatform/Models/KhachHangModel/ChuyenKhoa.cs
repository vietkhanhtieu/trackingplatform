using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.KhachHangModel;

public partial class ChuyenKhoa
{
    public string MaChuyenKhoa { get; set; } = null!;

    public string? TenChuyenKhoa { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; } = new List<Khb2bCkhoa>();
}
