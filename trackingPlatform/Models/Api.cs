using System;
using System.Collections.Generic;

namespace trackingPlatform.Models;

public partial class Api
{
    public string IdApi { get; set; } = null!;

    public string? UrlApi { get; set; }

    public string? MaNhomApi { get; set; }

    public short? EnableApi { get; set; }

    public string? GhiChu { get; set; }

    public string? ApiParameters { get; set; }

    public virtual NhomApi? MaNhomApiNavigation { get; set; }

    public virtual ICollection<RoleApiUser> RoleApiUsers { get; } = new List<RoleApiUser>();
}
