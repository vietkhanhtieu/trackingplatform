using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class DonViTinhService
    {
        private readonly DonViTinhRepositoryServices _donViTinhRepositoryServices;
        private readonly IMapper _mapper;

        public DonViTinhService(DonViTinhRepositoryServices donViTinhRepositoryServices, IMapper mapper)
        {
            _donViTinhRepositoryServices = donViTinhRepositoryServices;
            _mapper = mapper;
        }
        public async Task<DonViTinh> FindByNameAsync(string doViTinhCoSo)
        {
            return await _donViTinhRepositoryServices.FindByDonViTinhCoSo(doViTinhCoSo);
        }

        public async Task<DonViTinh> GetDonViTinh(string maDvt)
        {
            return await _donViTinhRepositoryServices.FindByMaDonViTinh(maDvt);

        }

        public async Task<IEnumerable<DonViTinh>> GetAllDonViTinh(int top, int skip, string? filter)
        {
            return await _donViTinhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(DonViTinh donViTinh)
        {
            await _donViTinhRepositoryServices.AddAsync(donViTinh);
        }

        public async Task<DonViTinh> DeleteAsync(string maDvt)
        {
            DonViTinh donViTinh = await GetDonViTinh(maDvt);
            if (donViTinh != null)
            {
                await _donViTinhRepositoryServices.DeleteAsync(donViTinh);
            }
            return donViTinh;
        }

        public async Task<PostDto> AddorUpdateDonViTinh(List<DonViTinhRequest> donViTinhRequests)
        {
            List<DonViTinh> donViTinhs = _mapper.Map<List<DonViTinh>>(donViTinhRequests);
            return await _donViTinhRepositoryServices.AddorUpdateDonViTinhs(donViTinhs);
        }
    }
}
