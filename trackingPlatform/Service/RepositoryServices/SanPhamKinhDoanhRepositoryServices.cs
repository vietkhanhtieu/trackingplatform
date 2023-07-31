using Microsoft.EntityFrameworkCore;
using System;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Utils;

namespace trackingPlatform.Service.RepositoryServices
{
    public class SanPhamKinhDoanhRepositoryServices
    {
        private readonly CnnDbContext _context;
        public SanPhamKinhDoanhRepositoryServices (CnnDbContext context)
        {
            _context = context;
        }
        public async Task<SanPhamKinhDoanh> FindAsync(string maSanPham)
        {
            return (await _context.Set<SanPhamKinhDoanh>()
                    .Include(sp => sp.MaDangBaoCheNavigation)
                    .Include(sp => sp.MaDkbqNavigation)
                    .Include(sp => sp.MaDinhHuongNavigation)
                    .Include(sp => sp.MaDvtNavigation)
                    .Include(sp => sp.MaLoaiSpNoiBoNavigation)
                    .Include(sp => sp.MaLoaiSpNavigation)
                    .Include(sp => sp.MaNhomKiemSoatNavigation)
                    .Include(sp => sp.MaNhomKinhDoanhNavigation)
                    .Include(sp => sp.MaGopNavigation)
                    .Include(sp => sp.CanhGiacDuocs)
                    .Include(sp => sp.GhiChuSps)
                    .Include(sp => sp.ThongTinNguonGocs)
                    .Include(sp => sp.ThongTinChinhs)
                    .Include(sp => sp.ThongTinNoiBos)
                    .Include(sp => sp.ThongTinPhapLies)
                    .AsQueryable().SingleOrDefaultAsync(s => s.MaSanPham == maSanPham))!;        
        }

        public async Task<List<SanPhamKinhDoanh>> FindAllAsync(int top, int skip, string? filter)
        {
            return await AddSkipQuery(AddTopQuery(_context.Set<SanPhamKinhDoanh>().AsNoTracking()
                                        .Include(sp => sp.MaDangBaoCheNavigation)
                                        .Include(sp => sp.MaDkbqNavigation)
                                        .Include(sp => sp.MaDinhHuongNavigation)
                                        .Include(sp => sp.MaDvtNavigation)
                                        .Include(sp => sp.MaLoaiSpNoiBoNavigation)
                                        .Include(sp => sp.MaLoaiSpNavigation)
                                        .Include(sp => sp.MaNhomKiemSoatNavigation)
                                        .Include(sp => sp.MaNhomKinhDoanhNavigation)
                                        .Include(sp => sp.MaGopNavigation)
                                        .Include(sp => sp.CanhGiacDuocs)
                                        .Include(sp => sp.GhiChuSps)
                                        .Include(sp => sp.ThongTinNguonGocs)
                                        .Include(sp => sp.ThongTinChinhs)
                                        .Include(sp => sp.ThongTinNoiBos)
                                        .Include(sp => sp.ThongTinPhapLies)
                                        .AsQueryable(), top), skip).ToListAsync();
        }

        public async Task<PostDto> AddOrUpdateSanPhams(List<SanPhamKinhDoanh> sanPhamKinhDoanhs)
        {
            PostDto result = new PostDto();
            foreach (SanPhamKinhDoanh sanPhamKinhDoanh in sanPhamKinhDoanhs)
            {
                try
                {
                    SanPhamKinhDoanh exitsSp = await FindAsync(sanPhamKinhDoanh.MaSanPham);
                    if (exitsSp != null)
                    {
                        SanPhamKinhDoanh spkd = SanPhamKinhDoanhUtils.UpdateSanPhamKinhDoanh(exitsSp, sanPhamKinhDoanh);

                        _context.Update(spkd);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await _context.AddAsync(sanPhamKinhDoanh);
                        result.NumberOfCreate++;
                    }
                }
                catch(Exception exception) 
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = sanPhamKinhDoanh.MaSanPham,
                        Name = sanPhamKinhDoanh.TenSanPham,
                        Message = exception.Message
                    }
                    );
                }
            }
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(SanPhamKinhDoanh sanPhamKinhDoanh)
        {
            _context.Set<SanPhamKinhDoanh>().Remove(sanPhamKinhDoanh);
            await _context.SaveChangesAsync();
        }
        private IQueryable<SanPhamKinhDoanh> AddTopQuery(IQueryable<SanPhamKinhDoanh> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<SanPhamKinhDoanh> AddSkipQuery(IQueryable<SanPhamKinhDoanh> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
