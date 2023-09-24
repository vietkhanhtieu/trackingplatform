using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class UserRole
{
    public string Username { get; set; } = null!;

    public string Marole { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual UserMwRole MaroleNavigation { get; set; } = null!;

    public virtual UserMiddleware UsernameNavigation { get; set; } = null!;
}
