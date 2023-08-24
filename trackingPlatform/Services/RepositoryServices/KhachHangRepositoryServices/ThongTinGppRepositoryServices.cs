
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ThongTinGppRepositoryServices : BaseRepositoryServices<ThongTinGpp>
    {
        public ThongTinGppRepositoryServices(CnnDbContext context) : base(context) { }
        public async Task<ThongTinGpp> FindByMaThongTinGpp(string maThongTinGpp)
        {
            return (await _context.ThongTinGpps.FirstOrDefaultAsync(ttGpp => ttGpp.MaTtGpp == maThongTinGpp))!;
        }
        
        public async Task<PostDto> AddorUpdateThongTinGpps(List<ThongTinGpp> ThongTinGpps)
        {
            PostDto result = new PostDto();
            foreach (ThongTinGpp thongTinGpp in ThongTinGpps)
            {
                try
                {
                    ThongTinGpp existThongTinGpp = await FindByMaThongTinGpp(thongTinGpp.MaTtGpp);
                    if (existThongTinGpp != null)
                    {
                        ThongTinGpp ttGdp = ThongTinGppUtils.UpdateThongTinGpp(existThongTinGpp, thongTinGpp);

                        await UpdateAsync(ttGdp);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinGpp);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinGpp.MaTtGpp.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
        private IQueryable<ThongTinGpp> AddTopQuery(IQueryable<ThongTinGpp> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<ThongTinGpp> AddSkipQuery(IQueryable<ThongTinGpp> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
