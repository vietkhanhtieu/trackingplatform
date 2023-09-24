using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.SanPhamModels;

public partial class ThongTinChinh : BaseModel
{
    public string MaSanPham { get; set; } = null!;

    public string MaTcc { get; set; } = null!;

    public string? HoatChat { get; set; }

    public string? HamLuong { get; set; }

    public string? PhamViPhanPhoi { get; set; }

    public string? DuongDung { get; set; }

    public string? LieuDung { get; set; }

    public string? NhomDieuTri { get; set; }

    public short? HanDung { get; set; }

    public short? KeToa { get; set; }

    public string? MaAtc { get; set; }

    public bool? HangGiaTot { get; set; }

    public double? GiaBanMoi { get; set; }
    [JsonIgnore]
    public virtual SanPhamKinhDoanh MaSanPhamNavigation { get; set; } = null!;
}
