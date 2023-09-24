using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class ThongTinXuatHoaDon : BaseModel
{
    public string MaTtXuatHd { get; set; } = null!;

    public string? TenNguoiMuaHang { get; set; }

    public string? TenDonVi { get; set; }

    public string? TenKhachHangXuatHoaDon { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? LuuY { get; set; }

    public string? DiaChi { get; set; }
    [JsonIgnore]

    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();
}
