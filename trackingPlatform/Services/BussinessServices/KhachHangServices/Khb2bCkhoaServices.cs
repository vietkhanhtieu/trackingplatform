
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class Khb2bCkhoaServices
    {
        private readonly Khb2bCkhoaRepositoryServices _khb2bCkhoaRepositoryServices;
        private readonly KhachHangB2bRepositoryServices _khachHangB2BRepositoryServices;
        private readonly ChuyenKhoaRepositoryServices _chuyenKhoaRepositoryServices;

        private readonly IMapper _mapper;
        public Khb2bCkhoaServices(Khb2bCkhoaRepositoryServices Khb2bCkhoaRepositoryServices, KhachHangB2bRepositoryServices khachHangB2BRepositoryServices, ChuyenKhoaRepositoryServices chuyenKhoaRepositoryServices, IMapper mapper)
        {
            _khb2bCkhoaRepositoryServices = Khb2bCkhoaRepositoryServices;
            _khachHangB2BRepositoryServices = khachHangB2BRepositoryServices;
            _chuyenKhoaRepositoryServices = chuyenKhoaRepositoryServices;
            _mapper = mapper;
        }
        public async Task<Khb2bCkhoa> GetKhb2bCkhoa(string maKhachHang, string maChuyenKhoa)
        {
            return await _khb2bCkhoaRepositoryServices.FindAsync(maKhachHang, maChuyenKhoa);
        }

        public async Task<List<Khb2bCkhoa>> GetAllKhb2bCkhoa(int top = 0, int skip = 0, string? filter = "")
        {
            return await _khb2bCkhoaRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<Khb2bCkhoa> DeleteAsync(string maKhachHang, string maChuyenKhoa)
        {
            Khb2bCkhoa khb2bCkhoa = await GetKhb2bCkhoa(maKhachHang, maChuyenKhoa);
            if (khb2bCkhoa != null)
            {
                await _khb2bCkhoaRepositoryServices.DeleteAsync(khb2bCkhoa);
            }
            return khb2bCkhoa;
        }

        public async Task AddAsync(Khb2bCkhoa khb2bCkhoa)
        {
            await _khb2bCkhoaRepositoryServices.AddAsync(khb2bCkhoa);
        }

        public async Task<PostDto> AddListKhb2bCkhoaAsync(List<Khb2bCkhoaRequest> Khb2bCkhoaRequests)
        {
            List<Khb2bCkhoa> khb2bCkhoas = _mapper.Map<List<Khb2bCkhoa>>(Khb2bCkhoaRequests);
            PostDto result = new PostDto();
            foreach (Khb2bCkhoa khb2bCkhoa in khb2bCkhoas)
            {
                if (await _chuyenKhoaRepositoryServices.FindByMaChuyenKhoa(khb2bCkhoa.MaChuyenKhoa) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khb2bCkhoa.MaChuyenKhoa,
                        Message = "Can't find maChuyenKhoa"
                    }
                    );
                    continue;
                }
                else if (await _khachHangB2BRepositoryServices.FindAsync(khb2bCkhoa.MaKhachHangB2b) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khb2bCkhoa.MaKhachHangB2b,
                        Message = "Can't find maKhachHangB2b"
                    }
                    );
                    continue;
                }
                else
                {
                    Khb2bCkhoa khCKhoa = await GetKhb2bCkhoa(khb2bCkhoa.MaKhachHangB2b, khb2bCkhoa.MaChuyenKhoa);
                    if (khCKhoa == null)
                    {
                        await _khb2bCkhoaRepositoryServices.AddAsync(khb2bCkhoa);
                        result.NumberOfCreate++;
                    }
                    else
                    {
                        await _khb2bCkhoaRepositoryServices.UpdateAsync(Khb2bCkhoaUtils.UpdateKhb2bCkhoaUtils(khCKhoa, khb2bCkhoa));
                        result.NumberOfUpdate++;
                    }
                }
            }
            return result;
        }
    }
}
