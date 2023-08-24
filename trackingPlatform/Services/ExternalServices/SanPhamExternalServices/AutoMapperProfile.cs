using AutoMapper;
using System.Runtime.InteropServices;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Services.ExternalServices.SanPhamExternalServices
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
            CreateMap<SP_CanhGiacDuocRequest, CanhGiacDuoc>();
            CreateMap<GhiChuSpRequest, GhiChuSp>();
            CreateMap<SP_ThongTinNguonGocRequest, ThongTinNguonGoc>();
            CreateMap<ThongTinNguonGocRequest, ThongTinNguonGoc>();
            CreateMap<SP_GhiChuSanPhamRequest, GhiChuSp>();
            CreateMap<ThongTinChinhRequest, ThongTinChinh>();
            CreateMap<SP_ThongTinChinhRequest, ThongTinChinh>();
            CreateMap<SP_ThongTinNoiBoRequest, ThongTinNoiBo>();
            CreateMap<ThongTinNoiBoRequest, ThongTinNoiBo>();
            CreateMap<ThongTinPhapLyRequest, ThongTinPhapLy>();
            CreateMap<SP_ThongTinPhapLyRequest, ThongTinPhapLy>();

            CreateMap<string, byte[]>().ConvertUsing<StringToByteArrayTypeConverter>();


        }
    }

    public class StringToByteArrayTypeConverter : ITypeConverter<string, byte[]>
    {
        public byte[] Convert(string source, byte[] destination, ResolutionContext context)
        {
            return System.Convert.FromBase64String(source);
        }
    }
}
