namespace trackingPlatform.Models.Request.CreateUpdateSanPham
{
    public class SP_CanhGiacDuocRequest
    {
        public string? TuongTacThuoc { get; set; }

        public string? CongDung { get; set; }

        public string? CanhGiacDuoc1 { get; set; } = null!;

        public string? TacDungPhu { get; set; }
    }
}
