using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/LoaiSpNoiBoServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/LoaiSpNoiBoServices.cs

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class LoaiSpNoiBoServices
    {
        public readonly LoaiSpNoiBoRepositoryService _loaiSpNoiBoRepositoryService;
        private readonly IMapper _mapper;


        public LoaiSpNoiBoServices(LoaiSpNoiBoRepositoryService loaiSpNoiBoRepositoryService, IMapper mapper)
        {
            _loaiSpNoiBoRepositoryService = loaiSpNoiBoRepositoryService;
            _mapper = mapper;
        }

        public async Task<LoaiSpNoiBo> FindByNameAsync(string tenLoaiSpNoiBo)
        {
            return await _loaiSpNoiBoRepositoryService.FindByTenLoaiSPNoiBo(tenLoaiSpNoiBo);
        }

        public async Task<LoaiSpNoiBo> GetLoaiSpNoiBo(string maLoaiSpNoiBo)
        {
            return await _loaiSpNoiBoRepositoryService.FindByMaLoaiSpNoiBo(maLoaiSpNoiBo);

        }

        public async Task<IEnumerable<LoaiSpNoiBo>> GetAllLoaiSpNoiBo(int top, int skip, string? filter)
        {
            return await _loaiSpNoiBoRepositoryService.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(LoaiSpNoiBo loaiSpNoiBo)
        {
            await _loaiSpNoiBoRepositoryService.AddAsync(loaiSpNoiBo);
        }

        public async Task<LoaiSpNoiBo> DeleteAsync(string maLoaiSpNoiBo)
        {
            LoaiSpNoiBo loaiSpNoiBo = await GetLoaiSpNoiBo(maLoaiSpNoiBo);
            if (loaiSpNoiBo != null)
            {
                await _loaiSpNoiBoRepositoryService.DeleteAsync(loaiSpNoiBo);
            }
            return loaiSpNoiBo;
        }

        public async Task<PostDto> AddorUpdateLoaiSpNoiBo(List<LoaiSanPhamNoiBoRequest> loaiSanPhamNoiBoRequests)
        {
            List<LoaiSpNoiBo> loaiSpNoiBos = _mapper.Map<List<LoaiSpNoiBo>>(loaiSanPhamNoiBoRequests);
            return await _loaiSpNoiBoRepositoryService.AddorUpdateLoaiSpNoiBo(loaiSpNoiBos);
        }
    }
}
