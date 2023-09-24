using System;
using System.Collections.Generic;
using trackingPlatform.Models.KhachHangModel;

namespace trackingPlatform.Models.GiaoDichModels;

public partial class DonHang
{
    public string MaSoDonHang { get; set; } = null!;

    public DateOnly? NgayLapDonHang { get; set; }

    public DateOnly? NgayGiaoHang { get; set; }

    public string? LuuYKhachHang { get; set; }

    public bool? XuatHoaDon { get; set; }

    public bool? TachDon { get; set; }

    public double? TongThue { get; set; }

    public string? TrangThaiDonHang { get; set; }

    public bool? TrangThaiThanhToan { get; set; }

    public double? TongGiaTri { get; set; }

    public string? MaHoaDon { get; set; }

    public string? SoNha { get; set; }

    public string? TenDuong { get; set; }

    public string? QuanHuyen { get; set; }

    public string? ThanhPho { get; set; }

    public int? SoLanGiaoHang { get; set; }

    public string? GhiChu { get; set; }

    public string? MaPhuongThuc { get; set; }

    public string? MaGiaoDichNganHang { get; set; }

    public string? MaVoucher { get; set; }

    public string? MaKhachHang { get; set; }

    public string MaChiPhiVanChuyen { get; set; } = null!;

    public virtual ICollection<LichSuDonHang> LichSuDonHangs { get; } = new List<LichSuDonHang>();

    public virtual ChiPhiVanChuyen MaChiPhiVanChuyenNavigation { get; set; } = null!;

    public virtual Khachhang? MaKhachHangNavigation { get; set; }

    public virtual PhuongThucThanhToan? MaPhuongThucNavigation { get; set; }

    public virtual Voucher? MaVoucherNavigation { get; set; }

    public virtual ICollection<SanPhamDonHang> SanPhamDonHangs { get; } = new List<SanPhamDonHang>();
}
