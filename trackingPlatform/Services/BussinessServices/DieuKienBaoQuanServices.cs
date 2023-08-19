using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class DieuKienBaoQuanServices
    {
        private readonly DieuKienBaoQuanRepositoryService _dieuKienBaoQuanRepositoryService;
        private readonly IMapper _mapper;

        public DieuKienBaoQuanServices(DieuKienBaoQuanRepositoryService dieuKienBaoQuanRepositoryService, IMapper mapper)
        {
            _dieuKienBaoQuanRepositoryService = dieuKienBaoQuanRepositoryService;
            _mapper = mapper;
        }

        public async Task<DieuKienBaoQuan> FindByNameAsync(string dieuKienBaoQuan1)
        {
            return await _dieuKienBaoQuanRepositoryService.FindByTenDieuKienBaoQuan1(dieuKienBaoQuan1);
        }

        public async Task<DieuKienBaoQuan> GetDieuKienBaoQuan(string maDkbq)
        {
            return await _dieuKienBaoQuanRepositoryService.FindByMaDieuKienBaoQuan(maDkbq);

        }

        public async Task<IEnumerable<DieuKienBaoQuan>> GetAllDieuKienBaoQuan(int top, int skip, string? filter)
        {
            return await _dieuKienBaoQuanRepositoryService.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(DieuKienBaoQuan dieuKienBaoQuan)
        {
            await _dieuKienBaoQuanRepositoryService.AddAsync(dieuKienBaoQuan);
        }

        public async Task<DieuKienBaoQuan> DeleteAsync(string maDkqb)
        {
            DieuKienBaoQuan dieuKienBaoQuan = await GetDieuKienBaoQuan(maDkqb);
            if (dieuKienBaoQuan != null)
            {
                await _dieuKienBaoQuanRepositoryService.DeleteAsync(dieuKienBaoQuan);
            }
            return dieuKienBaoQuan;
        }

        public async Task<PostDto> AddorUpdateDieuKienBaoQuan(List<DieuKienBaoQuanRequest> dieuKienBaoQuanRequest)
        {
            List<DieuKienBaoQuan> dieuKienBaoQuans = _mapper.Map<List<DieuKienBaoQuan>>(dieuKienBaoQuanRequest);
            return await _dieuKienBaoQuanRepositoryService.AddorUpdateDieuKienBaoQuan(dieuKienBaoQuans);
        }
    }
}
