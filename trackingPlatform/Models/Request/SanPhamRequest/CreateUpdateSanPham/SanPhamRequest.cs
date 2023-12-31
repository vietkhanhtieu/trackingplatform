﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
<<<<<<< HEAD
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.KhachHangModel;
=======
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham
{
    public class SanPhamRequest
    {
        [BindRequired]
        public string MaSanPham { get; set; } = null!;

        [BindRequired]
        public string? MaSanPhamGonsa { get; set; }

        public string? MaSanPhamEc { get; set; }

        public string? MaNhaBan { get; set; }

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
        public decimal? DonviHop { get; set; }

        [BindNever]
        public object? AmThanh { get; set; } = null;

        [BindNever]
        public object? GiongNoi { get; set; } = null;

        [BindNever]
        public object? PhienAm { get; set; } = null;

        [BindNever]
        public object? QrCode { get; set; } = null;

        [BindNever]
        [JsonIgnore]
        public string? MaLoaiSpNoiBo { get; set; }

        [BindNever]
        [JsonIgnore]
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
        public virtual DieuKienBaoQuan? DieuKienBaoQuan { get; set; }

        [BindNever]
        public virtual DonViTinh? DonViTinh { get; set; }

        [BindNever]
        public virtual SanPhamGop? SanPhamGop { get; set; }

        [BindNever]
        public virtual LoaiSp? LoaiSp { get; set; }

        [BindNever]
        public virtual LoaiSpNoiBo? LoaiSpNoiBo { get; set; }

        public virtual Khachhang? MaNhaBanNavigation { get; set; }

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

        [JsonIgnore]
        public virtual ICollection<TonkhoTheohub> TonkhoTheohubs { get; } = new List<TonkhoTheohub>();
    }
}
