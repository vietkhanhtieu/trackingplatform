using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class ThongTinNguonGocRepositoryServices : BaseRepositoryServices<ThongTinNguonGoc>
    {
        public ThongTinNguonGocRepositoryServices(CnnDbContext context) : base(context)
        {
        }
        public async Task<ThongTinNguonGoc> FindByMaTTNG(string maTTNG)
        {
            return (await _context.ThongTinNguonGocs.FirstOrDefaultAsync(ttng => ttng.MaTtng == maTTNG))!;
        }

        public async Task<bool> IdExistAsync(ThongTinNguonGoc thongTinNguonGoc)
        {
            return await _context.ThongTinNguonGocs.AnyAsync(ttng => ttng.MaTtng == thongTinNguonGoc.MaTtng);
        }

        public async Task<PostDto> AddorUpdateThongTinNguonGocs(List<ThongTinNguonGoc> thongTinNguonGocs)
        {
            PostDto result = new PostDto();
            foreach (ThongTinNguonGoc thongTinNguonGoc in thongTinNguonGocs)
            {
                try
                {
                    ThongTinNguonGoc existTTNG = await FindByMaTTNG(thongTinNguonGoc.MaTtng);
                    if (existTTNG != null)
                    {
                        ThongTinNguonGoc ttng = ThongTinNguoGocUtils.UpdateThongTinNguonGoc(existTTNG, thongTinNguonGoc);

                        await UpdateAsync(ttng);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinNguonGoc);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinNguonGoc.MaTtng.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }

    }
}
