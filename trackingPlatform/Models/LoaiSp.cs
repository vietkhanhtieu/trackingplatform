using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class LoaiSp : BaseModel
{
    public string MaLoaiSp { get; set; } = null!;

    public string? TenLoaiSp { get; set; }

    public string? DinhNghia { get; set; }

    public string? MaDanhMucLsp { get; set; }

    public virtual DanhMucLoaiSp? MaDanhMucLspNavigation { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
