using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ChiNhanhRepositoryServices : BaseRepositoryServices<ChiNhanh>
    {
        public ChiNhanhRepositoryServices(CnnDbContext context) : base(context) { }
        public async Task<ChiNhanh> FindByMaChiNhanh(string maChiNhanh)
        {
            return (await _context.ChiNhanhs.FirstOrDefaultAsync(chiNhanh => chiNhanh.MaChiNhanh == maChiNhanh))!;
        }

        public async Task<PostDto> AddorUpdateChiNhanhs(List<ChiNhanh> chiNhanhs)
        {
            PostDto result = new PostDto();
            foreach (ChiNhanh chiNhanh in chiNhanhs)
            {
                try
                {
                    ChiNhanh existChiNhanh = await FindByMaChiNhanh(chiNhanh.MaChiNhanh);
                    if (existChiNhanh != null)
                    {
                        ChiNhanh ph = ChiNhanhUtils.UpdateChiNhanh(existChiNhanh, chiNhanh);

                        await UpdateAsync(ph);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(chiNhanh);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = chiNhanh.MaChiNhanh.ToString(),
                        Name = chiNhanh.TenChiNhanh,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
