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
                List<SanPhamKinhDoanh> sanPhamKinhDoanhs1 = new List<SanPhamKinhDoanh>();
                DangBaoChe dangBaoChe = null;
                if (sanPhamRequest.MaDangBaoChe != null)
                {
                    dangBaoChe = await _manualMapper.MapDangBaoCheForSanPham(sanPhamRequest.MaDangBaoChe);
                }

                DinhHuongSanPham dinhHuongSanPham = null;
                if (sanPhamRequest.MaDinhHuong != null)
                {
                    dinhHuongSanPham = await _manualMapper.MapDinhHuongSanPhamForSanPham(sanPhamRequest.MaDinhHuong);
                }
                DieuKienBaoQuan dieuKienBaoQuan = null;
                if (sanPhamRequest.MaDkbq != null)
                {
                    dieuKienBaoQuan = await _manualMapper.MapDieuKienBaoQuanForSanPham(sanPhamRequest.MaDkbq);
                }
                DonViTinh donViTinh = null;
                if (sanPhamRequest.MaDvt != null)
                {
                    donViTinh = await _manualMapper.MapDonViTinhForSanPham(sanPhamRequest.MaDvt);
                }
                LoaiSp loaiSp = null;
                if (sanPhamRequest.MaLoaiSp != null)
                {
                    loaiSp = await _manualMapper.MapLoaiSanPhamForSanPham(sanPhamRequest.MaLoaiSp);
                }
                SanPhamGop sanPhamGop = null;
                if (sanPhamRequest.MaGop != null)
                {
                    sanPhamGop = await _manualMapper.MapSanPhamGopForSanPham(sanPhamRequest.MaGop);
                }
                LoaiSpNoiBo loaiSpNoiBo = null;
                if (sanPhamRequest.MaLoaiSpNoiBo != null)
                {
                    loaiSpNoiBo = await _manualMapper.MapLoaiSanPhamNoiBoForSanPham(sanPhamRequest.MaLoaiSpNoiBo);
                }
                NhomKiemSoat nhomKiemSoat = null;
                if (sanPhamRequest.MaNhomKiemSoat != null)
                {
                    nhomKiemSoat = await _manualMapper.MapNhomKiemSoatForSanPham(sanPhamRequest.MaNhomKiemSoat);
                }
                NhomKinhDoanh nhomKinhDoanh = null;
                if (sanPhamRequest.MaNhomKinhDoanh != null)
                {
                    nhomKinhDoanh = await _manualMapper.MapNhomKinhDoanhForSanPham(sanPhamRequest.MaNhomKinhDoanh);
                }
                SanPhamKinhDoanh sanPhamKinhDoanh = await GetSanPhamKinhDoanh(sanPhamRequest.MaSanPham);

                List<CanhGiacDuoc> canhGiacDuocs = null;
                if (sanPhamKinhDoanh != null)
                {
                    canhGiacDuocs = await _manualMapper.MapListCanhGiacDuocForSanPham(sanPhamRequest.CanhGiacDuocs, sanPhamRequest.MaSanPham);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    canhGiacDuocs = await _manualMapper.MapListCanhGiacDuocForSanPham(sanPhamRequest.CanhGiacDuocs, sanPhamRequest.MaSanPham);

                }

                List<GhiChuSp> ghiChuSps = null;
                if (sanPhamKinhDoanh != null)
                {
                    ghiChuSps = await _manualMapper.MapListGhiChuSpForSanPham(sanPhamRequest.GhiChuSps, sanPhamRequest.MaSanPham);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    ghiChuSps = await _manualMapper.MapListGhiChuSpForSanPham(sanPhamRequest.GhiChuSps, sanPhamRequest.MaSanPham);

                }
                List<ThongTinChinh> thongTinChinhs = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinChinhs = await _manualMapper.MapListThongTinChinhForSanPham(sanPhamRequest.ThongTinChinhs);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    thongTinChinhs = await _manualMapper.MapListThongTinChinhForSanPham(sanPhamRequest.ThongTinChinhs);

                }


                List<ThongTinNguonGoc> thongTinNguonGocs = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinNguonGocs = await _manualMapper.MapListThongTinNguonGocForSanPham(sanPhamRequest.ThongTinNguonGocs);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    thongTinNguonGocs = await _manualMapper.MapListThongTinNguonGocForSanPham(sanPhamRequest.ThongTinNguonGocs);
                }

                List<ThongTinPhapLy> thongTinPhapLies = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinPhapLies = await _manualMapper.MapListThongTinPhapLyForSanPham(sanPhamRequest.ThongTinPhapLies);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    thongTinPhapLies = await _manualMapper.MapListThongTinPhapLyForSanPham(sanPhamRequest.ThongTinPhapLies);
                }

                List<ThongTinNoiBo> thongTinNoiBos = null;
                if (sanPhamKinhDoanh != null)
                {
                    thongTinNoiBos = await _manualMapper.MapListThongTinNoiBoForSanPham(sanPhamRequest.ThongTinNoiBos);

                }
                else
                {
                    SanPhamKinhDoanh temp = _manualMapper.MapSanPhamKinhDoanh(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!);
                    sanPhamKinhDoanhs1.Add(temp);
                    await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs1);
                    thongTinNoiBos = await _manualMapper.MapListThongTinNoiBoForSanPham(sanPhamRequest.ThongTinNoiBos);

                }
                sanPhamKinhDoanhs.Add(_manualMapper.MapSanPhamKinhDoanhRequestForSanPham(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!, canhGiacDuocs, ghiChuSps, thongTinChinhs, thongTinNguonGocs, thongTinNoiBos, thongTinPhapLies));
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
