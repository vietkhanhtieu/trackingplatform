using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ThongTinThueServices
    {
        private readonly ThongTinThueRepositoryServices _thongTinThueRepositoryServices;
        private readonly KhachHangB2bRepositoryServices _khachHangB2BRepositoryServices;
        private readonly IMapper _mapper;

        public ThongTinThueServices(ThongTinThueRepositoryServices thongTinThueRepositoryServices, KhachHangB2bRepositoryServices khachHangB2BRepositoryServices, IMapper mapper)
        {
            _thongTinThueRepositoryServices = thongTinThueRepositoryServices;
            _khachHangB2BRepositoryServices = khachHangB2BRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ThongTinThue> GetThongTinThue(string maThongTinThue)
        {
            return await _thongTinThueRepositoryServices.FindByMaThongTinThue(maThongTinThue);

        }

        public async Task<IEnumerable<ThongTinThue>> GetAllThongTinThue(int top, int skip, string? filter)
        {
            return await _thongTinThueRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinThue thongTinThue)
        {
            await _thongTinThueRepositoryServices.AddAsync(thongTinThue);
        }

        public async Task<ThongTinThue> DeleteAsync(string maThongTinThue)
        {
            ThongTinThue thongTinThue = await GetThongTinThue(maThongTinThue);
            if (thongTinThue != null)
            {
                await _thongTinThueRepositoryServices.DeleteAsync(thongTinThue);
            }
            return thongTinThue;
        }

        public async Task<PostDto> AddorUpdateThongTinThue(List<ThongTinThueRequest> thongTinThueRequests)
        {
            List<ThongTinThue> thongTinThues = _mapper.Map<List<ThongTinThue>>(thongTinThueRequests);
            return await _thongTinThueRepositoryServices.AddorUpdateThongTinThues(thongTinThues);
        }
    }
}
