using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class CbnvKhachHangRepositoryServices : BaseRepositoryServices<CbnvKhachHang>
    {
        public CbnvKhachHangRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<CbnvKhachHang> FindByMaCbnvKhachHang(string maCbnvKhachHang)
        {
            return (await _context.CbnvKhachHangs.FirstOrDefaultAsync(CbnvKhachHang => CbnvKhachHang.MaCbnvKh == maCbnvKhachHang))!;

        }

        public async Task<PostDto> AddorUpdateCbnvKhachHangs(List<CbnvKhachHang> cbnvKhachHangs)
        {
            PostDto result = new PostDto();
            foreach (CbnvKhachHang cbnvKhachHang in cbnvKhachHangs)
            {
                try
                {
                    CbnvKhachHang existCbnvKhachHang = await FindByMaCbnvKhachHang(cbnvKhachHang.MaCbnvKh);
                    if (existCbnvKhachHang != null)
                    {
                        CbnvKhachHang cbnvKH = CbnvKhachHangUtils.UpadateCbnvKhachHang(existCbnvKhachHang, cbnvKhachHang);

                        await UpdateAsync(cbnvKH);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(cbnvKhachHang);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = cbnvKhachHang.MaCbnvKh.ToString(),
                        Name = cbnvKhachHang.TenCbnv,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }

        private IQueryable<CbnvKhachHang> AddTopQuery(IQueryable<CbnvKhachHang> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<CbnvKhachHang> AddSkipQuery(IQueryable<CbnvKhachHang> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
