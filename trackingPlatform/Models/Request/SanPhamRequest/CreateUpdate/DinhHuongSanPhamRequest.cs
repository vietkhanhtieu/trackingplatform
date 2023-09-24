using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class DinhHuongSanPhamRequest
    {

        [BindNever]
        public string MaDinhHuong { get; set; } = null!;
        [BindRequired]

        public string? TenDinhHuong { get; set; }

        public string? MoTa { get; set; }
    }
}
