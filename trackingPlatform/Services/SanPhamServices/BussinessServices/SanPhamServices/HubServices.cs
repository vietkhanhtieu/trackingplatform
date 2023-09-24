using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.SanPhamRequest;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices
{
    public class HubServices
    {
        public readonly HubRepositoryServices _hubRepositoryServices;
        private readonly IMapper _mapper;


        public HubServices(HubRepositoryServices HubRepositoryServices, IMapper mapper)
        {
            _hubRepositoryServices = HubRepositoryServices;
            _mapper = mapper;
        }

       
        public async Task<Hub> GetHub(string maHub)
        {
            return await _hubRepositoryServices.FindByMaHub(maHub);

        }

        public async Task<IEnumerable<Hub>> GetAllHub(int top, int skip, string? filter)
        {
            return await _hubRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(Hub hub)
        {
            await _hubRepositoryServices.AddAsync(hub);
        }

        public async Task<Hub> DeleteAsync(string maHub)
        {
            Hub hub = await GetHub(maHub);
            if (hub != null)
            {
                await _hubRepositoryServices.DeleteAsync(hub);
            }
            return hub;
        }

        public async Task<PostDto> AddorUpdateHub(List<HubRequest> hubRequests)
        {
            List<Hub> hubs = _mapper.Map<List<Hub>>(hubRequests);
            return await _hubRepositoryServices.AddorUpdateHub(hubs);
        }
    }
}
