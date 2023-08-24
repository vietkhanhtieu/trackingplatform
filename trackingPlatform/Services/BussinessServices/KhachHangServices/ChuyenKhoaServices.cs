
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class ChuyenKhoaServices
    {
        private readonly ChuyenKhoaRepositoryServices _chuyenKhoaRepositoryServices;
        private readonly IMapper _mapper;
        public ChuyenKhoaServices(ChuyenKhoaRepositoryServices chuyenKhoaRepositoryServices, IMapper mapper)
        {
            _chuyenKhoaRepositoryServices = chuyenKhoaRepositoryServices;
            _mapper = mapper;
        }

        public async Task<ChuyenKhoa> GetChuyenKhoa(string maChuyenKhoa)
        {
            return await _chuyenKhoaRepositoryServices.FindByMaChuyenKhoa(maChuyenKhoa);

        }

        public async Task<IEnumerable<ChuyenKhoa>> GetAllChuyenKhoa(int top, int skip, string? filter)
        {
            return await _chuyenKhoaRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ChuyenKhoa ChuyenKhoa)
        {
            await _chuyenKhoaRepositoryServices.AddAsync(ChuyenKhoa);
        }

        public async Task<ChuyenKhoa> DeleteAsync(string maChuyenKhoa)
        {
            ChuyenKhoa chuyenKhoa = await GetChuyenKhoa(maChuyenKhoa);
            if (chuyenKhoa != null)
            {
                await _chuyenKhoaRepositoryServices.DeleteAsync(chuyenKhoa);
            }
            return chuyenKhoa;
        }

        public async Task<PostDto> AddorUpdateChuyenKhoa(List<ChuyenKhoaRequest> chuyenKhoaRequests)
        {
            List<ChuyenKhoa> chuyenKhoas = _mapper.Map<List<ChuyenKhoa>>(chuyenKhoaRequests);
            return await _chuyenKhoaRepositoryServices.AddorUpdateChuyenKhoas(chuyenKhoas);
        }
    }
}
