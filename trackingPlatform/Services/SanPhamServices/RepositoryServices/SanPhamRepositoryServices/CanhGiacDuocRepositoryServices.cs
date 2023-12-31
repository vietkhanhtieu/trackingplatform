﻿using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/CanhGiacDuocRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;
========
using trackingPlatform.Utils;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/CanhGiacDuocRepositoryServices.cs

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class CanhGiacDuocRepositoryServices : BaseRepositoryServices<CanhGiacDuoc>
    {
        public CanhGiacDuocRepositoryServices(CnnDbContext context) : base(context)
        {

        }

        public async Task<CanhGiacDuoc> FindByMaCgd(string maCanhGiacDuoc)
        {
            return (await _context.CanhGiacDuocs.FirstOrDefaultAsync(cgd => cgd.MaCdg == maCanhGiacDuoc))!;
        }

        public async Task<CanhGiacDuoc> FindByCanhGiacDuoc(string canhGiacDuoc)
        {
            return (await _context.CanhGiacDuocs.FirstOrDefaultAsync(cgd => cgd.CanhGiacDuoc1.ToLower().Trim() == canhGiacDuoc.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(CanhGiacDuoc canhGiacDuoc)
        {
            return await _context.CanhGiacDuocs.AnyAsync(cgd => cgd.MaCdg == canhGiacDuoc.MaCdg);
        }

        public async Task<PostDto> AddorUpdateCanhGiacDuocs(List<CanhGiacDuoc> canhGiacDuocs)
        {
            PostDto result = new PostDto();
            foreach (CanhGiacDuoc canhGiacDuoc in canhGiacDuocs)
            {
                try
                {
                    CanhGiacDuoc existCgd = await FindByMaCgd(canhGiacDuoc.MaCdg);
                    if (existCgd != null)
                    {
                        CanhGiacDuoc cgd = UpdateCanhGiacDuocUtils.UpdateCanhGiacDuoc(existCgd, canhGiacDuoc);

                        await UpdateAsync(cgd);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(canhGiacDuoc);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = canhGiacDuoc.MaCdg.ToString(),
                        Name = canhGiacDuoc.CanhGiacDuoc1,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }

    }
}
