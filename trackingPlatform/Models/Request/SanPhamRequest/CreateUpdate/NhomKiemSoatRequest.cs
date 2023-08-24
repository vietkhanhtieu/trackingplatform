using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class NhomKiemSoatRequest
    {

        [BindNever]
        public string MaNhomKiemSoat { get; set; } = null!;

        [BindRequired]
        public string? TenNhomKiemSoat { get; set; }

        public string? YNghia { get; set; }

        public string? GhiChu { get; set; }
    }
}
