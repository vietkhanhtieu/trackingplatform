using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class NhomKhachHangB2BServices
    {
        private readonly NhomKhachHangB2BRepositoryServices _nhomKhachHangB2BRepositoryServices;
        private readonly IMapper _mapper;
        public NhomKhachHangB2BServices(NhomKhachHangB2BRepositoryServices nhomKhachHangB2BRepositoryServices, IMapper mapper)
        {
            _nhomKhachHangB2BRepositoryServices = nhomKhachHangB2BRepositoryServices;
            _mapper = mapper;
        }

        public async Task<NhomKhachHangB2b> GetNhomKhachHangB2B(string maNhomKhachHang)
        {
            return await _nhomKhachHangB2BRepositoryServices.FindByNhomKhachHangB2b(maNhomKhachHang);

        }

        public async Task<IEnumerable<NhomKhachHangB2b>> GetAllNhomKhachHangB2B(int top, int skip, string? filter)
        {
            return await _nhomKhachHangB2BRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NhomKhachHangB2b phanNganh)
        {
            await _nhomKhachHangB2BRepositoryServices.AddAsync(phanNganh);
        }

        public async Task<NhomKhachHangB2b> DeleteAsync(string maphanNganh)
        {
            NhomKhachHangB2b nhomKhachHangB2B = await GetNhomKhachHangB2B(maphanNganh);
            if (nhomKhachHangB2B != null)
            {
                await _nhomKhachHangB2BRepositoryServices.DeleteAsync(nhomKhachHangB2B);
            }
            return nhomKhachHangB2B;
        }

        public async Task<PostDto> AddorUpdateNhomKhachHangB2b(List<NhomKhachHangB2BRequest> nhomKhachHangB2BRequests)
        {
            List<NhomKhachHangB2b> nhomKhachHangB2Bs = _mapper.Map<List<NhomKhachHangB2b>>(nhomKhachHangB2BRequests);
            return await _nhomKhachHangB2BRepositoryServices.AddorUpdateNhomKhachHangB2bs(nhomKhachHangB2Bs);
        }
    }
}
