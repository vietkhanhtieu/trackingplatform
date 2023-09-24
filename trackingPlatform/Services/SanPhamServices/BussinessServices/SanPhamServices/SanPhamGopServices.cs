using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class SanPhamGopServices
    {
        public readonly SanPhamGopRepositorySevices _sanPhamGopRepositorySevices;
        private readonly IMapper _mapper;


        public SanPhamGopServices(SanPhamGopRepositorySevices sanPhamGopRepositorySevices, IMapper mapper)
        {
            _sanPhamGopRepositorySevices = sanPhamGopRepositorySevices;
            _mapper = mapper;
        }



        public async Task<SanPhamGop> GetSanPhamGop(string maGop)
        {
            return await _sanPhamGopRepositorySevices.FindByMaSanPhamGop(maGop);

        }

        public async Task<IEnumerable<SanPhamGop>> GetAllDangBaoChe(int top, int skip, string? filter)
        {
            return await _sanPhamGopRepositorySevices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(SanPhamGop sanPhamGop)
        {
            await _sanPhamGopRepositorySevices.AddAsync(sanPhamGop);
        }

        public async Task<SanPhamGop> DeleteAsync(string maGop)
        {
            SanPhamGop sanPhamGop = await GetSanPhamGop(maGop);
            if (sanPhamGop != null)
            {
                await _sanPhamGopRepositorySevices.DeleteAsync(sanPhamGop);
            }
            return sanPhamGop;
        }

        public async Task<PostDto> AddorUpdateSanPhamGops(List<SanPhamGopRequest> sanPhamGopRequests)
        {
            List<SanPhamGop> sanPhamGops = _mapper.Map<List<SanPhamGop>>(sanPhamGopRequests);
            return await _sanPhamGopRepositorySevices.AddorUpdateSanPhamGops(sanPhamGops);
        }
    }
}
