using System;
using System.Collections.Generic;
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModel;

public partial class Khachhang
{
    public string MaKhachHang { get; set; } = null!;

    public string? MaKhachHangGonsa { get; set; }

    public string? MaKhachHangEc { get; set; }

    public string? MaKhachHangOcs { get; set; }

    public string? TenKhachHang { get; set; }

    public int? DuocDuyet { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public int? TrangThaiHoatDong { get; set; }

    public string? CodeMonet { get; set; }

    public string? DoUuTien { get; set; }

    public string? GhiChu { get; set; }

    public string? TenChuNhaThuoc { get; set; }

    public string? SonhaTenduong { get; set; }

    public string? PhuongxaQuanhuyen { get; set; }

    public string? ThanhphoTinh { get; set; }

    public string? Giayphepkinhdoanh { get; set; }

    public DateOnly? Ngaythanhlap { get; set; }

    public int? Baohiemthanhtoan { get; set; }

    public string? MaLoaiThe { get; set; }

    public string? MaTtXuatHd { get; set; }

    public string? MaPhanHang { get; set; }

    public string? MaPhanNganh { get; set; }

    public string? MaNhom { get; set; }

    public string? MaNguoiDaiDien { get; set; }

    public int? LaNcc { get; set; }

    public int? LaCsh { get; set; }

    public int? LaKhdv { get; set; }

    public int? LaPartner { get; set; }

    public bool? LaNhaBan { get; set; }

    public virtual ICollection<ChiNhanh> ChiNhanhs { get; } = new List<ChiNhanh>();

    public virtual ICollection<CongNo> CongNos { get; } = new List<CongNo>();

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();

    public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; } = new List<Khb2bCkhoa>();

    public virtual LoaiTheThanhVien? MaLoaiTheNavigation { get; set; }

    public virtual NguoiDaiDienPhapLy? MaNguoiDaiDienNavigation { get; set; }

    public virtual NhomKhachHang? MaNhomNavigation { get; set; }

    public virtual PhanHang? MaPhanHangNavigation { get; set; }

    public virtual PhanNganh? MaPhanNganhNavigation { get; set; }

    public virtual ThongTinXuatHoaDon? MaTtXuatHdNavigation { get; set; }

    public virtual ICollection<NhomKiemSoatDacBiet> NhomKiemSoatDacBiets { get; } = new List<NhomKiemSoatDacBiet>();

    public virtual ICollection<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; } = new List<SanPhamKinhDoanh>();

    public virtual ICollection<ThongTinGdp> ThongTinGdps { get; } = new List<ThongTinGdp>();

    public virtual ICollection<ThongTinGpp> ThongTinGpps { get; } = new List<ThongTinGpp>();

    public virtual ICollection<ThongTinThue> ThongTinThues { get; } = new List<ThongTinThue>();
}
