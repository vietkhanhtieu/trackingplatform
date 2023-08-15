using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdateSanPham;
using trackingPlatform.Service.ExternalServices;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class SanPhamKinhDoanhServices
    {

        private readonly SanPhamKinhDoanhRepositoryServices _sanPhamKinhDoanhRepositoryService;
        private readonly ManualMapper _manualMapper;

        public SanPhamKinhDoanhServices(SanPhamKinhDoanhRepositoryServices sanPhamKinhDoanhRepositoryServices, ManualMapper manualMapper)
        {
            _sanPhamKinhDoanhRepositoryService = sanPhamKinhDoanhRepositoryServices;
            _manualMapper = manualMapper;
        }

        public async Task<SanPhamKinhDoanh> GetSanPhamKinhDoanh(string MaSanPham)
        {
            return await _sanPhamKinhDoanhRepositoryService.FindAsync(MaSanPham);
        }

        public async Task<List<SanPhamKinhDoanh>> GetAllSanPham(int top = 0, int skip = 0, string? filter = "")
        {
            return await _sanPhamKinhDoanhRepositoryService.FindAllAsync(top, skip, filter);
        }

        public async Task<SanPhamKinhDoanh> DeleteAsync(string maSanPham)
        {
            SanPhamKinhDoanh sanPham = await GetSanPhamKinhDoanh(maSanPham);
            if (sanPham != null)
            {
                await _sanPhamKinhDoanhRepositoryService.DeleteAsync(sanPham);
            }
            return sanPham;
        }

        public async Task<PostDto> AddOrUpdateSanPhams(List<SanPhamRequest> sanPhamRequests)
        {
            List<SanPhamKinhDoanh> sanPhamKinhDoanhs = new List<SanPhamKinhDoanh>();

            foreach (SanPhamRequest sanPhamRequest in sanPhamRequests)
            {
                DangBaoChe dangBaoChe = null;
                if (sanPhamRequest.DangBaoChe != null)
                {
                    dangBaoChe = await _manualMapper.MapDangBaoCheForSanPham(sanPhamRequest.DangBaoChe);
                }

                DinhHuongSanPham dinhHuongSanPham = null;
                if (sanPhamRequest.DinhHuongSanPham != null)
                {
                    dinhHuongSanPham = await _manualMapper.MapDinhHuongSanPhamForSanPham(sanPhamRequest.DinhHuongSanPham);
                }
                DieuKienBaoQuan dieuKienBaoQuan = null;
                if (sanPhamRequest.DieuKienBaoQuan != null)
                {
                    dieuKienBaoQuan = await _manualMapper.MapDieuKienBaoQuanForSanPham(sanPhamRequest.DieuKienBaoQuan);
                }
                DonViTinh donViTinh = null;
                if (sanPhamRequest.DonViTinh != null)
                {
                    donViTinh = await _manualMapper.MapDonViTinhForSanPham(sanPhamRequest.DonViTinh);
                }
                LoaiSp loaiSp = null;
                if (sanPhamRequest.MaLoaiSp != null)
                {
                    loaiSp = await _manualMapper.MapLoaiSanPhamForSanPham(sanPhamRequest.MaLoaiSp);
                }
                SanPhamGop sanPhamGop = null;
                if (sanPhamRequest.SanPhamGop != null)
                {
                    sanPhamGop = await _manualMapper.MapSanPhamGopForSanPham(sanPhamRequest.SanPhamGop);
                }
                LoaiSpNoiBo loaiSpNoiBo = null;
                if (sanPhamRequest.LoaiSpNoiBo != null)
                {
                    loaiSpNoiBo = await _manualMapper.MapLoaiSanPhamNoiBoForSanPham(sanPhamRequest.LoaiSpNoiBo);
                }
                NhomKiemSoat nhomKiemSoat = null;
                if (sanPhamRequest.NhomKiemSoat != null)
                {
                    nhomKiemSoat = await _manualMapper.MapNhomKiemSoatForSanPham(sanPhamRequest.NhomKiemSoat);
                }
                NhomKinhDoanh nhomKinhDoanh = null;
                if (sanPhamRequest.NhomKinhDoanh != null)
                {
                    nhomKinhDoanh = await _manualMapper.MapNhomKinhDoanhForSanPham(sanPhamRequest.NhomKinhDoanh);
                }
                SanPhamKinhDoanh sanPhamKinhDoanh = await GetSanPhamKinhDoanh(sanPhamRequest.MaSanPham);

                List<CanhGiacDuoc> canhGiacDuocs = null;
                if (sanPhamKinhDoanh != null)
                {
                    canhGiacDuocs = await _manualMapper.MapListCanhGiacDuocForSanPham(sanPhamRequest.CanhGiacDuocs, sanPhamRequest.MaSanPham);

                }
               
                List<GhiChuSp> ghiChuSps = null;
                if (sanPhamKinhDoanh != null)
                {
                    ghiChuSps = await _manualMapper.MapListGhiChuSpForSanPham(sanPhamRequest.GhiChuSps, sanPhamRequest.MaSanPham);

                }
               
                List<ThongTinChinh> thongTinChinhs = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinChinhs = await _manualMapper.MapListThongTinChinhForSanPham(sanPhamRequest.ThongTinChinhs, sanPhamRequest.MaSanPham);

                }
                
                List<ThongTinNguonGoc> thongTinNguonGocs = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinNguonGocs = await _manualMapper.MapListThongTinNguonGocForSanPham(sanPhamRequest.ThongTinNguonGocs, sanPhamRequest.MaSanPham);

                }
                

                List<ThongTinPhapLy> thongTinPhapLies = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinPhapLies = await _manualMapper.MapListThongTinPhapLyForSanPham(sanPhamRequest.ThongTinPhapLies, sanPhamRequest.MaSanPham);

                }
               
                List<ThongTinNoiBo> thongTinNoiBos = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinNoiBos = await _manualMapper.MapListThongTinNoiBoForSanPham(sanPhamRequest.ThongTinNoiBos, sanPhamRequest.MaSanPham);

                }
                
                sanPhamKinhDoanhs.Add(_manualMapper.MapSanPhamRequestForSanPham(sanPhamRequest,dangBaoChe, dinhHuongSanPham,dieuKienBaoQuan, donViTinh, sanPhamGop, loaiSp, loaiSpNoiBo, nhomKiemSoat, nhomKinhDoanh ));
            }
            return await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs);
        }


        //public async Task<PostDto> AddOrUpdateSanPhams(List<SanPhamRequest> sanPhamRequests)
        //{
        //    List<SanPhamKinhDoanh> temp = await _manualMapper.MapListSanPhamRequestForListSanPham(sanPhamRequests);
        //    List<SanPhamKinhDoanh> sanPhams = temp;
        //    return await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhams);
        //}
    }
}
