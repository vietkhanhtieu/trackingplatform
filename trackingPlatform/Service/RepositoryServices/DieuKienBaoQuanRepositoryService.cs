﻿using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Utils;

namespace trackingPlatform.Service.RepositoryServices
{
    public class DieuKienBaoQuanRepositoryService : BaseRepositoryServices<DieuKienBaoQuan>
    {
        public DieuKienBaoQuanRepositoryService(CnnDbContext context) : base(context) 
        { 
        }
        public async Task<DieuKienBaoQuan> FindByMaDieuKienBaoQuan(string maDieuKienBaoQuan)
        {
            return (await _context.DieuKienBaoQuans.FirstOrDefaultAsync(dkbq => dkbq.MaDkbq == maDieuKienBaoQuan))!;
        }

        public async Task<DieuKienBaoQuan> FindByTenDieuKienBaoQuan1(string tenDieuKienBaoQuan1)
        {
            return (await _context.DieuKienBaoQuans.FirstOrDefaultAsync(dkbq => dkbq.MaDkbq.ToLower().Trim() == tenDieuKienBaoQuan1.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(DieuKienBaoQuan dieuKienBaoQuan)
        {
            return await _context.DieuKienBaoQuans.AnyAsync(dkbq => dkbq.MaDkbq == dieuKienBaoQuan.MaDkbq);
        }

        public async Task<PostDto> AddorUpdateDieuKienBaoQuan(List<DieuKienBaoQuan> dieuKienBaoQuans)
        {
            PostDto result = new PostDto();
            foreach (DieuKienBaoQuan dieuKienBaoQuan in dieuKienBaoQuans)
            {
                try
                {
                    DieuKienBaoQuan existdkbq = await FindByMaDieuKienBaoQuan(dieuKienBaoQuan.MaDkbq);
                    if (existdkbq != null)
                    {
                        DieuKienBaoQuan dkbq = DieuKienBaoQuanUtils.UpdateDieuKienBaoQuan(existdkbq, dieuKienBaoQuan);

                        await UpdateAsync(dkbq);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(dieuKienBaoQuan);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = dieuKienBaoQuan.MaDkbq.ToString(),
                        Name = dieuKienBaoQuan.DieuKienBaoQuan1,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
