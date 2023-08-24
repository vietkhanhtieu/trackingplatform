using trackingPlatform.Models.Dtos;
using AutoMapper;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class GhiChuSanPhamServices
    {
        private readonly GhiChuSanPhamRepositoryServices _ghiChuSanPhamRepositoryServices;
        private readonly IMapper _mapper;
        public GhiChuSanPhamServices(GhiChuSanPhamRepositoryServices ghiChuSanPhamRepositories, IMapper mapper)
        {
            _ghiChuSanPhamRepositoryServices = ghiChuSanPhamRepositories;
            _mapper = mapper;
        }
        public async Task<GhiChuSp> FindByNameAsync(string ghiChu1)
        {
            return await _ghiChuSanPhamRepositoryServices.FindByGhiChu1(ghiChu1);
        }

        public async Task<GhiChuSp> GetGhiChuSanPham(string maGhiChu)
        {
            return await _ghiChuSanPhamRepositoryServices.FindByMaCgd(maGhiChu);

        }

        public async Task<IEnumerable<GhiChuSp>> GetAllGhiChuSanPham(int top, int skip, string? filter)
        {
            return await _ghiChuSanPhamRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(GhiChuSp ghiChuSp)
        {
            await _ghiChuSanPhamRepositoryServices.AddAsync(ghiChuSp);
        }

        public async Task UpdateAsync(GhiChuSp ghiChuSp)
        {
            await _ghiChuSanPhamRepositoryServices.UpdateAsync(ghiChuSp);
        }

        public async Task<GhiChuSp> DeleteAsync(string maGhiChu)
        {
            GhiChuSp ghiChuSp = await GetGhiChuSanPham(maGhiChu);
            if (ghiChuSp != null)
            {
                await _ghiChuSanPhamRepositoryServices.DeleteAsync(ghiChuSp);
            }
            return ghiChuSp;
        }

        public async Task<PostDto> AddorUpdateCanhGiacDuoc(List<GhiChuSpRequest> GhiChuSpRequests)
        {
            List<GhiChuSp> ghiChuSps = _mapper.Map<List<GhiChuSp>>(GhiChuSpRequests);
            return await _ghiChuSanPhamRepositoryServices.AddorUpdateGhiChuSps(ghiChuSps);
        }
    }
}
