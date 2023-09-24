using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/NhomKinhDoanhRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
========
using trackingPlatform.Utils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/NhomKinhDoanhRepositoryServices.cs
{
    public class NhomKinhDoanhRepositoryServices : BaseRepositoryServices<NhomKinhDoanh>
    {
        public NhomKinhDoanhRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<NhomKinhDoanh> FindByMaNhomKinhDoanh(string maNhomKinhDoanh)
        {
            return (await _context.NhomKinhDoanhs.FirstOrDefaultAsync(nkd => nkd.MaNhomKinhDoanh == maNhomKinhDoanh))!;
        }

        public async Task<NhomKinhDoanh> FindByTenNhomKinhDoanh(string tenNhomKinhDoanh)
        {
            return (await _context.NhomKinhDoanhs.FirstOrDefaultAsync(nkd => nkd.TenNhomKinhDoanh.ToLower().Trim() == tenNhomKinhDoanh.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(NhomKinhDoanh nhomKinhDoanh)
        {
            return await _context.NhomKinhDoanhs.AnyAsync(nkd => nkd.MaNhomKinhDoanh == nhomKinhDoanh.MaNhomKinhDoanh);
        }

        public async Task<PostDto> AddorUpdateNhomKinhDoanh(List<NhomKinhDoanh> nhomKinhDoanhs)
        {
            PostDto result = new PostDto();
            foreach (NhomKinhDoanh nhomKinhDoanh in nhomKinhDoanhs)
            {
                try
                {
                    NhomKinhDoanh existnkd = await FindByMaNhomKinhDoanh(nhomKinhDoanh.MaNhomKinhDoanh);
                    if (existnkd != null)
                    {
                        NhomKinhDoanh nkd = NhomKinhDoanhUtils.UpdateNhomKinhDoanh(existnkd, nhomKinhDoanh);

                        await UpdateAsync(nkd);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nhomKinhDoanh);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nhomKinhDoanh.MaNhomKinhDoanh.ToString(),
                        Name = nhomKinhDoanh.TenNhomKinhDoanh,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
