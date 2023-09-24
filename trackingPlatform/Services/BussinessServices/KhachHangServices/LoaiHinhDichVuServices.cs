
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class LoaiHinhDichVuServices
    {
        private readonly LoaiHinhDichVuRepositoryServices _loaiHinhDichVuRepositoryServices;
        private readonly IMapper _mapper;
        public LoaiHinhDichVuServices(LoaiHinhDichVuRepositoryServices loaiHinhDichVuRepositoryServices, IMapper mapper)
        {
            _loaiHinhDichVuRepositoryServices = loaiHinhDichVuRepositoryServices;
            _mapper = mapper;
        }

        public async Task<LoaiHinhDichVu> GetLoaiHinhDichVu(string maLoaiDichVu)
        {
            return await _loaiHinhDichVuRepositoryServices.FindByMaLoaiDichVu(maLoaiDichVu);

        }

        public async Task<IEnumerable<LoaiHinhDichVu>> GetAllLoaiHinhDichVu(int top, int skip, string? filter)
        {
            return await _loaiHinhDichVuRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(LoaiHinhDichVu loaiDichVu)
        {
            await _loaiHinhDichVuRepositoryServices.AddAsync(loaiDichVu);
        }

        public async Task<LoaiHinhDichVu> DeleteAsync(string maLoaiDichVu)
        {
            LoaiHinhDichVu loaiDichVu = await GetLoaiHinhDichVu(maLoaiDichVu);
            if (loaiDichVu != null)
            {
                await _loaiHinhDichVuRepositoryServices.DeleteAsync(loaiDichVu);
            }
            return loaiDichVu;
        }

        public async Task<PostDto> AddorUpdateLoaiHinhDichVu(List<LoaiHinhDichVuRequest> loaiHinhDichVuRequests)
        {
            List<LoaiHinhDichVu> loaiHinhDichVus = _mapper.Map<List<LoaiHinhDichVu>>(loaiHinhDichVuRequests);
            return await _loaiHinhDichVuRepositoryServices.AddorUpdateLoaiHinhDichVus(loaiHinhDichVus);
        }
    }
}
