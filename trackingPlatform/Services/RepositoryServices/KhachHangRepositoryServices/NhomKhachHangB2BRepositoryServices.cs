
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class NhomKhachHangB2BRepositoryServices : BaseRepositoryServices<NhomKhachHangB2b>
    {
        public NhomKhachHangB2BRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<NhomKhachHangB2b> FindByNhomKhachHangB2b(string maNhomKhachHangB2B)
        {
            return (await _context.NhomKhachHangB2bs.FirstOrDefaultAsync(nkhB2B => nkhB2B.MaNhom == maNhomKhachHangB2B))!;
        }



        public async Task<PostDto> AddorUpdateNhomKhachHangB2bs(List<NhomKhachHangB2b> nhomKhachHangB2Bs)
        {
            PostDto result = new PostDto();
            foreach (NhomKhachHangB2b nhomKhachHangB2B in nhomKhachHangB2Bs)
            {
                try
                {
                    NhomKhachHangB2b existNhomKhachHangB2b = await FindByNhomKhachHangB2b(nhomKhachHangB2B.MaNhom);
                    if (existNhomKhachHangB2b != null)
                    {
                        NhomKhachHangB2b KH = NhomKhachHangB2BUtils.UpdateNhomKhachHangB2B(existNhomKhachHangB2b, nhomKhachHangB2B);

                        await UpdateAsync(KH);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nhomKhachHangB2B);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nhomKhachHangB2B.MaNhom.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
