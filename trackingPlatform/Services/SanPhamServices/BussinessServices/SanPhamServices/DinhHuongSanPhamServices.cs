using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class DinhHuongSanPhamServices
    {
        public readonly DinhHuongSanPhamRepositoryServices _dinhHuongSanPhamRepositoryServices;
        private readonly IMapper _mapper;

        public DinhHuongSanPhamServices(DinhHuongSanPhamRepositoryServices dinhHuongSanPhamRepositoryServices, IMapper mapper)
        {
            _dinhHuongSanPhamRepositoryServices = dinhHuongSanPhamRepositoryServices;
            _mapper = mapper;
        }

        public async Task<DinhHuongSanPham> FindByNameAsync(string tenDinhHuong)
        {
            return await _dinhHuongSanPhamRepositoryServices.FindByTenDinhHuong(tenDinhHuong);
        }

        public async Task<DinhHuongSanPham> GetDinhHuongSanAsync(string maDinhHuong)
        {
            return await _dinhHuongSanPhamRepositoryServices.FindByMaDinhHuong(maDinhHuong);
        }

        public async Task<IEnumerable<DinhHuongSanPham>> GetAllDinhHuongSanPhamsAsync(int top, int skip, string? filter)
        {
            return await _dinhHuongSanPhamRepositoryServices.FindAllAsync(top, skip, filter);

        }

        public async Task AddAsync(DinhHuongSanPham dinhHuongSanPham)
        {
            await _dinhHuongSanPhamRepositoryServices.AddAsync(dinhHuongSanPham);
        }

        public async Task<DinhHuongSanPham> DeleteAsync(string maDinhHuongSanPham)
        {
            DinhHuongSanPham dinhHuongSanPham = await GetDinhHuongSanAsync(maDinhHuongSanPham);
            if (dinhHuongSanPham != null)
            {
                await _dinhHuongSanPhamRepositoryServices.DeleteAsync(dinhHuongSanPham);
            }
            return dinhHuongSanPham;
        }

        public async Task<PostDto> AddorUpdateDinhHuonSanPham(List<DinhHuongSanPhamRequest> dinhHuongSanPhamRequests)
        {
            List<DinhHuongSanPham> dinhHuongSanPhams = _mapper.Map<List<DinhHuongSanPham>>(dinhHuongSanPhamRequests);
            return await _dinhHuongSanPhamRepositoryServices.AddorUpdateDinhHuongSanPham(dinhHuongSanPhams);
        }

    }
}
