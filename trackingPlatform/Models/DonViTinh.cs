using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models;

public partial class DonViTinh : BaseModel
{
    public string MaDvt { get; set; } = null!;

    public string? DvtCoSo { get; set; }
    [JsonIgnore]

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();
}
