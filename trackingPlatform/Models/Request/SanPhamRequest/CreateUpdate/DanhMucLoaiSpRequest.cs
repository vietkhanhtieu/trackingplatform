using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
{
    public class DanhMucLoaiSpRequest
    {
        [BindNever]
        public string MaDanhMucLsp { get; set; } = null!;

        [BindRequired]
        public string? TenDanhMucLsp { get; set; }

        public string? DinhNghia { get; set; }

        public virtual ICollection<LoaiSpRequest> LoaiSps { get; } = new List<LoaiSpRequest>();
    }
}
