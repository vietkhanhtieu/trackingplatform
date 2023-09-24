
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;
namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class KhachHangB2bRepositoryServices 
    {
        private readonly CnnDbContext _context;
        public KhachHangB2bRepositoryServices(CnnDbContext context)
        {
            _context = context;
        }
        public async Task<KhachHangB2b> FindAsync(string maKhachHang)
        {
            return (await _context.Set<KhachHangB2b>()
                    .Include(sp => sp.MaPhanHangNavigation)
                    .Include(sp => sp.MaPhanNganhNavigation)
                    .Include(sp => sp.MaNhomNavigation)
                    .Include(sp => sp.MaNguoiDaiDienNavigation)
                    .Include(sp => sp.CbnvKhachHangs)
                    .Include(sp => sp.CbnvgonsaKhb2bs)
                    .Include(sp => sp.ChiNhanhs)
                    .Include(sp => sp.CongNos)
                    .Include(sp => sp.KhNgayCotMocs)
                    .Include(sp => sp.KhachHangs)
                    .Include(sp => sp.Khb2bCkhoas)
                    .Include(sp => sp.Khb2bLhdvus)
                    .Include(sp => sp.NguoiNhanTtHdons)
                    .Include(sp => sp.NhomKiemSoatDacBiets)
                    .Include(sp => sp.ThongTinGdps)
                    .Include(sp => sp.ThongTinGpps)
                    .Include(sp => sp.ThongTinThues)
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaKhachHangB2b == maKhachHang))!;
        }

        public async Task<List<KhachHangB2b>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<KhachHangB2b>().AsNoTracking()
                                        .Include(sp => sp.MaPhanHangNavigation)
                                        .Include(sp => sp.MaPhanNganhNavigation)
                                        .Include(sp => sp.MaNhomNavigation)
                                        .Include(sp => sp.MaNguoiDaiDienNavigation)
                                        .Include(sp => sp.CbnvKhachHangs)
                                        .Include(sp => sp.CbnvgonsaKhb2bs)
                                        .Include(sp => sp.ChiNhanhs)
                                        .Include(sp => sp.CongNos)
                                        .Include(sp => sp.KhNgayCotMocs)
                                        .Include(sp => sp.KhachHangs)
                                        .Include(sp => sp.Khb2bCkhoas)
                                        .Include(sp => sp.Khb2bLhdvus)
                                        .Include(sp => sp.NguoiNhanTtHdons)
                                        .Include(sp => sp.NhomKiemSoatDacBiets)
                                        .Include(sp => sp.ThongTinGdps)
                                        .Include(sp => sp.ThongTinGpps)
                                        .Include(sp => sp.ThongTinThues)
                                        .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task AddAsync(KhachHangB2b khachHangB2B)
        {
            await _context.Set<KhachHangB2b>().AddAsync(khachHangB2B);
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

        public async Task<PostDto> AddOrUpdateKhachHangB2bs(List<KhachHangB2b> khachHangB2bs)
        {
            PostDto result = new PostDto();
            foreach (KhachHangB2b khachHangB2b in khachHangB2bs)
            {
                try
                {
                    KhachHangB2b existKH = await FindAsync(khachHangB2b.MaKhachHangB2b);
                    if (existKH != null)
                    {
                        KhachHangB2b khB2b = KhachHangB2bUtils.UpdateKhachHangB2b(existKH, khachHangB2b);

                        _context.Update(khB2b);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await _context.AddAsync(khachHangB2b);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception exception)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khachHangB2b.MaKhachHangB2b,
                        Message = exception.Message
                    }
                    );
                }
            }
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(KhachHangB2b khachHangB2b)
        {
            _context.Set<KhachHangB2b>().Remove(khachHangB2b);
            await _context.SaveChangesAsync();
        }
        private IQueryable<KhachHangB2b> AddTopQuery(IQueryable<KhachHangB2b> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<KhachHangB2b> AddSkipQuery(IQueryable<KhachHangB2b> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
