﻿namespace trackingPlatform.Models.Request.CreateUpdateSanPham
{
    public class SP_ThongTinPhapLyRequest
    {

        public string MaSanPham { get; set; } = null!;
        public string MaTtpl { get; set; } = null!;
        public int? SttTheoTt3015 { get; set; }

        public int? SttTheoTt15 { get; set; }

        public int? NhomTheoTt3015 { get; set; }

        public int? NhomTheoTt15 { get; set; }
    }
}
