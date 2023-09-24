using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class ThongTinChinhRepositoryServices : BaseRepositoryServices<ThongTinChinh>
    {
        public ThongTinChinhRepositoryServices(CnnDbContext context) : base(context)
        {
        }
        public async Task<ThongTinChinh> FindByMaTTC(string maTTC)
        {
            return (await _context.ThongTinChinhs.FirstOrDefaultAsync(ttc => ttc.MaTcc == maTTC))!;
        }

        //public async Task<ThongTinChinh> FindByCanhGiacDuoc(string canhGiacDuoc)
        //{
        //    return (await _context.ThongTinChinhs.FirstOrDefaultAsync(ttc => ttc.CanhGiacDuoc1.ToLower().Trim() == canhGiacDuoc.ToLower().Trim()))!;
        //}

        public async Task<bool> IdExistAsync(ThongTinChinh thongTinChinh)
        {
            return await _context.ThongTinChinhs.AnyAsync(ttc => ttc.MaTcc == thongTinChinh.MaTcc);
        }

        public async Task<PostDto> AddorUpdateThongTinChinhs(List<ThongTinChinh> thongTinChinhs)
        {
            PostDto result = new PostDto();
            foreach (ThongTinChinh thongTinChinh in thongTinChinhs)
            {
                try
                {
                    ThongTinChinh existTTC = await FindByMaTTC(thongTinChinh.MaTcc);
                    if (existTTC != null)
                    {
                        ThongTinChinh ttc = ThongTinChinhUtils.UpdateThongTinChinh(existTTC, thongTinChinh);

                        await UpdateAsync(ttc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(thongTinChinh);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = thongTinChinh.MaTcc.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
