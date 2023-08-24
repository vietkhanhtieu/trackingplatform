
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class Khb2bLhdvServices
    {
        private readonly Khb2bLhdvuRepositoryServices _khb2BLhdvuRepositoryServices;
        private readonly KhachHangB2bRepositoryServices _khb2BRepositoryServices;
        private readonly LoaiHinhDichVuRepositoryServices _loaiHinhDichVuRepositoryServices;
        private readonly IMapper _mapper;
        public Khb2bLhdvServices(Khb2bLhdvuRepositoryServices khb2BLhdvuRepositoryServices, KhachHangB2bRepositoryServices khb2BRepositoryServices, LoaiHinhDichVuRepositoryServices loaiHinhDichVuRepositoryServices, IMapper mapper)
        {
            _khb2BLhdvuRepositoryServices = khb2BLhdvuRepositoryServices;
            _khb2BRepositoryServices = khb2BRepositoryServices;
            _loaiHinhDichVuRepositoryServices = loaiHinhDichVuRepositoryServices;
            _mapper = mapper;
        }
        public async Task<Khb2bLhdvu> GetKhb2bLhdvu(string maKhachHang, string maLhdvu)
        {
            return await _khb2BLhdvuRepositoryServices.FindAsync(maKhachHang, maLhdvu);
        }

        public async Task<List<Khb2bLhdvu>> GetAllKhb2bLhdvu(int top = 0, int skip = 0, string? filter = "")
        {
            return await _khb2BLhdvuRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<Khb2bLhdvu> DeleteAsync(string maKhachHang, string maLhdvu)
        {
            Khb2bLhdvu khb2bLhdvu = await GetKhb2bLhdvu(maKhachHang, maLhdvu);
            if (khb2bLhdvu != null)
            {
                await _khb2BLhdvuRepositoryServices.DeleteAsync(khb2bLhdvu);
            }
            return khb2bLhdvu;
        }

        public async Task AddAsync(Khb2bLhdvu Khb2bLhdvu)
        {
            await _khb2BLhdvuRepositoryServices.AddAsync(Khb2bLhdvu);
        }

        public async Task<PostDto> AddListKhb2bLhdvuAsync(List<Khb2bLhdvuRequest> khb2BLhdvuRequests)
        {
            List<Khb2bLhdvu> khb2BLhdvus= _mapper.Map<List<Khb2bLhdvu>>(khb2BLhdvuRequests);

            PostDto result = new PostDto();
            foreach (Khb2bLhdvu khb2BLhdvu in khb2BLhdvus)
            {
                if (await _khb2BRepositoryServices.FindAsync(khb2BLhdvu.MaKhachHangB2b) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khb2BLhdvu.MaKhachHangB2b,
                        Message = "Can't find maKhachHangB2b"
                    }
                    );
                    continue;
                }
                else if (await _loaiHinhDichVuRepositoryServices.FindAsync(khb2BLhdvu.MaLoaiHinhDv) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khb2BLhdvu.MaLoaiHinhDv,
                        Message = "Can't find maLoaiHinhDv"
                    }
                    );
                    continue;
                }
                else
                {
                    Khb2bLhdvu khDv = await GetKhb2bLhdvu(khb2BLhdvu.MaKhachHangB2b, khb2BLhdvu.MaLoaiHinhDv);
                    if (khDv == null)
                    {
                        await _khb2BLhdvuRepositoryServices.AddAsync(khb2BLhdvu);
                        result.NumberOfCreate++;
                    }
                    else
                    {
                        await _khb2BLhdvuRepositoryServices.UpdateAsync(Khb2bLhdvuUtils.UdpateKhb2bLhdvu(khDv, khb2BLhdvu));
                        result.NumberOfUpdate++;
                    }
                }
            }
            return result;
        }
    }
}
