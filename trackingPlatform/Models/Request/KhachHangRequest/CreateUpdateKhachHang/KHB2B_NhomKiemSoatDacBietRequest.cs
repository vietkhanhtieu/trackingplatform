using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang
{
    public class KHB2B_NhomKiemSoatDacBietRequest
    {

        [JsonIgnore]
        public string? MaKhachHangB2b { get; set; } 

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
    }
}
