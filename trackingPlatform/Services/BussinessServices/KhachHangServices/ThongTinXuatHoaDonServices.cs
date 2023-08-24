using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ThongTinXuatHoaDonServices
    {
        private readonly ThongTinXuatHoaDonRepositoryServices _thongTinXuatHoaDonRepositoryServices;
        private readonly IMapper _mapper;

        public ThongTinXuatHoaDonServices(ThongTinXuatHoaDonRepositoryServices thongTinXuatHoaDonRepositoryServices, IMapper mapper)
        {
            _thongTinXuatHoaDonRepositoryServices = thongTinXuatHoaDonRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ThongTinXuatHoaDon> GetThongTinXuatHoaDon(string maThongTinXuatHoaDon)
        {
            return await _thongTinXuatHoaDonRepositoryServices.FindByMaThongTinXuatHoaDon(maThongTinXuatHoaDon);

        }

        public async Task<IEnumerable<ThongTinXuatHoaDon>> GetAllThongTinXuatHoaDon(int top, int skip, string? filter)
        {
            return await _thongTinXuatHoaDonRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinXuatHoaDon thongTinXuatHoaDon)
        {
            await _thongTinXuatHoaDonRepositoryServices.AddAsync(thongTinXuatHoaDon);
        }

        public async Task<ThongTinXuatHoaDon> DeleteAsync(string maThongTinXuatHoaDon)
        {
            ThongTinXuatHoaDon thongTinXuatHoaDon = await GetThongTinXuatHoaDon(maThongTinXuatHoaDon);
            if (thongTinXuatHoaDon != null)
            {
                await _thongTinXuatHoaDonRepositoryServices.DeleteAsync(thongTinXuatHoaDon);
            }
            return thongTinXuatHoaDon;
        }

        public async Task<PostDto> AddorUpdateThongTinXuatHoaDon(List<ThongTinXuatHoaDonRequest> thongTinXuatHoaDonRequests)
        {
            List<ThongTinXuatHoaDon> thongTinXuatHoaDons = _mapper.Map<List<ThongTinXuatHoaDon>>(thongTinXuatHoaDonRequests);
            return await _thongTinXuatHoaDonRepositoryServices.AddorUpdateThongTinXuatHoaDons(thongTinXuatHoaDons);
        }
    }
}
