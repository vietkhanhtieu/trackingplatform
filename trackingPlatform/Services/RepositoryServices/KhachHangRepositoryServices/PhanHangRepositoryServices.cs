
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class PhanHangRepositoryServices : BaseRepositoryServices<PhanHang>
    {
        public PhanHangRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }
        public async Task<PhanHang> FindByPhanHang(string maPhanHang)
        {
            return (await _context.PhanHangs.FirstOrDefaultAsync(phanHang => phanHang.MaPhanHang == maPhanHang))!;
        }

        public async Task<PostDto> AddorUpdatePhanHangs(List<PhanHang> phanHangs)
        {
            PostDto result = new PostDto();
            foreach (PhanHang phanHang in phanHangs)
            {
                try
                {
                    PhanHang existPhanHang = await FindByPhanHang(phanHang.MaPhanHang);
                    if (existPhanHang != null)
                    {
                        PhanHang ph = PhanHangUtils.UpdatePhanHang(existPhanHang, phanHang);

                        await UpdateAsync(ph);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(phanHang);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = phanHang.MaPhanHang.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
