using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class DanhMucLoaiSp : BaseModel
{
    public string MaDanhMucLsp { get; set; } = null!;

    public string? TenDanhMucLsp { get; set; }

    public string? DinhNghia { get; set; }
    [JsonIgnore]
    public virtual ICollection<LoaiSp> LoaiSps { get; } = new List<LoaiSp>();
}
