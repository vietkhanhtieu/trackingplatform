using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;
using trackingPlatform.Services.ExternalServices.KhachHangExternalServices;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.BussinessServices.KhachHangServices
{
    public class KhachHangB2BServices
    {
        private readonly KhachHangB2bRepositoryServices _khachHangB2BRepositoryServices;
        private readonly CbnvKhachHangServices _cbnvKhachHangServices;
        private readonly ManualMapperKhachHang _manualMapper;

        public KhachHangB2BServices(KhachHangB2bRepositoryServices khachHangB2BRepositoryServices, CbnvKhachHangServices cbnvKhachHangServices, ManualMapperKhachHang manualMapper)
        {
            _khachHangB2BRepositoryServices = khachHangB2BRepositoryServices;
            _cbnvKhachHangServices = cbnvKhachHangServices;
            _manualMapper = manualMapper;
        }

        public async Task<KhachHangB2b> GetKhachHangB2B(string maKhachHang)
        {
            return await _khachHangB2BRepositoryServices.FindAsync(maKhachHang);
        }

        public async Task<List<KhachHangB2b>> GetAllKhachHangB2b(int top = 0, int skip = 0, string? filter = "")
        {
            return await _khachHangB2BRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<KhachHangB2b> DeleteAsync(string maKhachHang)
        {
            KhachHangB2b khachHangB2B = await GetKhachHangB2B(maKhachHang);
            if (khachHangB2B != null)
            {
                await _khachHangB2BRepositoryServices.DeleteAsync(khachHangB2B);
            }
            return khachHangB2B;
        }

        public async Task AddAsync(KhachHangB2b khachHangB2B)
        {
            await _khachHangB2BRepositoryServices.AddAsync(khachHangB2B);
        }

        public async Task<PostDto> AddorUpdateKhachHangB2b(List<KhachHangB2bRequest> khachHangB2BRequests)
        {
            List<KhachHangB2b> khachHangB2Bs = new List<KhachHangB2b>();
            foreach(KhachHangB2bRequest khachHangB2BRequest in khachHangB2BRequests)
            {
                PhanHang phanHang = null;
                if (khachHangB2BRequest.PhanHang != null)
                {
                    phanHang = await _manualMapper.MapPhanHangForKhachHangB2B(khachHangB2BRequest.PhanHang);
                }
                PhanNganh phanNganh = null;
                if (khachHangB2BRequest.PhanNganh != null)
                {
                    phanNganh = await _manualMapper.MapPhanNganhForKhachHangB2B(khachHangB2BRequest.PhanNganh);
                }
                NhomKhachHangB2b nhomKhachHangB2B= null;
                if (khachHangB2BRequest.NhomKhachHangB2b != null)
                {
                    nhomKhachHangB2B = await _manualMapper.MapNhomKhachHangB2BForKhachHangB2B(khachHangB2BRequest.NhomKhachHangB2b);
                }
                NguoiDaiDienPhapLy nguoiDaiDienPhapLy= null;
                if (khachHangB2BRequest.NguoiDaiDien != null)
                {
                    nguoiDaiDienPhapLy = await _manualMapper.MapNguoiDaiDienPhapLyForKhachHangB2B(khachHangB2BRequest.NguoiDaiDien);
                }
                KhachHangB2b khachHangB2B = await GetKhachHangB2B(khachHangB2BRequest.MaKhachHangB2b);

                List<NhomKiemSoatDacBiet> nhomKiemSoatDacBiets = null;
                if (khachHangB2B != null)
                {
                    nhomKiemSoatDacBiets = await _manualMapper.MapNhomKiemSoatForKhachHangB2B(khachHangB2BRequest.NhomKiemSoatDacBiets, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<NguoiNhanTtHdon> nguoiNhanTtHdons = null;
                if (khachHangB2B != null)
                {
                    nguoiNhanTtHdons = await _manualMapper.MapNguoiNhanTtHdonForKhachHangB2B(khachHangB2BRequest.NguoiNhanTtHdons, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<ThongTinGdp> thongTinGdps = null;
                if (khachHangB2B != null)
                {
                    thongTinGdps = await _manualMapper.MapThongTinGdpForKhachHangB2B(khachHangB2BRequest.ThongTinGdps, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<ThongTinGpp> thongTinGpps = null;
                if (khachHangB2B != null)
                {
                    thongTinGpps = await _manualMapper.MapThongTinGppForKhachHangB2B(khachHangB2BRequest.ThongTinGpps, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<ThongTinThue> thongTinThues= null;
                if (khachHangB2B != null)
                {
                    thongTinThues = await _manualMapper.MapThongTinThueForKhachHangB2B(khachHangB2BRequest.ThongTinThues, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<CbnvKhachHang> cbnvKhachHangs = null;
                if (khachHangB2B != null)
                {
                    cbnvKhachHangs = await _manualMapper.MapCbnvKhachhangForKhachHangB2B(khachHangB2BRequest.CbnvKhachHangs, khachHangB2BRequest.MaKhachHangB2b);
                    //cbnvKhachHangs = await MapCbnvKhachhangForKhachHangB2B(khachHangB2BRequest.CbnvKhachHangs, khachHangB2BRequest.MaKhachHangB2b);
                }
                List<ChiNhanh> chiNhanhs = null;
                if (khachHangB2B != null)
                {
                    chiNhanhs = await _manualMapper.MapChiNhanhForKhachHangB2B(khachHangB2BRequest.ChiNhanhs, khachHangB2BRequest.MaKhachHangB2b);
                }

                List<CongNo> congNos = null;
                if (khachHangB2B != null)
                {
                    congNos = await _manualMapper.MapCongNoForKhachHangB2B(khachHangB2BRequest.CongNos, khachHangB2BRequest.MaKhachHangB2b);
                }
                khachHangB2Bs.Add(_manualMapper.MapKhachHangB2BRequestForKhachHangB2B(khachHangB2BRequest,phanHang, phanNganh, nhomKhachHangB2B, nguoiDaiDienPhapLy));
            }
            return await _khachHangB2BRepositoryServices.AddOrUpdateKhachHangB2bs(khachHangB2Bs);
        }


        public async Task<List<CbnvKhachHang>> MapCbnvKhachhangForKhachHangB2B(ICollection<KHB2B_CbnvKhachHangRequest> kHB2B_CbnvKhachHangRequests, string maKhachHang)
        {
            List<CbnvKhachHang> cbnvKhachHangs = new List<CbnvKhachHang>();
            foreach (KHB2B_CbnvKhachHangRequest cbnvKhachHangRequest in kHB2B_CbnvKhachHangRequests)
            {
                CbnvKhachHang cbnvKhachHang = await _cbnvKhachHangServices.GetCbnvKhachHang(cbnvKhachHangRequest.MaCbnvKh);
                if (cbnvKhachHang == null)
                {
                    cbnvKhachHang = new CbnvKhachHang
                    {
                        MaCbnvKh = cbnvKhachHangRequest.MaCbnvKh,
                        MaKhachHangB2b = maKhachHang,
                        TenCbnv = cbnvKhachHangRequest.TenCbnv,
                        NgaySinh = cbnvKhachHangRequest.NgaySinh,
                        ChucVu = cbnvKhachHangRequest.ChucVu,
                        PhongBan = cbnvKhachHangRequest.PhongBan,
                        GioiTinh = cbnvKhachHangRequest.GioiTinh,
                        Email = cbnvKhachHangRequest.Email,
                        SoDt = cbnvKhachHangRequest.SoDt,
                        HinhAnh = cbnvKhachHangRequest.HinhAnh,
                        GhiChu = cbnvKhachHangRequest.GhiChu,
                        MaKhachHangB2bNavigation = await GetKhachHangB2B(maKhachHang)

                    };
                    await _cbnvKhachHangServices.AddAsync(cbnvKhachHang);
                }
                else
                {
                    cbnvKhachHang = CbnvKhachHangUtils.UpadateCbnvKhachHangRequest(cbnvKhachHang, cbnvKhachHangRequest);
                }
                cbnvKhachHangs.Add(cbnvKhachHang);
            }

            return cbnvKhachHangs;
        }
    }
}
