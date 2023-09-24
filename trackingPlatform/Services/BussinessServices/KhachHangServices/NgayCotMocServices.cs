using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class NgayCotMocServices
    {
        private readonly NgayCotMocRepositoryServices _ngayCotMocRepositoryServices;
        private readonly IMapper _mapper;
        public NgayCotMocServices(NgayCotMocRepositoryServices ngayCotMocRepositoryServices, IMapper mapper)
        {
            _ngayCotMocRepositoryServices = ngayCotMocRepositoryServices;
            _mapper = mapper;
        }

        public async Task<NgayCotMoc> GetMaCotMoc(string maNgayCotMoc)
        {
            return await _ngayCotMocRepositoryServices.FindByMaCotMoc(maNgayCotMoc);

        }

        public async Task<IEnumerable<NgayCotMoc>> GetAllNgayCotMoc(int top, int skip, string? filter)
        {
            return await _ngayCotMocRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NgayCotMoc ngayCotMoc)
        {
            await _ngayCotMocRepositoryServices.AddAsync(ngayCotMoc);
        }

        public async Task<NgayCotMoc> DeleteAsync(string maNgayCotMoc)
        {
            NgayCotMoc ngayCotMoc = await GetMaCotMoc(maNgayCotMoc);
            if (ngayCotMoc != null)
            {
                await _ngayCotMocRepositoryServices.DeleteAsync(ngayCotMoc);
            }
            return ngayCotMoc;
        }

        public async Task<PostDto> AddorUpdateNgayCotMoc(List<NgayCotMocRequest> ngayCotMocRequests)
        {
            List<NgayCotMoc> ngayCotMocs = _mapper.Map<List<NgayCotMoc>>(ngayCotMocRequests);
            return await _ngayCotMocRepositoryServices.AddorUpdateNgayCotMocs(ngayCotMocs);
        }
    }
}
