using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class NguoiNhanTtHdonServices
    {
        private readonly NguoiNhanTtHdonRepositoryServices _nguoiNhanTtHdonRepositoryServices;
        private readonly IMapper _mapper;

        public NguoiNhanTtHdonServices(NguoiNhanTtHdonRepositoryServices nguoiNhanTtHdonRepositoryServices, IMapper mapper)
        {
            _nguoiNhanTtHdonRepositoryServices = nguoiNhanTtHdonRepositoryServices;
            _mapper = mapper;
        }
        public async Task<NguoiNhanTtHdon> GetNguoiNhanTtHdon(string maNguoiNhanTtHdon)
        {
            return await _nguoiNhanTtHdonRepositoryServices.FindByMaNguoiNhan(maNguoiNhanTtHdon);

        }

        public async Task<IEnumerable<NguoiNhanTtHdon>> GetAllNguoiNhanTtHdon(int top, int skip, string? filter)
        {
            return await _nguoiNhanTtHdonRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NguoiNhanTtHdon nguoiNhanTtHdon)
        {
            await _nguoiNhanTtHdonRepositoryServices.AddAsync(nguoiNhanTtHdon);
        }

        public async Task<NguoiNhanTtHdon> DeleteAsync(string maNhomKiemSoat)
        {
            NguoiNhanTtHdon nguoiNhanTtHdon = await GetNguoiNhanTtHdon(maNhomKiemSoat);
            if (nguoiNhanTtHdon != null)
            {
                await _nguoiNhanTtHdonRepositoryServices.DeleteAsync(nguoiNhanTtHdon);
            }
            return nguoiNhanTtHdon;
        }

        public async Task<PostDto> AddorUpdateNguoiNhanTtHdon(List<NguoiNhanTtHoaDonRequest> nguoiNhanTtHoaDonRequests)
        {
            List<NguoiNhanTtHdon> nguoiNhanTtHdons = _mapper.Map<List<NguoiNhanTtHdon>>(nguoiNhanTtHoaDonRequests);
            return await _nguoiNhanTtHdonRepositoryServices.AddorUpdateNguoiNhanTtHdons(nguoiNhanTtHdons);
        }
    }
}
