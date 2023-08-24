
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class NguoiDaiDienRepositoryServices : BaseRepositoryServices<NguoiDaiDienPhapLy>
    {
        public NguoiDaiDienRepositoryServices(CnnDbContext context) : base(context) { }

        public async Task<NguoiDaiDienPhapLy> FindByMaNguoiDaiDien(string maNguoiDaiDien)
        {
            return (await _context.NguoiDaiDienPhapLies.FirstOrDefaultAsync(NDD => NDD.MaNguoiDaiDien == maNguoiDaiDien))!;
        }



        public async Task<PostDto> AddorUpdateNguoiDaiDienPhapLys(List<NguoiDaiDienPhapLy> nguoiDaiDienPhapLies)
        {
            PostDto result = new PostDto();
            foreach (NguoiDaiDienPhapLy nguoiDaiDienPhapLy in nguoiDaiDienPhapLies)
            {
                try
                {
                    NguoiDaiDienPhapLy existNguoiDaiDien = await FindByMaNguoiDaiDien(nguoiDaiDienPhapLy.MaNguoiDaiDien);
                    if (existNguoiDaiDien != null)
                    {
                        NguoiDaiDienPhapLy NDD = NguoiDaiDienPhapLyUtils.UpdateNguoiDaiDienPhapLy(existNguoiDaiDien, nguoiDaiDienPhapLy);

                        await UpdateAsync(NDD);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nguoiDaiDienPhapLy);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nguoiDaiDienPhapLy.MaNguoiDaiDien.ToString(),
                        Name = nguoiDaiDienPhapLy.TenNguoiDaiDien,
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
    }
}
