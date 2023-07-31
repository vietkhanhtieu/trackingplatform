using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
using trackingPlatform.Models.Request.CreateUpdate;

namespace trackingPlatform.Models.Request.CreateUpdateSanPham
{
    public class SanPhamRequest
    {
        [BindRequired]
        public string MaSanPham { get; set; } = null!;

        [BindRequired]
        public string? MaSanPhamGonsa { get; set; }

        [BindNever]
        public string? MaTichHop { get; set; }

        [BindNever]
        public string? MaRfid { get; set; }

        [BindNever]
        public string? MaDangBaoChe { get; set; }

        [BindNever]
        public string? MaDinhHuong { get; set; }

        [BindNever]
        public string? MaChuSoHuu { get; set; }

        [BindNever]
        public string? MaNhomKinhDoanh { get; set; }

        [BindNever]
        public string? MaDkbq { get; set; }

        [BindNever]
        public string? MaNhomKiemSoat { get; set; }

        [BindNever]
        public string? MaDvt { get; set; }

        [BindNever]
        public string? MaSpNcc { get; set; }

        [BindNever]
        public string? TenSanPham { get; set; }

        [BindNever]
        public string? TenThuongMai { get; set; }

        [BindNever]
        public string? QuyCachDongGoi { get; set; }

        [BindNever]
        public float? ThueVat { get; set; }

        [BindNever]
        public float? GiaKeKhai { get; set; }

        [BindNever]
        public float? GiaCoVat { get; set; }

        [BindNever]
        public int? HanCheBanLe { get; set; }

        [BindNever]
        public int? Active { get; set; }

        [BindNever]
        public long? DonviHop { get; set; }

        [BindNever]
        public string? AmThanh { get; set; }

        [BindNever]
        public string? GiongNoi { get; set; }

        [BindNever]
        public string? PhienAm { get; set; }

        [BindNever]
        public string? QrCode { get; set; }

        [BindNever]
        public string? MaLoaiSpNoiBo { get; set; }

        [BindNever]
        public string? MaLoaiSp { get; set; }

        [BindNever]
        public string? HinhAnh { get; set; }

        [BindNever]
        public string? TrangThai { get; set; }

        [BindNever]
        public string? MaGop { get; set; }

        [BindNever]
        public virtual ICollection<SP_CanhGiacDuocRequest> CanhGiacDuocs { get; set; } = new List<SP_CanhGiacDuocRequest>();

        [BindNever]
        public virtual ICollection<GhiChuSp> GhiChuSps { get;  } = new List<GhiChuSp>();

        [BindNever]
        [JsonIgnore]
        public virtual DangBaoChe? MaDangBaoCheNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual DinhHuongSanPham? MaDinhHuongNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual DieuKienBaoQuan? MaDkbqNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual DonViTinh? MaDvtNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual SanPhamGop? MaGopNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual LoaiSp? MaLoaiSpNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual LoaiSpNoiBo? MaLoaiSpNoiBoNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual NhomKiemSoat? MaNhomKiemSoatNavigation { get; set; }


        [BindNever]
        [JsonIgnore]
        public virtual NhomKinhDoanh? MaNhomKinhDoanhNavigation { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual ICollection<ThongTinChinh> ThongTinChinhs { get;  } = new List<ThongTinChinh>();

        [BindNever]
        [JsonIgnore]
        public virtual ICollection<ThongTinNguonGoc> ThongTinNguonGocs { get;  } = new List<ThongTinNguonGoc>();

        [BindNever]
        [JsonIgnore]
        public virtual ICollection<ThongTinNoiBo> ThongTinNoiBos { get;  } = new List<ThongTinNoiBo>();

        [BindNever]
        [JsonIgnore]
        public virtual ICollection<ThongTinPhapLy> ThongTinPhapLies { get;  } = new List<ThongTinPhapLy>();

    }
}
