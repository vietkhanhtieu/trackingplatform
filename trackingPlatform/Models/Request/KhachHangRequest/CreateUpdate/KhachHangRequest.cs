using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class KhachHangRequest
    {
        public string MaKhachHang { get; set; } = null!;

        public string? TenKhachHang { get; set; }

        public int? DuocDuyet { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public int? TrangThaiHoatDong { get; set; }

        public string? CodeMonet { get; set; }

        public string? MaKhachHangB2b { get; set; }

        [JsonIgnore]
        public string? MaKhachHangB2c { get; set; }

        [JsonIgnore]
        public string? MaPhuongThuc { get; set; }
        public string? MaKhoQuaTang { get; set; }

        [JsonIgnore]
        public string? MaLoaiThe { get; set; }

        [JsonIgnore]
        public string? MaTtXuatHd { get; set; }

        public string? MaKhachHangGonsa { get; set; }

        public string? DoUuTien { get; set; }

        public string? GhiChu { get; set; }

        public string? TenChuNhaThuoc { get; set; }

        public string? DiaChi { get; set; }
        [JsonIgnore]
        public virtual KhachHangB2b? MaKhachHangB2bNavigation { get; set; }
      
        public virtual KhachHangB2c? KhachHangB2c { get; set; }
      
        public virtual LoaiTheThanhVien? LoaiTheThanhVien { get; set; }

        public virtual PhuongThucLienLac? PhuongThucLienLac { get; set; }
  
        public virtual ThongTinXuatHoaDon? ThongTinXuatHoaDon { get; set; }
    }
}
