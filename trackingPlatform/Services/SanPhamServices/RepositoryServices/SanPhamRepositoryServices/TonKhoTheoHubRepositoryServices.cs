using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices
{
    public class TonKhoTheoHubRepositoryServices : BaseRepositoryServices<TonkhoTheohub>
    {
        public TonKhoTheoHubRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<TonkhoTheohub> FindByMaTonkhoTheohub(string maSanPham, string maHub)
        {
            return (await _context.TonkhoTheohubs.FirstOrDefaultAsync(tkth => tkth.MaSanPham == maSanPham && tkth.MaHub == maHub))!;
        }

       

        public async Task<PostDto> AddorUpdateTonkhoTheohubs(List<TonkhoTheohub> tonkhoTheohubs)
        {
            PostDto result = new PostDto();
            foreach (TonkhoTheohub tonkhoTheohub in tonkhoTheohubs)
            {
                try
                {
                    TonkhoTheohub existtkth = await FindByMaTonkhoTheohub(tonkhoTheohub.MaSanPham, tonkhoTheohub.MaHub);
                    if (existtkth != null)
                    {
                        TonkhoTheohub dbc = TonKhoTheoHubUtils.UpdateTonKhoTheoHub(existtkth, tonkhoTheohub);

                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        
                        await AddAsync(tonkhoTheohub);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = tonkhoTheohub.MaHub.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
