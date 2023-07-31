﻿using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Utils;

namespace trackingPlatform.Service.RepositoryServices
{
    public class DonViTinhRepositoryServices : BaseRepositoryServices<DonViTinh>
    {
        public DonViTinhRepositoryServices(CnnDbContext context) : base(context)
        {
        }

        public async Task<DonViTinh> FindByMaDonViTinh(string maDonViTinh)
        {
            return (await _context.DonViTinhs.FirstOrDefaultAsync(dvt => dvt.MaDvt == maDonViTinh))!;
        }

        public async Task<DonViTinh> FindByDonViTinhCoSo(string dvtCoSo)
        {
            return (await _context.DonViTinhs.FirstOrDefaultAsync(dvt => dvt.DvtCoSo.ToLower().Trim() == dvtCoSo.ToLower().Trim()))!;
        }

        public async Task<bool> IdExistAsync(DonViTinh donViTinh)
        {
            return await _context.DonViTinhs.AnyAsync(dvt => dvt.MaDvt == donViTinh.MaDvt);
        }

        public async Task<PostDto> AddorUpdateDonViTinhs(List<DonViTinh> donViTinhs)
        {
            PostDto result = new PostDto();
            foreach (DonViTinh donViTinh in donViTinhs)
            {
                try
                {
                    DonViTinh existDvt = await FindByMaDonViTinh(donViTinh.MaDvt);
                    if (existDvt != null)
                    {
                        DonViTinh dbc = DonViTinhUtils.UpdateDonViTinh(existDvt, donViTinh);

                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(donViTinh);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = donViTinh.MaDvt.ToString(),
                        Name = donViTinh.DvtCoSo,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
