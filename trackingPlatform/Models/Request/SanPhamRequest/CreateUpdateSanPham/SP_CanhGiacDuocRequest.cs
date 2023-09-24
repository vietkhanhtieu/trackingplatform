using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham
{
    public class SP_CanhGiacDuocRequest
    {
        [JsonIgnore]
        public string? MaSanPham { get; set; }
        public string MaCdg { get; set; } = null!;
        public string? TuongTacThuoc { get; set; }

        public string? CongDung { get; set; }

        public string? CanhGiacDuoc1 { get; set; } = null!;

        public string? TacDungPhu { get; set; }
    }
}
