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
        [JsonIgnore]
        public string? MaDangBaoChe { get; set; }

        [BindNever]
        [JsonIgnore]
        public string? MaDinhHuong { get; set; }

        [BindNever]
        public string? MaChuSoHuu { get; set; }

        [BindNever]
        [JsonIgnore]
        public string? MaNhomKinhDoanh { get; set; }

        [BindNever]
        [JsonIgnore]
        public string? MaDkbq { get; set; }

        [BindNever]
        [JsonIgnore]
        public string? MaNhomKiemSoat { get; set; }

        [BindNever]
        [JsonIgnore]
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
        [JsonIgnore]
        public string? MaLoaiSpNoiBo { get; set; }

        [BindNever]
        public string? MaLoaiSp { get; set; }

        [BindNever]
        public string? HinhAnh { get; set; }

        [BindNever]
        public string? TrangThai { get; set; }

        [BindNever]
        [JsonIgnore]

        public string? MaGop { get; set; }

        [BindNever]
        public virtual ICollection<SP_CanhGiacDuocRequest> CanhGiacDuocs { get; set; } = new List<SP_CanhGiacDuocRequest>();

        [BindNever]
        public virtual ICollection<SP_GhiChuSanPhamRequest> GhiChuSps { get; set; } = new List<SP_GhiChuSanPhamRequest>();

        [BindNever]
        public virtual DangBaoChe? DangBaoChe { get; set; }

        [BindNever]
        public virtual DinhHuongSanPham? DinhHuongSanPham { get; set; }

        [BindNever]
        public virtual DieuKienBaoQuan DieuKienBaoQuan { get; set; }

        [BindNever]
        public virtual DonViTinh? DonViTinh { get; set; }

        [BindNever]
        public virtual SanPhamGop? SanPhamGop { get; set; }

        [BindNever]
        [JsonIgnore]
        public virtual LoaiSp? LoaiSp { get; set; }

        [BindNever]
        public virtual LoaiSpNoiBo? LoaiSpNoiBo { get; set; }

        [BindNever]
        public virtual NhomKiemSoat? NhomKiemSoat { get; set; }


        [BindNever]
        public virtual NhomKinhDoanh? NhomKinhDoanh { get; set; }

        [BindNever]
        public virtual ICollection<SP_ThongTinChinhRequest> ThongTinChinhs { get; set; } = new List<SP_ThongTinChinhRequest>();

        [BindNever]
        public virtual ICollection<SP_ThongTinNguonGocRequest> ThongTinNguonGocs { get; set; } = new List<SP_ThongTinNguonGocRequest>();

        [BindNever]
        public virtual ICollection<SP_ThongTinNoiBoRequest> ThongTinNoiBos { get; set; } = new List<SP_ThongTinNoiBoRequest>();

        [BindNever]
        public virtual ICollection<SP_ThongTinPhapLyRequest> ThongTinPhapLies { get; set; } = new List<SP_ThongTinPhapLyRequest>();

    }
}
