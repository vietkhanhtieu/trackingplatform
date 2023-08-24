
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class Khb2bLhdvuRepositoryServices
    {
        private readonly CnnDbContext _context;
        public Khb2bLhdvuRepositoryServices(CnnDbContext context)
        {
            _context = context;
        }

        public async Task<Khb2bLhdvu> FindAsync(string maKhachHang, string maLoaiHinhDichVu)
        {
            return (await _context.Set<Khb2bLhdvu>()
                    .Include(sp => sp.MaKhachHangB2bNavigation)
                    .Include(sp => sp.MaLoaiHinhDvNavigation)
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaKhachHangB2b == maKhachHang && s.MaLoaiHinhDv == maLoaiHinhDichVu))!;
        }
        public async Task<List<Khb2bLhdvu>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<Khb2bLhdvu>().AsNoTracking()
                                        .Include(sp => sp.MaKhachHangB2bNavigation)
                                        .Include(sp => sp.MaLoaiHinhDvNavigation)                                
                                        .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task AddAsync(Khb2bLhdvu khb2BLhdvu)
        {
            await _context.Set<Khb2bLhdvu>().AddAsync(khb2BLhdvu);
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

        public async Task UpdateAsync(Khb2bLhdvu khb2BLhdvu)
        {
            _context.Set<Khb2bLhdvu>().Update(khb2BLhdvu);
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

        public async Task DeleteAsync(Khb2bLhdvu khachHangB2b)
        {
            _context.Set<Khb2bLhdvu>().Remove(khachHangB2b);
            await _context.SaveChangesAsync();
        }
        private IQueryable<Khb2bLhdvu> AddTopQuery(IQueryable<Khb2bLhdvu> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<Khb2bLhdvu> AddSkipQuery(IQueryable<Khb2bLhdvu> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
