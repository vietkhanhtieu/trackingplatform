using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.CreateUpdate
{
    public class NhomKinhDoanhRequest
    {
        [BindNever]
        public string MaNhomKinhDoanh { get; set; } = null!;

        [BindRequired]
        public string? TenNhomKinhDoanh { get; set; }

        public string? KyHieuVietTat { get; set; }

        public string? YNghia { get; set; }

        public string? GhiChu { get; set; }
    }
}
