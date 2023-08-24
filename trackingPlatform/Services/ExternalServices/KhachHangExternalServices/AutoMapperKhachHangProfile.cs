using AutoMapper;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Services.ExternalServices.KhachHangExternalServices
{
    public class AutoMapperKhachHangProfile : Profile
    {
        public AutoMapperKhachHangProfile()
        {
            CreateMap<PhuongThucLienLacRequest, PhuongThucLienLac>();
            CreateMap<KhachHangB2cRequest, KhachHangB2c>();
            CreateMap<ThongTinXuatHoaDonRequest, ThongTinXuatHoaDon>();
            CreateMap<LoaiTheThanhVienRequest, LoaiTheThanhVien>();
            CreateMap<NhomKiemSoatDatBietRequest, NhomKiemSoatDacBiet>();
            CreateMap<PhanHangRequest, PhanHang>();
            CreateMap<PhanNganhRequest, PhanNganh>();
            CreateMap<NhomKhachHangB2BRequest, NhomKhachHangB2b>();
            CreateMap<NguoiDaiDienPhapLyRequest, NguoiDaiDienPhapLy>();
            CreateMap<LoaiHinhDichVuRequest, LoaiHinhDichVu>();
            CreateMap<NgayCotMocRequest, NgayCotMoc>();
            CreateMap<ChuyenKhoaRequest, ChuyenKhoa>();
            CreateMap<KhachHangB2bRequest, KhachHangB2b>();
            CreateMap<KHB2B_NhomKiemSoatDacBietRequest, NhomKiemSoatDacBiet>();
            CreateMap<NguoiNhanTtHoaDonRequest, NguoiNhanTtHdon>();
            CreateMap<KHB2B_NguoiNhanTtHdonRequest, NguoiNhanTtHdon>();
            CreateMap<ThongTinGdpRequest, ThongTinGdp>();
            CreateMap<KHB2B_ThongTinGdpRequest, ThongTinGdp>();
            CreateMap<ThongTinGppRequest, ThongTinGpp>();
            CreateMap<KHB2B_ThongTinGppRequest, ThongTinGpp>();
            CreateMap<KHB2B_ThongTinThueRequest, ThongTinThue>();
            CreateMap<ThongTinThueRequest, ThongTinThue>();
            CreateMap<CbnvKhachHangRequest, CbnvKhachHang>();
            CreateMap<KHB2B_CbnvKhachHangRequest, CbnvKhachHang>();
            CreateMap<ChiNhanhRequest, ChiNhanh>();
            CreateMap<KHB2B_ChiNhanhRequest, ChiNhanh>();
            CreateMap<CongNoRequest, CongNo>();
            CreateMap<KHB2B_CongNoRequest, CongNo>();
            CreateMap<KhachHangRequest, KhachHang>();
            CreateMap<Khb2bLhdvuRequest, Khb2bLhdvu>();
            CreateMap<KhNgayCotMocRequest, KhNgayCotMoc>();
            CreateMap<Khb2bCkhoaRequest, Khb2bCkhoa>();
        }
    }
}
