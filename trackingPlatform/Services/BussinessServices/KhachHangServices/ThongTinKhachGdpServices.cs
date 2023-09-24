using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ThongTinKhachGdpServices
    {
        private readonly ThongTinGdpRepositoryServices _thongTinGdpRepositoryServices;
        private readonly IMapper _mapper;

        public ThongTinKhachGdpServices(ThongTinGdpRepositoryServices thongTinGdpRepositoryServices, IMapper mapper)
        {
            _thongTinGdpRepositoryServices = thongTinGdpRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ThongTinGdp> GetThongTinGdp(string maThongTinGdp)
        {
            return await _thongTinGdpRepositoryServices.FindByMaThongTinGdp(maThongTinGdp);

        }

        public async Task<IEnumerable<ThongTinGdp>> GetAllThongTinGdp(int top, int skip, string? filter)
        {
            return await _thongTinGdpRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinGdp thongTinGdp)
        {
            await _thongTinGdpRepositoryServices.AddAsync(thongTinGdp);
        }

        public async Task<ThongTinGdp> DeleteAsync(string maThongTinGdp)
        {
            ThongTinGdp thongTinGdp = await GetThongTinGdp(maThongTinGdp);
            if (thongTinGdp != null)
            {
                await _thongTinGdpRepositoryServices.DeleteAsync(thongTinGdp);
            }
            return thongTinGdp;
        }

        public async Task<PostDto> AddorUpdateThongTinGdp(List<ThongTinGdpRequest> thongTinGdpRequests)
        {
            List<ThongTinGdp> thongTinGdps = _mapper.Map<List<ThongTinGdp>>(thongTinGdpRequests);
            return await _thongTinGdpRepositoryServices.AddorUpdateThongTinGdps(thongTinGdps);
        }
    }
}
