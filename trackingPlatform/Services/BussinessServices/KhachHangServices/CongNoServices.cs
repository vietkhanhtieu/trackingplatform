
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class CongNoServices
    {
        private readonly CongNoRepositoryServices _congNoRepositoryServices;
        private readonly IMapper _mapper;
        public CongNoServices(CongNoRepositoryServices congNoRepositoryServices, IMapper mapper)
        {
            _congNoRepositoryServices = congNoRepositoryServices;
            _mapper = mapper;
        }

        public async Task<CongNo> GetCongNo(string maCongNo)
        {
            return await _congNoRepositoryServices.FindByMaCongNo(maCongNo);

        }

        public async Task<IEnumerable<CongNo>> GetAllCongNo(int top, int skip, string? filter)
        {
            return await _congNoRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(CongNo congNo)
        {
            await _congNoRepositoryServices.AddAsync(congNo);
        }

        public async Task<CongNo> DeleteAsync(string maCongNo)
        {
            CongNo congNo = await GetCongNo(maCongNo);
            if (congNo != null)
            {
                await _congNoRepositoryServices.DeleteAsync(congNo);
            }
            return congNo;
        }

        public async Task<PostDto> AddorUpdateCongNo(List<CongNoRequest> congNoRequests)
        {
            List<CongNo> congNos = _mapper.Map<List<CongNo>>(congNoRequests);
            return await _congNoRepositoryServices.AddorUpdateCongNos(congNos);
        }
    }
}
