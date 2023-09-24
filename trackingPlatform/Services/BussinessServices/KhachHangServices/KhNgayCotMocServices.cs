
using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class KhNgayCotMocServices
    {
        private readonly KhNgayCotMocRepositoryServices _khNgayCotMocRepositoryServices;
        private readonly NgayCotMocRepositoryServices _ngayCotMocRepositoryServices;
        private readonly KhachHangB2bRepositoryServices _khachHangB2BRepositoryServices;
        private readonly IMapper _mapper;
        public KhNgayCotMocServices(KhNgayCotMocRepositoryServices khNgayCotMocRepositoryServices, NgayCotMocRepositoryServices ngayCotMocRepositoryServices, KhachHangB2bRepositoryServices khachHangB2BRepositoryServices, IMapper mapper)
        {
            _khNgayCotMocRepositoryServices = khNgayCotMocRepositoryServices;
            _ngayCotMocRepositoryServices = ngayCotMocRepositoryServices;
            _khachHangB2BRepositoryServices = khachHangB2BRepositoryServices;
            _mapper = mapper;
        }
        public async Task<KhNgayCotMoc> GetKhNgayCotMoc(string maKhachHang, string maCotMoc)
        {
            return await _khNgayCotMocRepositoryServices.FindAsync(maKhachHang, maCotMoc);
        }

        public async Task<List<KhNgayCotMoc>> GetAllKhNgayCotMoc(int top = 0, int skip = 0, string? filter = "")
        {
            return await _khNgayCotMocRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<KhNgayCotMoc> DeleteAsync(string maKhachHang, string maCotMoc)
        {
            KhNgayCotMoc khNgayCotMoc = await GetKhNgayCotMoc(maKhachHang, maCotMoc);
            if (khNgayCotMoc != null)
            {
                await _khNgayCotMocRepositoryServices.DeleteAsync(khNgayCotMoc);
            }
            return khNgayCotMoc;
        }

        public async Task AddAsync(KhNgayCotMoc khNgayCotMoc)
        {
            await _khNgayCotMocRepositoryServices.AddAsync(khNgayCotMoc);
        }

        public async Task<PostDto> AddListKhNgayCotMocAsync(List<KhNgayCotMocRequest> khNgayCotMocRequests)
        {
            List<KhNgayCotMoc> khNgayCotMocs = _mapper.Map<List<KhNgayCotMoc>>(khNgayCotMocRequests);

            PostDto result = new PostDto();
            foreach (KhNgayCotMoc khNgayCotMoc in khNgayCotMocs)
            {
                if (await _khachHangB2BRepositoryServices.FindAsync(khNgayCotMoc.MaKhachHangB2b) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khNgayCotMoc.MaKhachHangB2b,
                        Message = "Can't find maChuyenKhoa"
                    }
                    );
                    continue;
                }
                else if (await _ngayCotMocRepositoryServices.FindByMaCotMoc(khNgayCotMoc.MaCotMoc) == null)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = khNgayCotMoc.MaCotMoc,
                        Message = "Can't find maCotMoc"
                    }
                    );
                    continue;
                }
                else
                {
                    KhNgayCotMoc kh = await GetKhNgayCotMoc(khNgayCotMoc.MaKhachHangB2b, khNgayCotMoc.MaCotMoc);
                    if (kh == null)
                    {
                        await _khNgayCotMocRepositoryServices.AddAsync(khNgayCotMoc);
                        result.NumberOfCreate++;
                    }
                    else
                    {
                        await _khNgayCotMocRepositoryServices.UpdateAsync(KhNgayCotMocUtils.UpdateKhNgayCotMoc(kh, khNgayCotMoc));
                        result.NumberOfUpdate++;
                    }
                }
            }
            return result;
        }
    }
}
