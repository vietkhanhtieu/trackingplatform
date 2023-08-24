using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class CanhGiacDuoc : BaseModel
{
    public string MaCdg { get; set; } = null!;



    public string MaSanPham { get; set; } = null!;

    public string? TuongTacThuoc { get; set; }

    public string? CongDung { get; set; }

    public string? CanhGiacDuoc1 { get; set; }

    public string? TacDungPhu { get; set; }

    [JsonIgnore]
    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
