using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham
{
    public class SP_ThongTinChinhRequest
    {

        [JsonIgnore]
        public string? MaSanPham { get; set; }

        public string MaTcc { get; set; } = null!;

        public string? HoatChat { get; set; }

        public string? HamLuong { get; set; }

        public string? PhamViPhanPhoi { get; set; }

        public string? DuongDung { get; set; }

        public string? LieuDung { get; set; }

        public string? NhomDieuTri { get; set; }

        public short? HanDung { get; set; }

        public short? KeToa { get; set; }
    }
}
