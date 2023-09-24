
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.RepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class KhachHangB2cRepositoryServices : BaseRepositoryServices<KhachHangB2c>
    {
        public KhachHangB2cRepositoryServices(CnnDbContext context) : base(context) { }

        public async Task<KhachHangB2c> FindByMaKhachHangB2c(string maKhachHang)
        {
            return (await _context.KhachHangB2cs.FirstOrDefaultAsync(KH => KH.MaKhachHangB2c == maKhachHang))!;
        }

        public async Task<bool> IdExistAsync(KhachHangB2c khachHangB2C)
        {
            return await _context.KhachHangB2cs.AnyAsync(KH => KH.MaKhachHangB2c == khachHangB2C.MaKhachHangB2c);
        }

        public async Task<PostDto> AddorUpdatePhuongThucLienLacs(List<KhachHangB2c> khachHangB2Cs)
        {
            PostDto result = new PostDto();
            foreach (KhachHangB2c khachHangB2C in khachHangB2Cs)
            {
                try
                {
                    KhachHangB2c existKHB2C = await FindByMaKhachHangB2c(khachHangB2C.MaKhachHangB2c);
                    if (existKHB2C != null)
                    {
                        KhachHangB2c KH = KhachHangB2CUtils.UpdateKhachHangB2c(existKHB2C, khachHangB2C);

                        await UpdateAsync(KH);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(khachHangB2C);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khachHangB2C.MaKhachHangB2c.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
