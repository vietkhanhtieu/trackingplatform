
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class KhachHangRepositoryServices
    {
        private readonly CnnDbContext _context;
        public KhachHangRepositoryServices(CnnDbContext context)
        {
            _context = context;
        }
        public async Task<KhachHang> FindAsync(string maKhachHang)
        {
            return (await _context.Set<KhachHang>()
                    //.Include(sp => sp.MaKhachHangB2bNavigation)
                    .Include(sp => sp.MaKhachHangB2cNavigation)
                    .Include(sp => sp.MaLoaiTheNavigation)
                    .Include(sp => sp.MaPhuongThucNavigation)
                    .Include(sp => sp.MaTtXuatHdNavigation)                    
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaKhachHang == maKhachHang))!;
        }
        public async Task<List<KhachHang>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<KhachHang>().AsNoTracking()
                    //.Include(sp => sp.MaKhachHangB2bNavigation)
                    .Include(sp => sp.MaKhachHangB2cNavigation)
                    .Include(sp => sp.MaLoaiTheNavigation)
                    .Include(sp => sp.MaPhuongThucNavigation)
                    .Include(sp => sp.MaTtXuatHdNavigation)
                    .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task<PostDto> AddOrUpdateKhachHangs(List<KhachHang> khachHangs)
        {
            PostDto result = new PostDto();
            foreach (KhachHang khachHang in khachHangs)
            {
                try
                {
                    KhachHang existKH = await FindAsync(khachHang.MaKhachHang);
                    if (existKH != null)
                    {
                        KhachHang khB2b = KhachHangUtils.UpdateKhachHang(existKH, khachHang);

                        _context.Update(khB2b);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await _context.AddAsync(khachHang);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception exception)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khachHang.MaKhachHang,
                        Name = khachHang.TenKhachHang,
                        Message = exception.Message
                    }
                    );
                }
            }
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(KhachHang KhachHang)
        {
            _context.Set<KhachHang>().Remove(KhachHang);
            await _context.SaveChangesAsync();
        }
        private IQueryable<KhachHang> AddTopQuery(IQueryable<KhachHang> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<KhachHang> AddSkipQuery(IQueryable<KhachHang> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
