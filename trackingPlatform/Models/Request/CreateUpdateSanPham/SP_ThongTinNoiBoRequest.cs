namespace trackingPlatform.Models.Request.CreateUpdateSanPham
{
    public class SP_ThongTinNoiBoRequest
    {
        public string MaSanPham { get; set; } = null!;

        public string MaTtnb { get; set; } = null!;

        public DateOnly? NgayTao { get; set; }

        public string? UserTao { get; set; }

        public DateOnly? NgayNgungSanPham { get; set; }

        public DateOnly? NgaySinhNhatSp { get; set; }

        public string? TheoDoiSanPham { get; set; }

        public string? QuanLySanPham { get; set; }

        public string? TrangThaiHoSo { get; set; }

        public short? LamToRoiHayKhong { get; set; }

        public short? XinCapPhepQc { get; set; }

        public short? DaDuocCapPhepTtThuocQc { get; set; }

        public short? TinhTrangToRoiNcc { get; set; }
    }
}
