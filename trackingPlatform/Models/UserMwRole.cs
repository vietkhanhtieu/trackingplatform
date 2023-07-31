using System;
using System.Collections.Generic;

namespace trackingPlatform.Models;

public partial class UserMwRole
{
    public string Marole { get; set; } = null!;

    public string? Tenrole { get; set; }

    public string? MaForm { get; set; }

    public string? GhiChu { get; set; }

    public virtual MwForm? MaFormNavigation { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
