using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class CanhGiacDuocServices
    {

        public readonly CanhGiacDuocRepositoryServices _canhGiacDuocRepositoryServices;
        private readonly IMapper _mapper;


        public CanhGiacDuocServices(CanhGiacDuocRepositoryServices canhGiacDuocRepositoryServices, IMapper mapper)
        {
            _canhGiacDuocRepositoryServices = canhGiacDuocRepositoryServices;
            _mapper = mapper;
        }

        public async Task<CanhGiacDuoc> FindByNameAsync(string canhGiacDuoc)
        {
            return await _canhGiacDuocRepositoryServices.FindByCanhGiacDuoc(canhGiacDuoc);
        }

        public async Task<CanhGiacDuoc> GetCanhGiacDuoc(string maCanhGiacDuoc)
        {
            return await _canhGiacDuocRepositoryServices.FindByMaCgd(maCanhGiacDuoc);

        }

        public async Task<IEnumerable<CanhGiacDuoc>> GetAllCanhGiacDuoc(int top, int skip, string? filter)
        {
            return await _canhGiacDuocRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(CanhGiacDuoc canhGiacDuoc)
        {
            await _canhGiacDuocRepositoryServices.AddAsync(canhGiacDuoc);
        }

        public async Task UpdateAsync(CanhGiacDuoc canhGiacDuoc)
        {
            await _canhGiacDuocRepositoryServices.UpdateAsync(canhGiacDuoc);
        }

        public async Task<CanhGiacDuoc> DeleteAsync(string maCanhGiacDuoc)
        {
            CanhGiacDuoc canhGiacDuoc = await GetCanhGiacDuoc(maCanhGiacDuoc);
            if (canhGiacDuoc != null)
            {
                await _canhGiacDuocRepositoryServices.DeleteAsync(canhGiacDuoc);
            }
            return canhGiacDuoc;
        }

        public async Task<PostDto> AddorUpdateCanhGiacDuoc(List<CanhGiacDuocRequest> canhGiacDuocRequests)
        {
            List<CanhGiacDuoc> canhGiacDuocs = _mapper.Map<List<CanhGiacDuoc>>(canhGiacDuocRequests);
            return await _canhGiacDuocRepositoryServices.AddorUpdateCanhGiacDuocs(canhGiacDuocs);
        }
    }
}
