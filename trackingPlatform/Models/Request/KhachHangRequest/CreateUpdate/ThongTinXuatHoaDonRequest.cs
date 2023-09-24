namespace trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate
{
    public class ThongTinXuatHoaDonRequest
    {
        public string MaTtXuatHd { get; set; } = null!;

        public string? TenNguoiMuaHang { get; set; }

        public string? TenDonVi { get; set; }

        public string? TenKhachHangXuatHoaDon { get; set; }

        public string? Email { get; set; }

        public string? SoDt { get; set; }

        public string? LuuY { get; set; }

        public string? DiaChi { get; set; }
    }
}
