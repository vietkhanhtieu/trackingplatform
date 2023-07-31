using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.CreateUpdate
{
    public class DangBaoCheRequest
    {
        [BindNever]
        public string MaDangBaoChe { get; set; } = null!;
        [BindRequired]
        public string? DangBaoChe1 { get; set; } = null!;

        public string? DangBaoCheDacBiet { get; set; }

        public string? MoTa { get; set; }

    }
}
