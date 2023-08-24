using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trackingPlatform.Models.KhachHangModels;

public partial class KhachHangB2b
{
    public string MaKhachHangB2b { get; set; } = null!;

    public string? GiayPhepKinhDoanh { get; set; }

    public DateOnly? NgayThanhLap { get; set; }

    public int? BaoHiemThanhToan { get; set; }

    public string? MaPhanHang { get; set; }

    public string? MaPhanNganh { get; set; }

    public string? MaNhom { get; set; }

    public string? MaNguoiDaiDien { get; set; }

    public string? MaKhachHangGonsa { get; set; }

    public int? LaNcc { get; set; }

    public int? LaCsh { get; set; }

    public int? LaKhdv { get; set; }

    public int? LaPartner { get; set; }

    public virtual ICollection<CbnvKhachHang> CbnvKhachHangs { get; } = new List<CbnvKhachHang>();

    public virtual ICollection<CbnvgonsaKhb2b> CbnvgonsaKhb2bs { get; } = new List<CbnvgonsaKhb2b>();

    public virtual ICollection<ChiNhanh> ChiNhanhs { get; } = new List<ChiNhanh>();

    public virtual ICollection<CongNo> CongNos { get; } = new List<CongNo>();

    public virtual ICollection<KhNgayCotMoc> KhNgayCotMocs { get; } = new List<KhNgayCotMoc>();

    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();

    public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; } = new List<Khb2bCkhoa>();

    public virtual ICollection<Khb2bLhdvu> Khb2bLhdvus { get; } = new List<Khb2bLhdvu>();
    [JsonIgnore]

    public virtual NguoiDaiDienPhapLy? MaNguoiDaiDienNavigation { get; set; }
    [JsonIgnore]

    public virtual NhomKhachHangB2b? MaNhomNavigation { get; set; }
    [JsonIgnore]

    public virtual PhanHang? MaPhanHangNavigation { get; set; }
    [JsonIgnore]

    public virtual PhanNganh? MaPhanNganhNavigation { get; set; }
    [JsonIgnore]

    public virtual ICollection<NguoiNhanTtHdon> NguoiNhanTtHdons { get; } = new List<NguoiNhanTtHdon>();

    public virtual ICollection<NhomKiemSoatDacBiet> NhomKiemSoatDacBiets { get; } = new List<NhomKiemSoatDacBiet>();

    public virtual ICollection<ThongTinGdp> ThongTinGdps { get; } = new List<ThongTinGdp>();

    public virtual ICollection<ThongTinGpp> ThongTinGpps { get; } = new List<ThongTinGpp>();

    public virtual ICollection<ThongTinThue> ThongTinThues { get; } = new List<ThongTinThue>();
}
