using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/ThongTinNoiBoRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
========
using trackingPlatform.Utils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/ThongTinNoiBoRepositoryServices.cs
{
    public class ThongTinNoiBoRepositoryServices : BaseRepositoryServices<ThongTinNoiBo>
    {
        public ThongTinNoiBoRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext)
        {
        }
        public async Task<ThongTinNoiBo> FindByMaTTNB(string maTTNB)
        {
            return (await _context.ThongTinNoiBos.FirstOrDefaultAsync(ttnb => ttnb.MaTtnb == maTTNB))!;
        }

        public async Task<bool> IdExistAsync(ThongTinNoiBo thongTinNoiBo)
        {
            return await _context.ThongTinNoiBos.AnyAsync(ttnb => ttnb.MaTtnb == thongTinNoiBo.MaTtnb);
        }

        public async Task<PostDto> AddorUpdateThongTinNoiBos(List<ThongTinNoiBo> thongTinNoiBos)
        {
            PostDto result = new PostDto();
            foreach (ThongTinNoiBo thongTinNoiBo in thongTinNoiBos)
            {
                try
                {
                    ThongTinNoiBo existTTPL = await FindByMaTTNB(thongTinNoiBo.MaTtnb);
                    if (existTTPL != null)
                    {
                        ThongTinNoiBo ttnb = ThongTinNoiBoUtils.UpdateThongTinNoiBo(existTTPL, thongTinNoiBo);

                        await UpdateAsync(ttnb);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinNoiBo);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinNoiBo.MaTtnb.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
