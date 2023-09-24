using System.Text.Json.Serialization;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class CanhGiacDuocRequest
    {

        public string MaSanPham { get; set; } = null!;

        public string MaCdg { get; set; } = null!;

        public string? TuongTacThuoc { get; set; }

        public string? CongDung { get; set; }

        public string? CanhGiacDuoc1 { get; set; }

        public string? TacDungPhu { get; set; }
    }
}
