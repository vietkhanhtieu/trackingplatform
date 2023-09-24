using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class LoaiSanPhamNoiBoRequest
    {
        [BindNever]
        public string MaLoaiSpNoiBo { get; set; } = null!;
        [BindRequired]
        public string? TenLoaiSpNoiBo { get; set; }

        public string? KyHieuVietTat { get; set; }

        public string? GhiChu { get; set; }
    }
}
