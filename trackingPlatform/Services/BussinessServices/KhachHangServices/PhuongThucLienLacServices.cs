using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class PhuongThucLienLacServices
    {
        public PhuongThucLienLacRepositoryServices _phuongThucLienLacRepositoryServices;
        private readonly IMapper _mapper;

        public PhuongThucLienLacServices(PhuongThucLienLacRepositoryServices phuongThucLienLacRepositoryServices, IMapper mapper)
        {
            _phuongThucLienLacRepositoryServices = phuongThucLienLacRepositoryServices;
            _mapper = mapper;
        }

        
        public async Task<PhuongThucLienLac> GetPhuongThucLienLac(string maPhuongThuc)
        {
            return await _phuongThucLienLacRepositoryServices.FindByMaPhuongThucLienLac(maPhuongThuc);

        }

        public async Task<IEnumerable<PhuongThucLienLac>> GetAllPhuongThucLienLac(int top, int skip, string? filter)
        {
            return await _phuongThucLienLacRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(PhuongThucLienLac phuongThucLienLac)
        {
            await _phuongThucLienLacRepositoryServices.AddAsync(phuongThucLienLac);
        }

        public async Task<PhuongThucLienLac> DeleteAsync(string maPhuongThuc)
        {
            PhuongThucLienLac phuongThucLienLac = await GetPhuongThucLienLac(maPhuongThuc);
            if (phuongThucLienLac != null)
            {
                await _phuongThucLienLacRepositoryServices.DeleteAsync(phuongThucLienLac);
            }
            return phuongThucLienLac;
        }

        public async Task<PostDto> AddorUpdatePhuongThucLienLac(List<PhuongThucLienLacRequest> phuongThucLienLacRequests)
        {
            List<PhuongThucLienLac> phuongThucLienLacs = _mapper.Map<List<PhuongThucLienLac>>(phuongThucLienLacRequests);
            return await _phuongThucLienLacRepositoryServices.AddorUpdatePhuongThucLienLacs(phuongThucLienLacs);
        }

    }
}
