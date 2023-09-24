using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Utils.SanPhamUtils;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class ThongTinPhapLyRepositoryServices : BaseRepositoryServices<ThongTinPhapLy>
    {
        public ThongTinPhapLyRepositoryServices(CnnDbContext context) : base(context)
        {
        }
        public async Task<ThongTinPhapLy> FindByMaTTPL(string maTTPL)
        {
            return (await _context.ThongTinPhapLies.FirstOrDefaultAsync(ttpl => ttpl.MaTtpl == maTTPL))!;
        }

        public async Task<bool> IdExistAsync(ThongTinPhapLy thongTinPhapLy)
        {
            return await _context.ThongTinPhapLies.AnyAsync(ttng => ttng.MaTtpl == thongTinPhapLy.MaTtpl);
        }

        public async Task<PostDto> AddorUpdateThongTinPhapLys(List<ThongTinPhapLy> thongTinPhapLies)
        {
            PostDto result = new PostDto();
            foreach (ThongTinPhapLy thongTinPhapLy in thongTinPhapLies)
            {
                try
                {
                    ThongTinPhapLy existTTPL = await FindByMaTTPL(thongTinPhapLy.MaTtpl);
                    if (existTTPL != null)
                    {
                        ThongTinPhapLy ttpl = ThongTinPhapLyUtils.UpdateThongTinPhapLy(existTTPL, thongTinPhapLy);

                        await UpdateAsync(ttpl);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinPhapLy);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinPhapLy.MaTtpl.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
