using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class KhachHangB2c : BaseModel
{
    public string MaKhachHangB2c { get; set; } = null!;

    public string? MoTa { get; set; }
    [JsonIgnore]
    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();
}
