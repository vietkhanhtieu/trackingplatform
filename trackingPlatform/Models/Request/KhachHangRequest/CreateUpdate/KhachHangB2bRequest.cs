
using System.Text.Json.Serialization;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class KhachHangB2bRequest
    {
        public string MaKhachHangB2b { get; set; } = null!;

        public string? GiayPhepKinhDoanh { get; set; }

        public DateOnly? NgayThanhLap { get; set; }

        public int? BaoHiemThanhToan { get; set; }
        [JsonIgnore]
        public string? MaPhanHang { get; set; }
        [JsonIgnore]
        public string? MaPhanNganh { get; set; }
        [JsonIgnore]
        public string? MaNhom { get; set; }
        [JsonIgnore]
        public string? MaNguoiDaiDien { get; set; }

        public string? MaKhachHangGonsa { get; set; }

        public int? LaNcc { get; set; }

        public int? LaCsh { get; set; }

        public int? LaKhdv { get; set; }

        public int? LaPartner { get; set; }


        public virtual ICollection<KHB2B_CbnvKhachHangRequest> CbnvKhachHangs { get; set; } = new List<KHB2B_CbnvKhachHangRequest>();
        [JsonIgnore]
        public virtual ICollection<KHB2B_CbnvKhachHangRequest> CbnvgonsaKhb2bs { get; set; } = new List<KHB2B_CbnvKhachHangRequest>();
       
        public virtual ICollection<KHB2B_ChiNhanhRequest> ChiNhanhs { get; set; } = new List<KHB2B_ChiNhanhRequest>();

        public virtual ICollection<KHB2B_CongNoRequest> CongNos { get; set; } = new List<KHB2B_CongNoRequest>();

        [JsonIgnore]
        public virtual ICollection<KhNgayCotMoc> KhNgayCotMocs { get; set; } = new List<KhNgayCotMoc>();

        [JsonIgnore]
        public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

        [JsonIgnore]
        public virtual ICollection<Khb2bCkhoa> Khb2bCkhoas { get; set; } = new List<Khb2bCkhoa>();

        [JsonIgnore]
        public virtual ICollection<Khb2bLhdvu> Khb2bLhdvus { get; set; } = new List<Khb2bLhdvu>();
    
        public virtual NguoiDaiDienPhapLy? NguoiDaiDien { get; set; }
        public virtual NhomKhachHangB2b? NhomKhachHangB2b { get; set; }
        
        public virtual PhanHang? PhanHang { get; set; }
        
        public virtual PhanNganh? PhanNganh { get; set; }

        
        public virtual ICollection<KHB2B_NguoiNhanTtHdonRequest> NguoiNhanTtHdons { get; set; } = new List<KHB2B_NguoiNhanTtHdonRequest>();

        
        public virtual ICollection<KHB2B_NhomKiemSoatDacBietRequest> NhomKiemSoatDacBiets { get; set; } = new List<KHB2B_NhomKiemSoatDacBietRequest>();

        public virtual ICollection<KHB2B_ThongTinGdpRequest> ThongTinGdps { get; set; } = new List<KHB2B_ThongTinGdpRequest>();

        public virtual ICollection<KHB2B_ThongTinGppRequest> ThongTinGpps { get; set; } = new List<KHB2B_ThongTinGppRequest>();

        public virtual ICollection<KHB2B_ThongTinThueRequest> ThongTinThues { get; set; } = new List<KHB2B_ThongTinThueRequest>();
    }
}
