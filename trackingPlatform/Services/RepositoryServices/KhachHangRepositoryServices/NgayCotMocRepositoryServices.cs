
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.RepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class NgayCotMocRepositoryServices : BaseRepositoryServices<NgayCotMoc>
    {
        public NgayCotMocRepositoryServices(CnnDbContext context) : base(context) { }
        public async Task<NgayCotMoc> FindByMaCotMoc(string maNgayCotMoc)
        {
            return (await _context.NgayCotMocs.FirstOrDefaultAsync(ngayCotMoc => ngayCotMoc.MaCotMoc == maNgayCotMoc))!;
        }

        public async Task<PostDto> AddorUpdateNgayCotMocs(List<NgayCotMoc> ngayCotMocs)
        {
            PostDto result = new PostDto();
            foreach (NgayCotMoc ngayCotMoc in ngayCotMocs)
            {
                try
                {
                    NgayCotMoc existNgayCotMoc = await FindByMaCotMoc(ngayCotMoc.MaCotMoc);
                    if (existNgayCotMoc != null)
                    {
                        NgayCotMoc mcm = NgayCotMocUtils.UpdateNgayCotMoc(existNgayCotMoc, ngayCotMoc);

                        await UpdateAsync(mcm);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(ngayCotMoc);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = ngayCotMoc.MaCotMoc.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
