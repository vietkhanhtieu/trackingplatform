
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ThongTinGdpRepositoryServices : BaseRepositoryServices<ThongTinGdp>
    {
        public ThongTinGdpRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<ThongTinGdp> FindByMaThongTinGdp(string maThongTinGdp)
        {
            return (await _context.ThongTinGdps.FirstOrDefaultAsync(ttGdp => ttGdp.MaTtGdp == maThongTinGdp))!;
        }
        
        public async Task<PostDto> AddorUpdateThongTinGdps(List<ThongTinGdp> thongTinGdps)
        {
            PostDto result = new PostDto();
            foreach (ThongTinGdp thongTinGdp in thongTinGdps)
            {
                try
                {
                    ThongTinGdp existThongTinGdp = await FindByMaThongTinGdp(thongTinGdp.MaTtGdp);
                    if (existThongTinGdp != null)
                    {
                        ThongTinGdp ttGdp = ThongTinGdpUtils.UpdateThongTinGdp(existThongTinGdp, thongTinGdp);

                        await UpdateAsync(ttGdp);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinGdp);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinGdp.MaTtGdp.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
        private IQueryable<ThongTinGdp> AddTopQuery(IQueryable<ThongTinGdp> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<ThongTinGdp> AddSkipQuery(IQueryable<ThongTinGdp> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
