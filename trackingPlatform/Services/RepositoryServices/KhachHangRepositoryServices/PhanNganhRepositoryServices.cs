
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class PhanNganhRepositoryServices : BaseRepositoryServices<PhanNganh>
    {
        public PhanNganhRepositoryServices(CnnDbContext context) : base(context) { }
        public async Task<PhanNganh> FindByPhanNganh(string maPhanNganh)
        {
            return (await _context.PhanNganhs.FirstOrDefaultAsync(phanNganh => phanNganh.MaPhanNganh == maPhanNganh))!;
        }

        public async Task<PostDto> AddorUpdatePhanNganhs(List<PhanNganh> phanNganhs)
        {
            PostDto result = new PostDto();
            foreach (PhanNganh phanNganh in phanNganhs)
            {
                try
                {
                    PhanNganh existphanNganh = await FindByPhanNganh(phanNganh.MaPhanNganh);
                    if (existphanNganh != null)
                    {
                        PhanNganh pn = PhanNganhUtils.UpdatePhanNganh(existphanNganh, phanNganh);

                        await UpdateAsync(pn);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(phanNganh);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = phanNganh.MaPhanNganh.ToString(),
                        Name = phanNganh.PhanNganh1,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
