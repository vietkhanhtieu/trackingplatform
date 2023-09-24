using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.SanPhamRequest;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.ExternalServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.SanPhamServices.RepositoryServices;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices
{
    public class TonKhoTheoHubServices
    {
        public readonly TonKhoTheoHubRepositoryServices _tonkhoTheohubRepositoryServices;
        public readonly HubRepositoryServices _hubRepositoryServices;
        public readonly SanPhamKinhDoanhRepositoryServices _sanPhamKinhDoanhRepositoryServices;
        private readonly ManualMapper _mapper;


        public TonKhoTheoHubServices(TonKhoTheoHubRepositoryServices TonkhoTheohubRepositoryServices, HubRepositoryServices hubRepositoryServices, SanPhamKinhDoanhRepositoryServices sanPhamKinhDoanhRepositoryServices, ManualMapper mapper)
        {
            _tonkhoTheohubRepositoryServices = TonkhoTheohubRepositoryServices;
            _hubRepositoryServices = hubRepositoryServices;
            _sanPhamKinhDoanhRepositoryServices = sanPhamKinhDoanhRepositoryServices;
            _mapper = mapper;
        }


        public async Task<TonkhoTheohub> GetTonkhoTheohub(string maSanPham, string maHub)
        {
            return await _tonkhoTheohubRepositoryServices.FindByMaTonkhoTheohub(maSanPham, maHub);

        }

        public async Task<IEnumerable<TonkhoTheohub>> GetAllTonkhoTheohub(int top, int skip, string? filter)
        {
            return await _tonkhoTheohubRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(TonkhoTheohub TonkhoTheohub)
        {
            await _tonkhoTheohubRepositoryServices.AddAsync(TonkhoTheohub);
        }

        public async Task<TonkhoTheohub> DeleteAsync(string maSanPham, string maHub)
        {
            TonkhoTheohub TonkhoTheohub = await GetTonkhoTheohub(maSanPham, maHub);
            if (TonkhoTheohub != null)
            {
                await _tonkhoTheohubRepositoryServices.DeleteAsync(TonkhoTheohub);
            }
            return TonkhoTheohub;
        }

        public async Task<PostDto> AddorUpdateTonkhoTheohub(List<TonKhoTheoHubRequest> tonkhoTheohubRequests)
        {
            //List<TonkhoTheohub> TonkhoTheohubs = _mapper.Map<List<TonkhoTheohub>>(TonkhoTheohubRequests);
            //return await _tonkhoTheohubRepositoryServices.AddorUpdateTonkhoTheohubs(TonkhoTheohubs);

            List<TonkhoTheohub> tonkhoTheohubs = new List<TonkhoTheohub>();
            PostDto result = new PostDto();
            foreach (TonKhoTheoHubRequest tonKhoTheoHubRequest in tonkhoTheohubRequests)
            {
                if(await _sanPhamKinhDoanhRepositoryServices.FindAsync(tonKhoTheoHubRequest.MaSanPham) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = tonKhoTheoHubRequest.MaSanPham.ToString(),
                        Message = "Can not find product"
                    }
                    );
                    continue;
                }
                if (await _hubRepositoryServices.FindAsync(tonKhoTheoHubRequest.MaHub) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = tonKhoTheoHubRequest.MaSanPham.ToString(),
                        Message = "Can not find hub"
                    }
                    );
                    continue;
                }
                SanPhamKinhDoanh sanPhamKinhDoanh = await _sanPhamKinhDoanhRepositoryServices.FindAsync(tonKhoTheoHubRequest.MaSanPham);
                Models.SanPhamModels.Hub hub = await _hubRepositoryServices.FindAsync(tonKhoTheoHubRequest.MaHub);
                tonkhoTheohubs.Add(_mapper.MapTonkhoTheohubRequestForTonkhoTheohub(tonKhoTheoHubRequest, sanPhamKinhDoanh, hub));
            }
            return UpdatePostDto.UpdatePostDto1(await _tonkhoTheohubRepositoryServices.AddorUpdateTonkhoTheohubs(tonkhoTheohubs), result) ;
        }
    }
}
