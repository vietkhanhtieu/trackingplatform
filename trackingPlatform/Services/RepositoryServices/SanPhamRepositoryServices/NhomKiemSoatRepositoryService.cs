using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/NhomKiemSoatRepositoryService.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;
========
using trackingPlatform.Utils;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/NhomKiemSoatRepositoryService.cs

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class NhomKiemSoatRepositoryService : BaseRepositoryServices<NhomKiemSoat>
    {
        public NhomKiemSoatRepositoryService(CnnDbContext context) : base(context) { }

        public async Task<NhomKiemSoat> FindByMaNhomKiemSoat(string maNhomKiemSoat)
        {
            return (await _context.NhomKiemSoats.FirstOrDefaultAsync(nks => nks.MaNhomKiemSoat == maNhomKiemSoat))!;
        }

        public async Task<NhomKiemSoat> FindByTenNhomKiemSoat(string tenNhomKiemSoat)
        {
            return (await _context.NhomKiemSoats.FirstOrDefaultAsync(nks => nks.TenNhomKiemSoat.ToLower().Trim() == tenNhomKiemSoat.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(NhomKiemSoat nhomKiemSoat)
        {
            return await _context.NhomKiemSoats.AnyAsync(nks => nks.MaNhomKiemSoat == nhomKiemSoat.MaNhomKiemSoat);
        }

        public async Task<PostDto> AddorUpdateNhomKiemSoats(List<NhomKiemSoat> nhomKiemSoats)
        {
            PostDto result = new PostDto();
            foreach (NhomKiemSoat nhomKiemSoat in nhomKiemSoats)
            {
                try
                {
                    NhomKiemSoat existNks = await FindByMaNhomKiemSoat(nhomKiemSoat.MaNhomKiemSoat);
                    if (existNks != null)
                    {
                        NhomKiemSoat dbc = NhomKiemSoatUtils.UpdateNhomKiemSoat(existNks, nhomKiemSoat);

                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nhomKiemSoat);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nhomKiemSoat.MaNhomKiemSoat.ToString(),
                        Name = nhomKiemSoat.TenNhomKiemSoat,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
