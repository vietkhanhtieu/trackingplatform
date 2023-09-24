using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/RepositoryServices/SanPhamRepositoryServices/DinhHuongSanPhamRepositoryServices.cs
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils.SanPhamUtils;
========
using trackingPlatform.Utils;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/RepositoryServices/SanPhamRepositoryServices/DinhHuongSanPhamRepositoryServices.cs

namespace trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices
{
    public class DinhHuongSanPhamRepositoryServices : BaseRepositoryServices<DinhHuongSanPham>
    {
        public DinhHuongSanPhamRepositoryServices(CnnDbContext context) : base(context)
        { }

        public async Task<DinhHuongSanPham> FindByMaDinhHuong(string maDinhHuong)
        {
            return (await _context.DinhHuongSanPhams.FirstOrDefaultAsync(dhsp => dhsp.MaDinhHuong == maDinhHuong))!;
        }

        public async Task<DinhHuongSanPham> FindByTenDinhHuong(string tenDinhHuong)
        {
            return (await _context.DinhHuongSanPhams.FirstOrDefaultAsync(dhsp => dhsp.TenDinhHuong == tenDinhHuong))!;
        }

        public async Task<bool> IdExistAsync(string maDinhHuong)
        {
            return await _context.DinhHuongSanPhams.AnyAsync(dhsp => dhsp.MaDinhHuong == maDinhHuong);
        }

        public async Task<PostDto> AddorUpdateDinhHuongSanPham(List<DinhHuongSanPham> dinhHuongSanPhams)
        {
            PostDto result = new PostDto();
            foreach (DinhHuongSanPham dinhHuongSanPham in dinhHuongSanPhams)
            {
                try
                {
                    DinhHuongSanPham existdhsp = await FindByMaDinhHuong(dinhHuongSanPham.MaDinhHuong);
                    if (existdhsp != null)
                    {
                        DinhHuongSanPham dbc = DinhHuongSanPhamUtils.UpdateDinhHuongSanPham(existdhsp, dinhHuongSanPham);

                        await UpdateAsync(dbc);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(dinhHuongSanPham);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = dinhHuongSanPham.MaDinhHuong.ToString(),
                        Name = dinhHuongSanPham.TenDinhHuong,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }

    }
}
