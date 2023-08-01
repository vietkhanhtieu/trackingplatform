using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace trackingPlatform.Models;

public partial class SanPhamKinhDoanh
{
    public string MaSanPham { get; set; } = null!;

    public string? MaSanPhamGonsa { get; set; }

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

    public long? DonviHop { get; set; }

    public byte[]? AmThanh { get; set; }

    public byte[]? GiongNoi { get; set; }

    public byte[]? PhienAm { get; set; }

    public byte[]? QrCode { get; set; }

    public string? MaLoaiSpNoiBo { get; set; }

    public string? MaLoaiSp { get; set; }

    public string? HinhAnh { get; set; }

    public string? TrangThai { get; set; }

    public string? MaGop { get; set; }
    public virtual ICollection<CanhGiacDuoc> CanhGiacDuocs { get; set; } = new List<CanhGiacDuoc>();

    public virtual ICollection<GhiChuSp> GhiChuSps { get; set; } = new List<GhiChuSp>();
    public virtual DangBaoChe? MaDangBaoCheNavigation { get; set; }
    public virtual DinhHuongSanPham? MaDinhHuongNavigation { get; set; }
    public virtual DieuKienBaoQuan? MaDkbqNavigation { get; set; }
    public virtual DonViTinh? MaDvtNavigation { get; set; }
    public virtual SanPhamGop? MaGopNavigation { get; set; }
    public virtual LoaiSp? MaLoaiSpNavigation { get; set; }
    public virtual LoaiSpNoiBo? MaLoaiSpNoiBoNavigation { get; set; }
    public virtual NhomKiemSoat? MaNhomKiemSoatNavigation { get; set; }
    public virtual NhomKinhDoanh? MaNhomKinhDoanhNavigation { get; set; }

    public virtual ICollection<ThongTinChinh> ThongTinChinhs { get; set; } = new List<ThongTinChinh>();

    public virtual ICollection<ThongTinNguonGoc> ThongTinNguonGocs { get; set; } = new List<ThongTinNguonGoc>();

    public virtual ICollection<ThongTinNoiBo> ThongTinNoiBos { get; set; } = new List<ThongTinNoiBo>();

    public virtual ICollection<ThongTinPhapLy> ThongTinPhapLies { get; set; } = new List<ThongTinPhapLy>();
}
