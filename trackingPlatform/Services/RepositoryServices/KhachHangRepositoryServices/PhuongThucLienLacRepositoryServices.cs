
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class PhuongThucLienLacRepositoryServices : BaseRepositoryServices<PhuongThucLienLac>
    {
        public PhuongThucLienLacRepositoryServices(CnnDbContext context) : base(context) { }

        public async Task<PhuongThucLienLac> FindByMaPhuongThucLienLac(string maPhuongThucLienLac)
        {
            return (await _context.PhuongThucLienLacs.FirstOrDefaultAsync(ptll => ptll.MaPhuongThuc == maPhuongThucLienLac))!;
        }

        public async Task<bool> IdExistAsync(PhuongThucLienLac phuongThucLienLac)
        {
            return await _context.PhuongThucLienLacs.AnyAsync(ptll => ptll.MaPhuongThuc == phuongThucLienLac.MaPhuongThuc);
        }

        public async Task<PostDto> AddorUpdatePhuongThucLienLacs(List<PhuongThucLienLac> phuongThucLienLacs)
        {
            PostDto result = new PostDto();
            foreach (PhuongThucLienLac phuongThucLienLac in phuongThucLienLacs)
            {
                try
                {
                    PhuongThucLienLac existPTLL = await FindByMaPhuongThucLienLac(phuongThucLienLac.MaPhuongThuc);
                    if (existPTLL != null)
                    {
                        PhuongThucLienLac dbc = PhuongThucLienLacUtils.UpdatePhuongThucLienLac(existPTLL, phuongThucLienLac);

                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(phuongThucLienLac);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = phuongThucLienLac.MaPhuongThuc.ToString(),
                        Name = phuongThucLienLac.PhuongThuc,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
