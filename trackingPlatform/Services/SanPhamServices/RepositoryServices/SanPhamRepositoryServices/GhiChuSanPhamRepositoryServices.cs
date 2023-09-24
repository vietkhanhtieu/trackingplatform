using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class GhiChuSanPhamRepositoryServices : BaseRepositoryServices<GhiChuSp>
    {
        public GhiChuSanPhamRepositoryServices(CnnDbContext context) : base(context)
        {

        }
        public async Task<GhiChuSp> FindByMaCgd(string maGhiChuSp)
        {
            return (await _context.GhiChuSps.FirstOrDefaultAsync(ghichuSp => ghichuSp.MaGhiChu == maGhiChuSp))!;
        }

        public async Task<GhiChuSp> FindByGhiChu1(string ghiChu1)
        {
            return (await _context.GhiChuSps.FirstOrDefaultAsync(ghichuSp => ghichuSp.GhiChu1.ToLower().Trim() == ghiChu1.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(GhiChuSp maGhiChuSp)
        {
            return await _context.GhiChuSps.AnyAsync(ghichuSp => ghichuSp.MaGhiChu == maGhiChuSp.MaGhiChu);
        }

        public async Task<PostDto> AddorUpdateGhiChuSps(List<GhiChuSp> ghiChuSps)
        {
            PostDto result = new PostDto();
            foreach (GhiChuSp ghichuSp in ghiChuSps)
            {
                try
                {
                    GhiChuSp existGhiChuSp = await FindByMaCgd(ghichuSp.MaGhiChu);
                    if (existGhiChuSp != null)
                    {
                        GhiChuSp ghichu = GhiChuSpUtils.UpdateGhiChuSp(existGhiChuSp, ghichuSp);

                        await UpdateAsync(ghichu);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(ghichuSp);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = ghichuSp.MaGhiChu.ToString(),
                        Name = ghichuSp.MaGhiChu,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
