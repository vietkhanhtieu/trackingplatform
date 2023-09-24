using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/DanhMucLoaiSanPhamRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
========
using trackingPlatform.Utils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/DanhMucLoaiSanPhamRepositoryServices.cs
{
    public class DanhMucLoaiSanPhamRepositoryServices : BaseRepositoryServices<DanhMucLoaiSp>
    {
        public DanhMucLoaiSanPhamRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<DanhMucLoaiSp> FindByMaDanhMucLoaiSp(string maDMLSP)
        {
            return (await _context.DanhMucLoaiSps.FirstOrDefaultAsync(dmlsp => dmlsp.MaDanhMucLsp == maDMLSP))!;
        }

        public async Task<DanhMucLoaiSp> FindByTenDMLSP(string tenDMLSP)
        {
            return (await _context.DanhMucLoaiSps.FirstOrDefaultAsync(dmlsp => dmlsp.TenDanhMucLsp.ToLower().Trim() == tenDMLSP.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(DanhMucLoaiSp danhMucLoaiSp)
        {
            return await _context.DanhMucLoaiSps.AnyAsync(dmlsp => dmlsp.MaDanhMucLsp == danhMucLoaiSp.MaDanhMucLsp);
        }

        public async Task<PostDto> AddorUpdateDanhMucLoaiSp(List<DanhMucLoaiSp> danhMucLoaiSps)
        {
            PostDto result = new PostDto();
            foreach (DanhMucLoaiSp danhMucLoaiSp in danhMucLoaiSps)
            {
                try
                {
                    DanhMucLoaiSp existDmlsp = await FindByMaDanhMucLoaiSp(danhMucLoaiSp.MaDanhMucLsp);
                    if (existDmlsp != null)
                    {
                        DanhMucLoaiSp dmlsp = DanhMucLoaiSpUtils.UpdateDanhMucLoaiSp(existDmlsp, danhMucLoaiSp);

                        await UpdateAsync(dmlsp);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(danhMucLoaiSp);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = danhMucLoaiSp.MaDanhMucLsp.ToString(),
                        Name = danhMucLoaiSp.TenDanhMucLsp,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
