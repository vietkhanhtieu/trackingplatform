using System;
using System.Collections.Generic;

namespace trackingPlatform.Models;

public partial class RoleApiUser
{
    public string Username { get; set; } = null!;

    public string IdApi { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual Api IdApiNavigation { get; set; } = null!;

    public virtual UserMiddleware UsernameNavigation { get; set; } = null!;
}
