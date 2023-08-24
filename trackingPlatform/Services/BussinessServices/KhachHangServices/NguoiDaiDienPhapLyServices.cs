using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class NguoiDaiDienPhapLyServices
    {
        private readonly NguoiDaiDienRepositoryServices _nguoiDaiDienRepositoryServices;
        private readonly IMapper _mapper;
        public NguoiDaiDienPhapLyServices(NguoiDaiDienRepositoryServices nguoiDaiDienRepositoryServices, IMapper mapper)
        {
            _nguoiDaiDienRepositoryServices = nguoiDaiDienRepositoryServices;
            _mapper = mapper;
        }

        public async Task<NguoiDaiDienPhapLy> GetNguoiDaiDienPhapLy(string maNguoiDaiDien)
        {
            return await _nguoiDaiDienRepositoryServices.FindByMaNguoiDaiDien(maNguoiDaiDien);

        }

        public async Task<IEnumerable<NguoiDaiDienPhapLy>> GetAllNguoiDaiDienPhapLy(int top, int skip, string? filter)
        {
            return await _nguoiDaiDienRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NguoiDaiDienPhapLy nguoiDaiDien)
        {
            await _nguoiDaiDienRepositoryServices.AddAsync(nguoiDaiDien);
        }

        public async Task<NguoiDaiDienPhapLy> DeleteAsync(string maNguoiDaiDien)
        {
            NguoiDaiDienPhapLy nguoiDaiDien = await GetNguoiDaiDienPhapLy(maNguoiDaiDien);
            if (nguoiDaiDien != null)
            {
                await _nguoiDaiDienRepositoryServices.DeleteAsync(nguoiDaiDien);
            }
            return nguoiDaiDien;
        }

        public async Task<PostDto> AddorUpdateNguoiDaiDienPhapLy(List<NguoiDaiDienPhapLyRequest> nguoiDaiDienPhapLyRequests)
        {
            List<NguoiDaiDienPhapLy> nguoiDaiDienPhapLies = _mapper.Map<List<NguoiDaiDienPhapLy>>(nguoiDaiDienPhapLyRequests);
            return await _nguoiDaiDienRepositoryServices.AddorUpdateNguoiDaiDienPhapLys(nguoiDaiDienPhapLies);
        }
    }
}
