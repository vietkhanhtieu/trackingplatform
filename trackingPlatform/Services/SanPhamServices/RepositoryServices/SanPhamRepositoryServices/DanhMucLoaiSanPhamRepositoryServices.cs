using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices
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
