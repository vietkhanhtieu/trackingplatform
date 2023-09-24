using AutoMapper;
using trackingPlatform.Models.Dtos;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/ThongTinChinhServices.cs
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
========
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/ThongTinChinhServices.cs
{
    public class ThongTinChinhServices
    {
        public readonly ThongTinChinhRepositoryServices _thongTinChinhRepositoryServices;
        private readonly IMapper _mapper;


        public ThongTinChinhServices(ThongTinChinhRepositoryServices thongTinChinhRepositoryServices, IMapper mapper)
        {
            _thongTinChinhRepositoryServices = thongTinChinhRepositoryServices;
            _mapper = mapper;
        }

        //public async Task<CanhGiacDuoc> FindByNameAsync(string canhGiacDuoc)
        //{
        //    return await _canhGiacDuocRepositoryServices.FindByCanhGiacDuoc(canhGiacDuoc);
        //}

        public async Task<ThongTinChinh> GetThongTinChinh(string maTTC)
        {
            return await _thongTinChinhRepositoryServices.FindByMaTTC(maTTC);

        }

        public async Task<IEnumerable<ThongTinChinh>> GetAllThongTinChinh(int top, int skip, string? filter)
        {
            return await _thongTinChinhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinChinh thongTinChinh)
        {
            await _thongTinChinhRepositoryServices.AddAsync(thongTinChinh);
        }

        public async Task UpdateAsync(ThongTinChinh thongTinChinh)
        {
            await _thongTinChinhRepositoryServices.UpdateAsync(thongTinChinh);
        }

        public async Task<ThongTinChinh> DeleteAsync(string maTTC)
        {
            ThongTinChinh thongTinChinh = await GetThongTinChinh(maTTC);
            if (thongTinChinh != null)
            {
                await _thongTinChinhRepositoryServices.DeleteAsync(thongTinChinh);
            }
            return thongTinChinh;
        }

        public async Task<PostDto> AddorUpdateThongTinChinh(List<ThongTinChinhRequest> thongTinChinhRequests)
        {
            List<ThongTinChinh> thongTinChinhs = _mapper.Map<List<ThongTinChinh>>(thongTinChinhRequests);
            return await _thongTinChinhRepositoryServices.AddorUpdateThongTinChinhs(thongTinChinhs);
        }
    }
}
