using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ThongTinGppServices
    {
        private readonly ThongTinGppRepositoryServices _ThongTinGppRepositoryServices;
        private readonly IMapper _mapper;

        public ThongTinGppServices(ThongTinGppRepositoryServices thongTinGppRepositoryServices, IMapper mapper)
        {
            _ThongTinGppRepositoryServices = thongTinGppRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ThongTinGpp> GetThongTinGpp(string maThongTinGpp)
        {
            return await _ThongTinGppRepositoryServices.FindByMaThongTinGpp(maThongTinGpp);

        }

        public async Task<IEnumerable<ThongTinGpp>> GetAllThongTinGpp(int top, int skip, string? filter)
        {
            return await _ThongTinGppRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinGpp thongTinGpp)
        {
            await _ThongTinGppRepositoryServices.AddAsync(thongTinGpp);
        }

        public async Task<ThongTinGpp> DeleteAsync(string maThongTinGpp)
        {
            ThongTinGpp thongTinGpp = await GetThongTinGpp(maThongTinGpp);
            if (thongTinGpp != null)
            {
                await _ThongTinGppRepositoryServices.DeleteAsync(thongTinGpp);
            }
            return thongTinGpp;
        }

        public async Task<PostDto> AddorUpdateThongTinGpp(List<ThongTinGppRequest> thongTinGppRequests)
        {
            List<ThongTinGpp> thongTinGpps = _mapper.Map<List<ThongTinGpp>>(thongTinGppRequests);
            return await _ThongTinGppRepositoryServices.AddorUpdateThongTinGpps(thongTinGpps);
        }
    }
}
