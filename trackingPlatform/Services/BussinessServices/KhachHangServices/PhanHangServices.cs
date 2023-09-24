using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class PhanHangServices
    {
        private readonly PhanHangRepositoryServices _phanHangRepositoryServices;
        private readonly IMapper _mapper;
        public PhanHangServices(PhanHangRepositoryServices phanHangRepositoryServices, IMapper mapper)
        {
            _phanHangRepositoryServices = phanHangRepositoryServices;
            _mapper = mapper;
        }

        public async Task<PhanHang> GetPhanHang(string maPhanHang)
        {
            return await _phanHangRepositoryServices.FindByPhanHang(maPhanHang);

        }

        public async Task<IEnumerable<PhanHang>> GetAllPhanHang(int top, int skip, string? filter)
        {
            return await _phanHangRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(PhanHang phanHang)
        {
            await _phanHangRepositoryServices.AddAsync(phanHang);
        }

        public async Task<PhanHang> DeleteAsync(string maPhanHang)
        {
            PhanHang phanHang = await GetPhanHang(maPhanHang);
            if (phanHang != null)
            {
                await _phanHangRepositoryServices.DeleteAsync(phanHang);
            }
            return phanHang;
        }

        public async Task<PostDto> AddorUpdatePhanHang(List<PhanHangRequest> phanHangRequests)
        {
            List<PhanHang> phanHangs = _mapper.Map<List<PhanHang>>(phanHangRequests);
            return await _phanHangRepositoryServices.AddorUpdatePhanHangs(phanHangs);
        }

    }
}
