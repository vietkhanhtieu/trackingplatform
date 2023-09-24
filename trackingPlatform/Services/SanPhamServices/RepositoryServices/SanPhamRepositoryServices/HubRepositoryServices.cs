using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
{
    public class HubRepositoryServices : BaseRepositoryServices<Hub>
    {
        public HubRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<Hub> FindByMaHub(string maHub)
        {
            return (await _context.Hubs.FirstOrDefaultAsync(hub => hub.MaHub == maHub))!;
        }

        

       

        public async Task<PostDto> AddorUpdateHub(List<Hub> hubs)
        {
            PostDto result = new PostDto();
            foreach (Hub hub in hubs)
            {
                try
                {
                    Hub existHub = await FindByMaHub(hub.MaHub);
                    if (existHub != null)
                    {
                        Hub Hub = HubUtils.UpdateHub(existHub, hub);

                        await UpdateAsync(Hub);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(hub);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = hub.MaHub.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
