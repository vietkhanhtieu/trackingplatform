using AutoMapper;
using System.Runtime.InteropServices;
using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models.Request.CreateUpdateSanPham;

namespace trackingPlatform.Service.ExternalServices
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<DangBaoCheRequest, DangBaoChe>();
            CreateMap<DinhHuongSanPhamRequest, DinhHuongSanPham>();
            CreateMap<NhomKinhDoanhRequest, NhomKinhDoanh>();
            CreateMap<DieuKienBaoQuanRequest, DieuKienBaoQuan>();
            CreateMap<NhomKiemSoatRequest, NhomKiemSoat>();
            CreateMap<DonViTinhRequest, DonViTinh>();
            CreateMap<LoaiSanPhamNoiBoRequest, LoaiSpNoiBo>();
            CreateMap<LoaiSpRequest, LoaiSp>();
            CreateMap<SanPhamGopRequest, SanPhamGop>();
            CreateMap<DanhMucLoaiSpRequest, DanhMucLoaiSp>();
            CreateMap<SanPhamRequest, SanPhamKinhDoanh>();
            CreateMap<CanhGiacDuocRequest, CanhGiacDuoc>();


        }
    }
}
