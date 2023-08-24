using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate
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
        [JsonIgnore]
        public virtual DanhMucLoaiSp? MaDanhMucLspNavigation { get; set; }

    }
}
