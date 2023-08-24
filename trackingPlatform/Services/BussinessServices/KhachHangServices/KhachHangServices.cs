
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.ExternalServices.KhachHangExternalServices;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class KhachHangServices
    {
        private readonly KhachHangRepositoryServices _khachHangRepositoryServices;
        private readonly KhachHangB2BServices _khachHangB2BServices;
        private readonly ManualMapperKhachHang _manualMapper;

        public KhachHangServices(KhachHangRepositoryServices KhachHangRepositoryServices, KhachHangB2BServices khachHangB2BServices, ManualMapperKhachHang manualMapper)
        {
            _khachHangRepositoryServices = KhachHangRepositoryServices;
            _khachHangB2BServices = khachHangB2BServices;
            _manualMapper = manualMapper;
        }

        public async Task<KhachHang> GetKhachHang(string maKhachHang)
        {
            return await _khachHangRepositoryServices.FindAsync(maKhachHang);
        }

        public async Task<List<KhachHang>> GetAllKhachHang(int top = 0, int skip = 0, string? filter = "")
        {
            return await _khachHangRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<KhachHang> DeleteAsync(string maKhachHang)
        {
            KhachHang khachHang = await GetKhachHang(maKhachHang);
            if (khachHang != null)
            {
                await _khachHangRepositoryServices.DeleteAsync(khachHang);
            }
            return khachHang;
        }

        public async Task<PostDto> AddorUpdateKhachHang(List<KhachHangRequest> khachHangRequests)
        {
            List<KhachHang> khachHangs = new List<KhachHang>();
            foreach (KhachHangRequest khachHangRequest in khachHangRequests)
            {
                KhachHangB2b khachHangB2B = null;
                if (khachHangRequest.MaKhachHangB2b != null)
                {
                    khachHangB2B = await MapKhachHangB2bForKhachHang(khachHangRequest.MaKhachHangB2b);
                }
                KhachHangB2c khachHangB2C = null;
                if (khachHangRequest.KhachHangB2c != null)
                {
                    khachHangB2C = await _manualMapper.MapKhachHangB2CForKhachHang(khachHangRequest.KhachHangB2c);
                }
                LoaiTheThanhVien loaiTheThanhVien = null;
                if (khachHangRequest.LoaiTheThanhVien != null)
                {
                    loaiTheThanhVien = await _manualMapper.MapLoaiTheThanhVienForKhachHang(khachHangRequest.LoaiTheThanhVien);
                }
                PhuongThucLienLac phuongThucLienLac = null;
                if (khachHangRequest.PhuongThucLienLac != null)
                {
                    phuongThucLienLac = await _manualMapper.MapPhuongThucLienLacForKhachHang(khachHangRequest.PhuongThucLienLac);
                }
                ThongTinXuatHoaDon thongTinXuatHoaDon = null;
                if (khachHangRequest.ThongTinXuatHoaDon != null)
                {
                    thongTinXuatHoaDon = await _manualMapper.MapThongTinXuatHoaDonForKhachHang(khachHangRequest.ThongTinXuatHoaDon);
                }
                khachHangs.Add(_manualMapper.MapKhachHangRequestForKhachHang(khachHangRequest, khachHangB2B, khachHangB2C, loaiTheThanhVien, phuongThucLienLac, thongTinXuatHoaDon));
            }

            return await _khachHangRepositoryServices.AddOrUpdateKhachHangs(khachHangs);
        }

        public async Task<KhachHangB2b> MapKhachHangB2bForKhachHang(string maKhachHangB2b)
        {
            KhachHangB2b khachHangB2B = await _khachHangB2BServices.GetKhachHangB2B(maKhachHangB2b);
            if (khachHangB2B == null)
            {
                khachHangB2B = new KhachHangB2b
                {
                    MaKhachHangB2b = maKhachHangB2b
                };
                await _khachHangB2BServices.AddAsync(khachHangB2B);
            }

            return khachHangB2B;
        }
    }  
}
