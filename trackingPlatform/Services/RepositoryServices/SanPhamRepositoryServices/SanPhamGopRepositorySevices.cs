using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Utils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class SanPhamGopRepositorySevices : BaseRepositoryServices<SanPhamGop>
    {
        public SanPhamGopRepositorySevices(CnnDbContext context) : base(context)
        {
        }

        public async Task<SanPhamGop> FindByMaSanPhamGop(string maSanPhamGop)
        {
            return (await _context.SanPhamGops.FirstOrDefaultAsync(spg => spg.MaGop == maSanPhamGop))!;
        }



        public async Task<bool> IdExistAsync(SanPhamGop sanPhamGop)
        {
            return await _context.SanPhamGops.AnyAsync(spg => spg.MaGop == sanPhamGop.MaGop);
        }

        public async Task<PostDto> AddorUpdateSanPhamGops(List<SanPhamGop> sanPhamGops)
        {
            PostDto result = new PostDto();
            foreach (SanPhamGop sanPhamGop in sanPhamGops)
            {
                try
                {
                    SanPhamGop existspg = await FindByMaSanPhamGop(sanPhamGop.MaGop);
                    if (existspg != null)
                    {
                        SanPhamGop spg = SanPhamGopUtils.UpdateSanPhamGop(existspg, sanPhamGop);

                        await UpdateAsync(spg);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(sanPhamGop);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = sanPhamGop.MaGop.ToString(),
                        Name = sanPhamGop.GhiChu,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
