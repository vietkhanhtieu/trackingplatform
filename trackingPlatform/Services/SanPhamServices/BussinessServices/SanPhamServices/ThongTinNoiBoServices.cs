using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class ThongTinNoiBoServices
    {
        public readonly ThongTinNoiBoRepositoryServices _thongTinNoiBoRepositoryServices;
        private readonly IMapper _mapper;


        public ThongTinNoiBoServices(ThongTinNoiBoRepositoryServices thongTinNoiBoRepositoryServices, IMapper mapper)
        {
            _thongTinNoiBoRepositoryServices = thongTinNoiBoRepositoryServices;
            _mapper = mapper;
        }
        public async Task<ThongTinNoiBo> GetThongTinNoiBo(string maTTNB)
        {
            return await _thongTinNoiBoRepositoryServices.FindByMaTTNB(maTTNB);

        }

        public async Task<IEnumerable<ThongTinNoiBo>> GetAllThongTinNoiBo(int top, int skip, string? filter)
        {
            return await _thongTinNoiBoRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinNoiBo thongTinNoiBo)
        {
            await _thongTinNoiBoRepositoryServices.AddAsync(thongTinNoiBo);
        }

        public async Task UpdateAsync(ThongTinNoiBo thongTinNoiBo)
        {
            await _thongTinNoiBoRepositoryServices.UpdateAsync(thongTinNoiBo);
        }

        public async Task<ThongTinNoiBo> DeleteAsync(string maTTPL)
        {
            ThongTinNoiBo thongTinNoiBo = await GetThongTinNoiBo(maTTPL);
            if (thongTinNoiBo != null)
            {
                await _thongTinNoiBoRepositoryServices.DeleteAsync(thongTinNoiBo);
            }
            return thongTinNoiBo;
        }

        public async Task<PostDto> AddorUpdateThongTinNoiBo(List<ThongTinNoiBoRequest> thongTinNoiBoRequests)
        {
            List<ThongTinNoiBo> thongTinNoiBos = _mapper.Map<List<ThongTinNoiBo>>(thongTinNoiBoRequests);
            return await _thongTinNoiBoRepositoryServices.AddorUpdateThongTinNoiBos(thongTinNoiBos);
        }
    }
}
