using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class NhomKiemSoatDacBietServices
    {
        private readonly NhomKiemSoatDacBietRepositoryServices _nhomKiemSoatDacBietRepositoryServices;
        private readonly IMapper _mapper;

        public NhomKiemSoatDacBietServices(NhomKiemSoatDacBietRepositoryServices nhomKiemSoatDacBietRepositoryServices, IMapper mapper)
        {
            _nhomKiemSoatDacBietRepositoryServices = nhomKiemSoatDacBietRepositoryServices;
            _mapper = mapper;
        }
        public async Task<NhomKiemSoatDacBiet> GetNhomKiemSoat(string maNhomKiemSoat)
        {
            return await _nhomKiemSoatDacBietRepositoryServices.FindByMaNhomKiemSoat(maNhomKiemSoat);

        }

        public async Task<IEnumerable<NhomKiemSoatDacBiet>> GetAllNhomKiemSoat(int top, int skip, string? filter)
        {
            return await _nhomKiemSoatDacBietRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NhomKiemSoatDacBiet nhomKiemSoatDacBiet)
        {
            await _nhomKiemSoatDacBietRepositoryServices.AddAsync(nhomKiemSoatDacBiet);
        }

        public async Task<NhomKiemSoatDacBiet> DeleteAsync(string maNhomKiemSoat)
        {
            NhomKiemSoatDacBiet nhomKiemSoatDacBiet = await GetNhomKiemSoat(maNhomKiemSoat);
            if (nhomKiemSoatDacBiet != null)
            {
                await _nhomKiemSoatDacBietRepositoryServices.DeleteAsync(nhomKiemSoatDacBiet);
            }
            return nhomKiemSoatDacBiet;
        }

        public async Task<PostDto> AddorUpdateNhomKiemSoat(List<NhomKiemSoatDatBietRequest> nhomKiemSoatDatBietRequests)
        {
            List<NhomKiemSoatDacBiet> nhomKiemSoatDacBiets = _mapper.Map<List<NhomKiemSoatDacBiet>>(nhomKiemSoatDatBietRequests);
            return await _nhomKiemSoatDacBietRepositoryServices.AddorUpdateNhomKiemSoats(nhomKiemSoatDacBiets);
        }
    }
}
