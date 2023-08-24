using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class DangBaoCheRequest
    {
        [BindRequired]
        public string MaDangBaoChe { get; set; } = null!;
        [BindNever]
        public string DangBaoChe1 { get; set; } = null!;
        [BindNever]

        public string? DangBaoCheDacBiet { get; set; }
        [BindNever]

        public string? MoTa { get; set; }

    }
}
