using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class LoaiTheThanhVienServices
    {
        private readonly LoaiTheThanhVienRepositoryServices _loaiTheThanhVienRepositoryServices;
        private readonly IMapper _mapper;

        public LoaiTheThanhVienServices (LoaiTheThanhVienRepositoryServices loaiTheThanhVienRepositoryServices, IMapper mapper)
        {
            _loaiTheThanhVienRepositoryServices = loaiTheThanhVienRepositoryServices;
            _mapper = mapper;
        }

        public async Task<LoaiTheThanhVien> GetLoaiTheThanhVien(string maLoaiThe)
        {
            return await _loaiTheThanhVienRepositoryServices.FindByMaLoaiThanhVien(maLoaiThe);

        }

        public async Task<IEnumerable<LoaiTheThanhVien>> GetAllLoaiTheThanhVien(int top, int skip, string? filter)
        {
            return await _loaiTheThanhVienRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(LoaiTheThanhVien loaiTheThanhVien)
        {
            await _loaiTheThanhVienRepositoryServices.AddAsync(loaiTheThanhVien);
        }

        public async Task<LoaiTheThanhVien> DeleteAsync(string maLoaiThe)
        {
            LoaiTheThanhVien loaiTheThanhVien = await GetLoaiTheThanhVien(maLoaiThe);
            if (loaiTheThanhVien != null)
            {
                await _loaiTheThanhVienRepositoryServices.DeleteAsync(loaiTheThanhVien);
            }
            return loaiTheThanhVien;
        }

        public async Task<PostDto> AddorUpdateLoaiTheThanhVien(List<LoaiTheThanhVienRequest> loaiTheThanhVienRequests)
        {
            List<LoaiTheThanhVien> loaiTheThanhViens = _mapper.Map<List<LoaiTheThanhVien>>(loaiTheThanhVienRequests);
            return await _loaiTheThanhVienRepositoryServices.AddorUpdateLoaiTheThanhViens(loaiTheThanhViens);
        }
    }
}
