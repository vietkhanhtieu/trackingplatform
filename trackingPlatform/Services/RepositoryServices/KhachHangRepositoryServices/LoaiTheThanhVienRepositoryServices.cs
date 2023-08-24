
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class LoaiTheThanhVienRepositoryServices : BaseRepositoryServices<LoaiTheThanhVien>
    {
        public LoaiTheThanhVienRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<LoaiTheThanhVien> FindByMaLoaiThanhVien(string maLoaiThanhVien)
        {
            return (await _context.LoaiTheThanhViens.FirstOrDefaultAsync(ltv => ltv.MaLoaiThe == maLoaiThanhVien))!;
        }

        public async Task<bool> IdExistAsync(LoaiTheThanhVien loaiTheThanhVien)
        {
            return await _context.LoaiTheThanhViens.AnyAsync(ltv => ltv.MaLoaiThe == loaiTheThanhVien.MaLoaiThe);
        }

        public async Task<PostDto> AddorUpdateLoaiTheThanhViens(List<LoaiTheThanhVien> loaiTheThanhViens)
        {
            PostDto result = new PostDto();
            foreach (LoaiTheThanhVien loaiTheThanhVien in loaiTheThanhViens)
            {
                try
                {
                    LoaiTheThanhVien existLTTV = await FindByMaLoaiThanhVien(loaiTheThanhVien.MaLoaiThe);
                    if (existLTTV != null)
                    {
                        LoaiTheThanhVien ltv = LoaiTheThanhVienUtils.UpdateLoaiTheThanhVien(existLTTV, loaiTheThanhVien);

                        await UpdateAsync(ltv);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(loaiTheThanhVien);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = loaiTheThanhVien.MaLoaiThe.ToString(),
                        Name = loaiTheThanhVien.TenLoaiThe,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
