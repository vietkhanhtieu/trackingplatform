using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.CreateUpdate
{
    public class LoaiSpRequest
    {

        [BindNever]
        public string MaLoaiSp { get; set; } = null!;
        [BindRequired]
        public string? TenLoaiSp { get; set; }
        [BindNever]

        public string? DinhNghia { get; set; }
        [BindNever]

        public string? MaDanhMucLsp { get; set; }
        [BindNever]

        public virtual DanhMucLoaiSp? MaDanhMucLspNavigation { get; set; }

    }
}
