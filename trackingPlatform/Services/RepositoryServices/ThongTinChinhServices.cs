using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;

namespace trackingPlatform.Service.RepositoryServices
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
