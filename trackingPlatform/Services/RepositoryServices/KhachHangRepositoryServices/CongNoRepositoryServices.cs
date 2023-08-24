
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.RepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class CongNoRepositoryServices : BaseRepositoryServices<CongNo>
    {
        public CongNoRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }
        public async Task<CongNo> FindByMaCongNo(string maCongNo)
        {
            return (await _context.CongNos.FirstOrDefaultAsync(congNo => congNo.MaCongNo == maCongNo))!;
        }

        public async Task<PostDto> AddorUpdateCongNos(List<CongNo> congNos)
        {
            PostDto result = new PostDto();
            foreach (CongNo congNo in congNos)
            {
                try
                {
                    CongNo existCongNo = await FindByMaCongNo(congNo.MaCongNo);
                    if (existCongNo != null)
                    {
                        CongNo cbnvKH = CongNoUtils.UpdateCongNo(existCongNo, congNo);

                        await UpdateAsync(cbnvKH);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(congNo);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = congNo.MaCongNo.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
