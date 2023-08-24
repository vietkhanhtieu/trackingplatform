using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.KhachHangModels;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public int? DuocDuyet { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public int? TrangThaiHoatDong { get; set; }

    public string? CodeMonet { get; set; }

    public string? MaKhachHangB2b { get; set; }

    public string? MaKhachHangB2c { get; set; }

    public string? MaPhuongThuc { get; set; }

    public string? MaKhoQuaTang { get; set; }

    public string? MaLoaiThe { get; set; }

    public string? MaTtXuatHd { get; set; }

    public string? MaKhachHangGonsa { get; set; }

    public string? DoUuTien { get; set; }

    public string? GhiChu { get; set; }

    public string? TenChuNhaThuoc { get; set; }

    public string? DiaChi { get; set; }
    [JsonIgnore]
    public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
    [JsonIgnore]
    public virtual KhachHangB2c? MaKhachHangB2cNavigation { get; set; }
    [JsonIgnore]
    public virtual LoaiTheThanhVien? MaLoaiTheNavigation { get; set; }
    [JsonIgnore]
    public virtual PhuongThucLienLac? MaPhuongThucNavigation { get; set; }
    [JsonIgnore]
    public virtual ThongTinXuatHoaDon? MaTtXuatHdNavigation { get; set; }
}
