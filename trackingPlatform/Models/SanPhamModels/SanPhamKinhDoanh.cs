using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.KhachHangModel;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace trackingPlatform.Models.SanPhamModels;

public partial class SanPhamKinhDoanh
{
    public string MaSanPham { get; set; } = null!;

    public string? MaSanPhamGonsa { get; set; }

    public string? MaSanPhamEc { get; set; }

    public string? MaNhaBan { get; set; }

    public string? MaTichHop { get; set; }

    public string? MaRfid { get; set; }

    public string? MaDangBaoChe { get; set; }

    public string? MaDinhHuong { get; set; }

    public string? MaChuSoHuu { get; set; }

    public string? MaNhomKinhDoanh { get; set; }

    public string? MaDkbq { get; set; }

    public string? MaNhomKiemSoat { get; set; }

    public string? MaDvt { get; set; }

    public string? MaSpNcc { get; set; }

    public string? TenSanPham { get; set; }

    public string? TenThuongMai { get; set; }

    public string? QuyCachDongGoi { get; set; }

    public float? ThueVat { get; set; }

    public float? GiaKeKhai { get; set; }

    public float? GiaCoVat { get; set; }

    public int? HanCheBanLe { get; set; }

    public int? Active { get; set; }

    public double? DonviHop { get; set; }

    public byte[]? AmThanh { get; set; }

    public byte[]? GiongNoi { get; set; }

    public byte[]? PhienAm { get; set; }

    public byte[]? QrCode { get; set; }

    public string? MaLoaiSpNoiBo { get; set; }

    public string? MaLoaiSp { get; set; }

    public string? HinhAnh { get; set; }

    public string? TrangThai { get; set; }

    public string? MaGop { get; set; }

    public virtual ICollection<CanhGiacDuoc> CanhGiacDuocs { get; } = new List<CanhGiacDuoc>();

    public virtual ICollection<DanhGiaSanPham> DanhGiaSanPhams { get; } = new List<DanhGiaSanPham>();

    public virtual ICollection<GhiChuSp> GhiChuSps { get; } = new List<GhiChuSp>();

    public virtual ICollection<GiaSanPham> GiaSanPhams { get; } = new List<GiaSanPham>();

    public virtual ICollection<LoSanPham> LoSanPhams { get; } = new List<LoSanPham>();

    public virtual DangBaoChe? MaDangBaoCheNavigation { get; set; }

    public virtual DinhHuongSanPham? MaDinhHuongNavigation { get; set; }

    public virtual DieuKienBaoQuan? MaDkbqNavigation { get; set; }

    public virtual DonViTinh? MaDvtNavigation { get; set; }

    public virtual SanPhamGop? MaGopNavigation { get; set; }

    public virtual LoaiSp? MaLoaiSpNavigation { get; set; }

    public virtual LoaiSpNoiBo? MaLoaiSpNoiBoNavigation { get; set; }

    public virtual Khachhang? MaNhaBanNavigation { get; set; }

    public virtual NhomKiemSoat? MaNhomKiemSoatNavigation { get; set; }

    public virtual NhomKinhDoanh? MaNhomKinhDoanhNavigation { get; set; }

    public virtual ICollection<SanPhamDonHang> SanPhamDonHangs { get; } = new List<SanPhamDonHang>();

    public virtual ICollection<ThongTinChinh> ThongTinChinhs { get; } = new List<ThongTinChinh>();

    public virtual ICollection<ThongTinNguonGoc> ThongTinNguonGocs { get; } = new List<ThongTinNguonGoc>();

    public virtual ICollection<ThongTinNoiBo> ThongTinNoiBos { get; } = new List<ThongTinNoiBo>();

    public virtual ICollection<ThongTinPhapLy> ThongTinPhapLies { get; } = new List<ThongTinPhapLy>();

    public virtual ICollection<TonkhoTheohub> TonkhoTheohubs { get; } = new List<TonkhoTheohub>();
}
