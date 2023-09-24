using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class MwForm
{
    public string MaForm { get; set; } = null!;

    public string? TenForm { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<UserMwRole> UserMwRoles { get; } = new List<UserMwRole>();
}
