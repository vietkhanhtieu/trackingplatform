
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class Khb2bCkhoaRepositoryServices
    {
        private readonly CnnDbContext _context;
        public Khb2bCkhoaRepositoryServices(CnnDbContext context)
        {
            _context = context;
        }

        public async Task<Khb2bCkhoa> FindAsync(string maKhachHang, string maChuyenKhoa)
        {
            return (await _context.Set<Khb2bCkhoa>()
                    .Include(sp => sp.MaKhachHangB2bNavigation)
                    .Include(sp => sp.MaChuyenKhoaNavigation)
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaKhachHangB2b == maKhachHang && s.MaChuyenKhoa == maChuyenKhoa))!;
        }
        public async Task<List<Khb2bCkhoa>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<Khb2bCkhoa>().AsNoTracking()
                                        .Include(sp => sp.MaKhachHangB2bNavigation)
                                        .Include(sp => sp.MaChuyenKhoaNavigation)
                                        .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task AddAsync(Khb2bCkhoa khb2bCkhoa)
        {
            await _context.Set<Khb2bCkhoa>().AddAsync(khb2bCkhoa);
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

        public async Task UpdateAsync(Khb2bCkhoa khb2bCkhoa)
        {
            _context.Set<Khb2bCkhoa>().Update(khb2bCkhoa);
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



        public async Task DeleteAsync(Khb2bCkhoa khb2bCkhoa)
        {
            _context.Set<Khb2bCkhoa>().Remove(khb2bCkhoa);
            await _context.SaveChangesAsync();
        }
        private IQueryable<Khb2bCkhoa> AddTopQuery(IQueryable<Khb2bCkhoa> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<Khb2bCkhoa> AddSkipQuery(IQueryable<Khb2bCkhoa> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
