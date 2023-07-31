using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.CreateUpdate
{
    public class DonViTinhRequest
    {

        [BindNever]
        public string MaDvt { get; set; } = null!;
        [BindRequired]
        public string? DvtCoSo { get; set; }
    }
}
