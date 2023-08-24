using System;
using System.Collections.Generic;

namespace trackingPlatform.Models.SanPhamModels;

public partial class UserMiddleware
{
    public string Username { get; set; } = null!;

    public string? Passwd { get; set; }

    public string? MaNhanVien { get; set; }

    public string? UserPrivilege { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<RoleApiUser> RoleApiUsers { get; } = new List<RoleApiUser>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
