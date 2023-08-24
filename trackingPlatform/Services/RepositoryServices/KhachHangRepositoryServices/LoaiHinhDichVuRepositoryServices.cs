
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class LoaiHinhDichVuRepositoryServices : BaseRepositoryServices<LoaiHinhDichVu>
    {
        public LoaiHinhDichVuRepositoryServices(CnnDbContext context) : base(context) { }
        public async Task<LoaiHinhDichVu> FindByMaLoaiDichVu(string maLoaiDichVu)
        {
            return (await _context.LoaiHinhDichVus.FirstOrDefaultAsync(LDV => LDV.MaLoaiHinhDv == maLoaiDichVu))!;
        }

        public async Task<PostDto> AddorUpdateLoaiHinhDichVus(List<LoaiHinhDichVu> loaiHinhDichVus)
        {
            PostDto result = new PostDto();
            foreach (LoaiHinhDichVu loaiHinhDichVu in loaiHinhDichVus)
            {
                try
                {
                    LoaiHinhDichVu existLoaiHinhDichVu = await FindByMaLoaiDichVu(loaiHinhDichVu.MaLoaiHinhDv);
                    if (existLoaiHinhDichVu != null)
                    {
                        LoaiHinhDichVu LDV = LoaiHinhDichVuUtils.UpdateLoaiHinhDichVu(existLoaiHinhDichVu, loaiHinhDichVu);

                        await UpdateAsync(LDV);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(loaiHinhDichVu);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = loaiHinhDichVu.MaLoaiHinhDv.ToString(),
                        Name = loaiHinhDichVu.LoaiHinhDv,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
