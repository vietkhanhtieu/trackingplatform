﻿namespace trackingPlatform.Models.Request.CreateUpdateSanPham
{
    public class SP_GhiChuSanPhamRequest
    {
        public string MaSanPham { get; set; } = null!;

        public string MaGhiChu { get; set; } = null!;

        public string? GhiChu1 { get; set; }

        public string? GhiChu2 { get; set; }

        public string? GhiChu3 { get; set; }
    }
}
