
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class KhNgayCotMocRepositoryServices
    {
        private readonly CnnDbContext _context;
        public KhNgayCotMocRepositoryServices(CnnDbContext context)
        {
            _context = context;
        }

        public async Task<KhNgayCotMoc> FindAsync(string maKhachHang, string maCotMoc)
        {
            return (await _context.Set<KhNgayCotMoc>()
                    .Include(sp => sp.MaKhachHangB2bNavigation)
                    .Include(sp => sp.MaCotMocNavigation)
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaKhachHangB2b == maKhachHang && s.MaCotMoc == maCotMoc))!;
        }
        public async Task<List<KhNgayCotMoc>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<KhNgayCotMoc>().AsNoTracking()
                                        .Include(sp => sp.MaKhachHangB2bNavigation)
                                        .Include(sp => sp.MaCotMocNavigation)
                                        .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task AddAsync(KhNgayCotMoc khNgayCotMoc)
        {
            await _context.Set<KhNgayCotMoc>().AddAsync(khNgayCotMoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }

        public async Task UpdateAsync(KhNgayCotMoc khNgayCotMoc)
        {
            _context.Set<KhNgayCotMoc>().Update(khNgayCotMoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }

        public async Task<PostDto> AddOrUpdateKhNgayCotMocs(List<KhNgayCotMoc> khNgayCotMocs)
        {
            PostDto result = new PostDto();
            foreach (KhNgayCotMoc khNgayCotMoc in khNgayCotMocs)
            {
                try
                {
                    await _context.AddAsync(khNgayCotMoc);
                    result.NumberOfCreate++;

                }
                catch (Exception exception)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khNgayCotMoc.MaKhachHangB2b,
                        Message = exception.Message
                    }
                    );
                }
            }
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(KhNgayCotMoc khNgayCotMoc)
        {
            _context.Set<KhNgayCotMoc>().Remove(khNgayCotMoc);
            await _context.SaveChangesAsync();
        }
        private IQueryable<KhNgayCotMoc> AddTopQuery(IQueryable<KhNgayCotMoc> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<KhNgayCotMoc> AddSkipQuery(IQueryable<KhNgayCotMoc> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
