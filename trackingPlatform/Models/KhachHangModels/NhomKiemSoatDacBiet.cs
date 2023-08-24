using System;
using System.Collections.Generic;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.KhachHangModels;

public partial class NhomKiemSoatDacBiet : BaseModel
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string MaNksdb { get; set; } = null!;

    public int? ThuocHanCheBanLe { get; set; }

    public int? ThuocTienChat { get; set; }

    public int? NguyenLieuLaDcGayNghienHuongThanPxaTchat { get; set; }

    public int? ThuocPhongXa { get; set; }

    public int? ThuocDocNlieuDocLamThuoc { get; set; }

    public int? CamTrongMotSoLinhVuc { get; set; }

    public int? DangPhChuaDchatHuongThan { get; set; }

    public int? ThuocHuongThan { get; set; }

    public int? ThuocGayNghien { get; set; }

    public int? DangPhChuaDcGayNghien { get; set; }

    public int? DangPhChuaTienChat { get; set; }

    public virtual KhachHangB2b MaKhachHangB2bNavigation { get; set; } = null!;
}
