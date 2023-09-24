using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class PhanNganhServices
    {
        private readonly PhanNganhRepositoryServices _phanNganhRepositoryServices;
        private readonly IMapper _mapper;
        public PhanNganhServices(PhanNganhRepositoryServices phanNganhRepositoryServices, IMapper mapper)
        {
            _phanNganhRepositoryServices = phanNganhRepositoryServices;
            _mapper = mapper;
        }

        public async Task<PhanNganh> GetPhanNganh(string maPhanNganh)
        {
            return await _phanNganhRepositoryServices.FindByPhanNganh(maPhanNganh);

        }

        public async Task<IEnumerable<PhanNganh>> GetAllPhanNganh(int top, int skip, string? filter)
        {
            return await _phanNganhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(PhanNganh phanNganh)
        {
            await _phanNganhRepositoryServices.AddAsync(phanNganh);
        }

        public async Task<PhanNganh> DeleteAsync(string maphanNganh)
        {
            PhanNganh phanNganh = await GetPhanNganh(maphanNganh);
            if (phanNganh != null)
            {
                await _phanNganhRepositoryServices.DeleteAsync(phanNganh);
            }
            return phanNganh;
        }

        public async Task<PostDto> AddorUpdatePhanNganh(List<PhanNganhRequest> phanNganhRequests)
        {
            List<PhanNganh> phanNganhs = _mapper.Map<List<PhanNganh>>(phanNganhRequests);
            return await _phanNganhRepositoryServices.AddorUpdatePhanNganhs(phanNganhs);
        }
    }
}
