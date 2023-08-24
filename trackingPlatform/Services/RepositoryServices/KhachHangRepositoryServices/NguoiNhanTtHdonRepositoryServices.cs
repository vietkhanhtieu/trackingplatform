
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class NguoiNhanTtHdonRepositoryServices : BaseRepositoryServices<NguoiNhanTtHdon>
    {
        public NguoiNhanTtHdonRepositoryServices(CnnDbContext context) : base(context) { }

        public async Task<NguoiNhanTtHdon> FindByMaNguoiNhan(string maNguoiNhan)
        {
            return (await _context.NguoiNhanTtHdons.FirstOrDefaultAsync(nntthd => nntthd.MaNguoiNhan == maNguoiNhan))!;

        }


        public async Task<PostDto> AddorUpdateNguoiNhanTtHdons(List<NguoiNhanTtHdon> nguoiNhanTtHdons)
        {
            PostDto result = new PostDto();
            foreach (NguoiNhanTtHdon nguoiNhanTtHdon in nguoiNhanTtHdons)
            {
                try
                {
                    NguoiNhanTtHdon existNguoiNhanTtHdon = await FindByMaNguoiNhan(nguoiNhanTtHdon.MaNguoiNhan);
                    if (existNguoiNhanTtHdon != null)
                    {
                        NguoiNhanTtHdon nhanTtHdon = NguoiNhanThongTinHoaDonUtils.UpdateNguoiNhanTtHdon(existNguoiNhanTtHdon, nguoiNhanTtHdon);

                        await UpdateAsync(nhanTtHdon);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nguoiNhanTtHdon);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nguoiNhanTtHdon.MaNguoiNhan.ToString(),
                        Name = nguoiNhanTtHdon.TenNguoiNhan,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
        private IQueryable<NguoiNhanTtHdon> AddTopQuery(IQueryable<NguoiNhanTtHdon> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<NguoiNhanTtHdon> AddSkipQuery(IQueryable<NguoiNhanTtHdon> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }

   
}
