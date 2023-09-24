using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/LoaiSpNoiBoRepositoryService.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
========
using trackingPlatform.Utils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/LoaiSpNoiBoRepositoryService.cs
{
    public class LoaiSpNoiBoRepositoryService : BaseRepositoryServices<LoaiSpNoiBo>
    {
        public LoaiSpNoiBoRepositoryService(CnnDbContext context) : base(context)
        {
        }

        public async Task<LoaiSpNoiBo> FindByMaLoaiSpNoiBo(string maLoaiSpNoiBo)
        {
            return (await _context.LoaiSpNoiBos.FirstOrDefaultAsync(lspnb => lspnb.MaLoaiSpNoiBo == maLoaiSpNoiBo))!;
        }

        public async Task<LoaiSpNoiBo> FindByTenLoaiSPNoiBo(string tenLoaiSpNoiBo)
        {
            return (await _context.LoaiSpNoiBos.FirstOrDefaultAsync(lspnb => lspnb.TenLoaiSpNoiBo.ToLower().Trim() == tenLoaiSpNoiBo.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(LoaiSpNoiBo loaiSpNoiBo)
        {
            return await _context.LoaiSpNoiBos.AnyAsync(lspnb => lspnb.MaLoaiSpNoiBo == loaiSpNoiBo.MaLoaiSpNoiBo);
        }

        public async Task<PostDto> AddorUpdateLoaiSpNoiBo(List<LoaiSpNoiBo> loaiSpNoiBos)
        {
            PostDto result = new PostDto();
            foreach (LoaiSpNoiBo loaiSpNoiBo in loaiSpNoiBos)
            {
                try
                {
                    LoaiSpNoiBo existLspnb = await FindByMaLoaiSpNoiBo(loaiSpNoiBo.MaLoaiSpNoiBo);
                    if (existLspnb != null)
                    {
                        LoaiSpNoiBo lspnb = LoaiSanPhamNoiBoUtils.UpdateLoaiSpNoiBo(existLspnb, loaiSpNoiBo);

                        await UpdateAsync(lspnb);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(loaiSpNoiBo);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = loaiSpNoiBo.MaLoaiSpNoiBo.ToString(),
                        Name = loaiSpNoiBo.TenLoaiSpNoiBo,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
