
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ChiNhanhServices 
    {
        private readonly ChiNhanhRepositoryServices _chiNhanhRepositoryServices;
        private readonly IMapper _mapper;
        public ChiNhanhServices(ChiNhanhRepositoryServices chiNhanhRepositoryServices, IMapper mapper)
        {
            _chiNhanhRepositoryServices = chiNhanhRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ChiNhanh> GetChiNhanh(string maChiNhanh)
        {
            return await _chiNhanhRepositoryServices.FindByMaChiNhanh(maChiNhanh);

        }

        public async Task<IEnumerable<ChiNhanh>> GetAllChiNhanh(int top, int skip, string? filter)
        {
            return await _chiNhanhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ChiNhanh chiNhanh)
        {
            await _chiNhanhRepositoryServices.AddAsync(chiNhanh);
        }

        public async Task<ChiNhanh> DeleteAsync(string maChiNhanh)
        {
            ChiNhanh ChiNhanh = await GetChiNhanh(maChiNhanh);
            if (ChiNhanh != null)
            {
                await _chiNhanhRepositoryServices.DeleteAsync(ChiNhanh);
            }
            return ChiNhanh;
        }

        public async Task<PostDto> AddorUpdateChiNhanh(List<ChiNhanhRequest> chiNhanhRequests)
        {
            List<ChiNhanh> chiNhanhs = _mapper.Map<List<ChiNhanh>>(chiNhanhRequests);
            return await _chiNhanhRepositoryServices.AddorUpdateChiNhanhs(chiNhanhs);
        }
    }
}
