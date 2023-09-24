using Microsoft.EntityFrameworkCore;
using System;
using trackingPlatform.Content;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/DangBaoCheRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
========
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/DangBaoCheRepositoryServices.cs
using trackingPlatform.Utils;
using trackingPlatform.Utils.SanPhamUtils;

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class DangBaoCheRepositoryServices : BaseRepositoryServices<DangBaoChe>
    {
        public DangBaoCheRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<DangBaoChe> FindByMaDangBaoChe(string maDangBaoChe)
        {
            return (await _context.DangBaoChes.FirstOrDefaultAsync(dbc => dbc.MaDangBaoChe == maDangBaoChe))!;
        }

        public async Task<DangBaoChe> FindByTenDangBaoChe(string tenDangBaoChe)
        {
            return (await _context.DangBaoChes.FirstOrDefaultAsync(dbc => dbc.DangBaoChe1.ToLower().Trim() == tenDangBaoChe.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(DangBaoChe dangBaoChe)
        {
            return await _context.DangBaoChes.AnyAsync(dbc => dbc.MaDangBaoChe == dangBaoChe.MaDangBaoChe);
        }

        public async Task<PostDto> AddorUpdateDangBaoChes(List<DangBaoChe> dangBaoChes)
        {
            PostDto result = new PostDto();
            foreach (DangBaoChe dangBaoChe in dangBaoChes)
            {
                try
                {
                    DangBaoChe existdbc = await FindByMaDangBaoChe(dangBaoChe.MaDangBaoChe);
                    if (existdbc != null)
                    {
                        DangBaoChe dbc = DangBaoCheUtils.UpdateDangBaoChe(existdbc, dangBaoChe);
                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(dangBaoChe);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = dangBaoChe.MaDangBaoChe.ToString(),
                        Name = dangBaoChe.DangBaoChe1,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
