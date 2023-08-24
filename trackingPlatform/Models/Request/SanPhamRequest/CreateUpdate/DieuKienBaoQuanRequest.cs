using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class DieuKienBaoQuanRequest
    {
        [BindNever]
        public string MaDkbq { get; set; } = null!;

        [BindRequired]
        public string? DieuKienBaoQuan1 { get; set; }

        public string? MoTa { get; set; }
    }
}
