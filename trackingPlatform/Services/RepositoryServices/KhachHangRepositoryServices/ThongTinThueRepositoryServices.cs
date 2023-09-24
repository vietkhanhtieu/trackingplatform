using trackingPlatform.Models.KhachHangModels;
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ThongTinThueRepositoryServices : BaseRepositoryServices<ThongTinThue>
    {
        public ThongTinThueRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }
        public async Task<ThongTinThue> FindByMaThongTinThue(string maThongTinThue)
        {
            return (await _context.ThongTinThues.FirstOrDefaultAsync(ttt => ttt.MaTtThue == maThongTinThue))!;
        }

        

        public async Task<PostDto> AddorUpdateThongTinThues(List<ThongTinThue> thongTinThues)
        {
            PostDto result = new PostDto();
            foreach (ThongTinThue thongTinThue in thongTinThues)
            {
                try
                {
                    ThongTinThue existThongTinThue = await FindByMaThongTinThue(thongTinThue.MaTtThue);
                    if (existThongTinThue != null)
                    {
                        ThongTinThue ttt = ThongTinThueUtils.UpdateThongTinThue(existThongTinThue, thongTinThue);
                        await UpdateAsync(ttt);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinThue);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinThue.MaTtThue.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }

        private IQueryable<ThongTinThue> AddTopQuery(IQueryable<ThongTinThue> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<ThongTinThue> AddSkipQuery(IQueryable<ThongTinThue> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
