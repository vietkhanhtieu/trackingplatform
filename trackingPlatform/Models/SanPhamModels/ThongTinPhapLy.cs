using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class ThongTinPhapLy : BaseModel
{
    public string MaSanPham { get; set; } = null!;

    public string MaTtpl { get; set; } = null!;

    public int? SttTheoTt3015 { get; set; }

    public int? SttTheoTt15 { get; set; }

    public int? NhomTheoTt3015 { get; set; }

    public int? NhomTheoTt15 { get; set; }
    [JsonIgnore]
    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
