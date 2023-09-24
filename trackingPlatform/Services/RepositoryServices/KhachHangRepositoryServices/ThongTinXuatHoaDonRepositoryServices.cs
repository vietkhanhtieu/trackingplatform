
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ThongTinXuatHoaDonRepositoryServices : BaseRepositoryServices<ThongTinXuatHoaDon>
    {
        public ThongTinXuatHoaDonRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<ThongTinXuatHoaDon> FindByMaThongTinXuatHoaDon(string maTtXuatHd)
        {
            return (await _context.ThongTinXuatHoaDons.FirstOrDefaultAsync(ttxhd => ttxhd.MaTtXuatHd == maTtXuatHd))!;
        }

        public async Task<bool> IdExistAsync(ThongTinXuatHoaDon thongTinXuatHoaDon)
        {
            return await _context.ThongTinXuatHoaDons.AnyAsync(ttxhd => ttxhd.MaTtXuatHd == thongTinXuatHoaDon.MaTtXuatHd);
        }

        public async Task<PostDto> AddorUpdateThongTinXuatHoaDons(List<ThongTinXuatHoaDon> ThongTinXuatHoaDons)
        {
            PostDto result = new PostDto();
            foreach (ThongTinXuatHoaDon thongTinXuatHoaDon in ThongTinXuatHoaDons)
            {
                try
                {
                    ThongTinXuatHoaDon existTtXhd = await FindByMaThongTinXuatHoaDon(thongTinXuatHoaDon.MaTtXuatHd);
                    if (existTtXhd != null)
                    {
                        ThongTinXuatHoaDon ltv = ThongTinXuatHoaDonUtils.UpdateThongTinXuatHoaDon(existTtXhd, thongTinXuatHoaDon);

                        await UpdateAsync(ltv);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinXuatHoaDon);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinXuatHoaDon.MaTtXuatHd.ToString(),
                        Name = thongTinXuatHoaDon.TenNguoiMuaHang,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
