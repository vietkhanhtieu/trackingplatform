using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class SanPhamGopRequest
    {
        [BindNever]
        public string MaGop { get; set; } = null!;
        [BindRequired]
        public string? GhiChu { get; set; }
    }
}
