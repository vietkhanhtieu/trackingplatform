using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/ThongTinPhapLyServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/ThongTinPhapLyServices.cs
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class ThongTinPhapLyServices
    {
        public readonly ThongTinPhapLyRepositoryServices _thongTinPhapLyRepositoryServices;
        private readonly IMapper _mapper;


        public ThongTinPhapLyServices(ThongTinPhapLyRepositoryServices thongTinPhapLyRepositoryServices, IMapper mapper)
        {
            _thongTinPhapLyRepositoryServices = thongTinPhapLyRepositoryServices;
            _mapper = mapper;
        }
        public async Task<ThongTinPhapLy> GetThongTinPhapLy(string maTTPL)
        {
            return await _thongTinPhapLyRepositoryServices.FindByMaTTPL(maTTPL);

        }

        public async Task<IEnumerable<ThongTinPhapLy>> GetAllThongTinPhapLy(int top, int skip, string? filter)
        {
            return await _thongTinPhapLyRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinPhapLy thongTinPhapLy)
        {
            await _thongTinPhapLyRepositoryServices.AddAsync(thongTinPhapLy);
        }

        public async Task UpdateAsync(ThongTinPhapLy thongTinPhapLy)
        {
            await _thongTinPhapLyRepositoryServices.UpdateAsync(thongTinPhapLy);
        }

        public async Task<ThongTinPhapLy> DeleteAsync(string maTTPL)
        {
            ThongTinPhapLy thongTinPhapLy = await GetThongTinPhapLy(maTTPL);
            if (thongTinPhapLy != null)
            {
                await _thongTinPhapLyRepositoryServices.DeleteAsync(thongTinPhapLy);
            }
            return thongTinPhapLy;
        }

        public async Task<PostDto> AddorUpdateThongTinNoiBo(List<ThongTinPhapLyRequest> thongTinPhapLyRequests)
        {
            List<ThongTinPhapLy> thongTinPhapLys = _mapper.Map<List<ThongTinPhapLy>>(thongTinPhapLyRequests);
            return await _thongTinPhapLyRepositoryServices.AddorUpdateThongTinPhapLys(thongTinPhapLys);
        }
    }
}
