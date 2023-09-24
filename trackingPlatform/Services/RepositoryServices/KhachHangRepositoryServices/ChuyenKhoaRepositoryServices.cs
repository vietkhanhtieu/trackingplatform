
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class ChuyenKhoaRepositoryServices : BaseRepositoryServices<ChuyenKhoa>
    {
        public ChuyenKhoaRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }
        public async Task<ChuyenKhoa> FindByMaChuyenKhoa(string maChuyenKhoa)
        {
            return (await _context.ChuyenKhoas.FirstOrDefaultAsync(chuyenKhoa => chuyenKhoa.MaChuyenKhoa == maChuyenKhoa))!;
        }

        public async Task<PostDto> AddorUpdateChuyenKhoas(List<ChuyenKhoa> chuyenKhoas)
        {
            PostDto result = new PostDto();
            foreach (ChuyenKhoa chuyenKhoa in chuyenKhoas)
            {
                try
                {
                    ChuyenKhoa existChuyenKhoa = await FindByMaChuyenKhoa(chuyenKhoa.MaChuyenKhoa);
                    if (existChuyenKhoa != null)
                    {
                        ChuyenKhoa ph = ChuyenKhoaUtils.UpdateChuyenKhoa(existChuyenKhoa, chuyenKhoa);

                        await UpdateAsync(ph);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(chuyenKhoa);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = chuyenKhoa.MaChuyenKhoa.ToString(),
                        Name = chuyenKhoa.TenChuyenKhoa,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
