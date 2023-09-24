
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class KhachHangB2CServices 
    {
        private readonly KhachHangB2cRepositoryServices _khachHangB2CRepositoryServices;
        private readonly IMapper _mapper;

        public KhachHangB2CServices(KhachHangB2cRepositoryServices khachHangB2CRepositoryServices, IMapper mapper)
        {
            _khachHangB2CRepositoryServices = khachHangB2CRepositoryServices;
            _mapper = mapper;
        }

        public async Task<KhachHangB2c> GetKhachHangB2c(string maKhachHang)
        {
            return await _khachHangB2CRepositoryServices.FindByMaKhachHangB2c(maKhachHang);

        }

        public async Task<IEnumerable<KhachHangB2c>> GetAllKhachHangB2c(int top, int skip, string? filter)
        {
            return await _khachHangB2CRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(KhachHangB2c khachHangB2C)
        {
            await _khachHangB2CRepositoryServices.AddAsync(khachHangB2C);
        }

        public async Task<KhachHangB2c> DeleteAsync(string maPhuongThuc)
        {
            KhachHangB2c khachHangB2C = await GetKhachHangB2c(maPhuongThuc);
            if (khachHangB2C != null)
            {
                await _khachHangB2CRepositoryServices.DeleteAsync(khachHangB2C);
            }
            return khachHangB2C;
        }

        public async Task<PostDto> AddorUpdateKhachHangB2c(List<KhachHangB2cRequest> khachHangB2CRequests)
        {
            List<KhachHangB2c> khachHangB2Cs = _mapper.Map<List<KhachHangB2c>>(khachHangB2CRequests);
            return await _khachHangB2CRepositoryServices.AddorUpdatePhuongThucLienLacs(khachHangB2Cs);
        }
    }
}
