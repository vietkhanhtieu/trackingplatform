using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class CbnvKhachHangServices
    {
        private readonly CbnvKhachHangRepositoryServices _cbnvKhachHangRepositoryServices;
        private readonly IMapper _mapper;


        public CbnvKhachHangServices(CbnvKhachHangRepositoryServices cbnvKhachHangRepositoryServices, IMapper mapper)
        {
            _cbnvKhachHangRepositoryServices = cbnvKhachHangRepositoryServices;
            _mapper = mapper;
        }
        public async Task<CbnvKhachHang> GetCbnvKhachHang(string maCbnvKhachHang)
        {
            return await _cbnvKhachHangRepositoryServices.FindByMaCbnvKhachHang(maCbnvKhachHang);

        }

        public async Task<IEnumerable<CbnvKhachHang>> GetAllCbnvKhachHang(int top, int skip, string? filter)
        {
            return await _cbnvKhachHangRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(CbnvKhachHang cbnvKhachHang)
        {
            await _cbnvKhachHangRepositoryServices.AddAsync(cbnvKhachHang);
        }

        public async Task<CbnvKhachHang> DeleteAsync(string maCbnvKhachHang)
        {
            CbnvKhachHang cbnvKhachHang = await GetCbnvKhachHang(maCbnvKhachHang);
            if (cbnvKhachHang != null)
            {
                await _cbnvKhachHangRepositoryServices.DeleteAsync(cbnvKhachHang);
            }
            return cbnvKhachHang;
        }

        public async Task<PostDto> AddorUpdateCbnvKhachHang(List<CbnvKhachHangRequest> cbnvKhachHangRequests)
        {
            List<CbnvKhachHang> cbnvKhachHangs = _mapper.Map<List<CbnvKhachHang>>(cbnvKhachHangRequests);
            return await _cbnvKhachHangRepositoryServices.AddorUpdateCbnvKhachHangs(cbnvKhachHangs);
        }
    }
}
