using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/LoaiSpRepositoryServices.cs
using trackingPlatform.Utils.SanPhamUtils;
using trackingPlatform.Service.RepositoryServices;
========
using trackingPlatform.Models;
using trackingPlatform.Utils;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/LoaiSpRepositoryServices.cs
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class LoaiSpRepositoryServices : BaseRepositoryServices<LoaiSp>
    {
        public LoaiSpRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<LoaiSp> FindByMaLoaiSp(string maLoaiSp)
        {
            return (await _context.LoaiSps.FirstOrDefaultAsync(loaiSp => loaiSp.MaLoaiSp == maLoaiSp))!;
        }

        public async Task<LoaiSp> FindByTenLoaiSp(string tenLoaiSp)
        {
            return (await _context.LoaiSps.FirstOrDefaultAsync(loaiSp => loaiSp.TenLoaiSp.ToLower().Trim() == tenLoaiSp.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(LoaiSp loaiSp)
        {
            return await _context.LoaiSps.AnyAsync(lSp => lSp.MaLoaiSp == loaiSp.MaLoaiSp);
        }

        public async Task<PostDto> AddorUpdateLoaiSp(List<LoaiSp> loaiSps)
        {
            PostDto result = new PostDto();
            foreach (LoaiSp loaiSp in loaiSps)
            {
                try
                {
                    LoaiSp existLsp = await FindByMaLoaiSp(loaiSp.MaLoaiSp);
                    if (existLsp != null)
                    {
                        LoaiSp lsp = LoaiSpUtils.UpdateLoaiSp(existLsp, loaiSp);

                        await UpdateAsync(lsp);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(loaiSp);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = loaiSp.MaLoaiSp.ToString(),
                        Name = loaiSp.TenLoaiSp,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
