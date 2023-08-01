using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Serialization;
using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models.Request.CreateUpdateSanPham;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.ExternalServices
{
    public class ManualMapper
    {
        private readonly DangBaoCheService _dangBaoCheService;
        private readonly DinhHuongSanPhamServices _dinhHuongSanPhamService;
        private readonly NhomKinhDoanhServices _nhomKinhDoanhServices;
        private readonly NhomKiemSoatServices _nhomKiemSoatServices;
        private readonly DieuKienBaoQuanServices _dieuKienBaoQuanServices;
        private readonly DonViTinhService _donViTinhService;
        private readonly LoaiSpNoiBoServices _loaiSpNoiBoService;
        private readonly SanPhamGopServices _sanPhamGopServices;
        private readonly DanhMucLoaiSpServices _danhMucLoaiSpServices;
        private readonly LoaiSpServices _loaiSpServices;
        private readonly CanhGiacDuocServices _canhGiacDuocServices; 
        private readonly GhiChuSanPhamServices _ghiChuSanPhamServices;
        private readonly ThongTinChinhServices _thongTinChinhServices;
        private readonly ThongTinNguonGocServices _thongTinNguonGocServices;
        private readonly ThongTinPhapLyServices _thongTinPhapLyServices;
        private readonly ThongTinNoiBoServices _thongTinNoiBoServices;

        private readonly IMapper _mapper;

        public ManualMapper(DangBaoCheService dangBaoCheService, DinhHuongSanPhamServices dinhHuongSanPhamServices, NhomKinhDoanhServices nhomKinhDoanhServices, NhomKiemSoatServices nhomKiemSoatServices, DieuKienBaoQuanServices dieuKienBaoQuanServices, DonViTinhService donViTinhService, LoaiSpNoiBoServices loaiSpNoiBoService, SanPhamGopServices sanPhamGop, DanhMucLoaiSpServices danhMucLoaiSpServices, LoaiSpServices loaiSpServices, CanhGiacDuocServices canhGiacDuocServices, GhiChuSanPhamServices ghiChuSanPhamServices, ThongTinChinhServices thongTinChinhServices,ThongTinNguonGocServices thongTinNguonGocServices, ThongTinPhapLyServices thongTinPhapLyServices, ThongTinNoiBoServices thongTinNoiBoServices, IMapper mapper)
        {
            _dangBaoCheService = dangBaoCheService;
            _dinhHuongSanPhamService = dinhHuongSanPhamServices;
            _nhomKinhDoanhServices = nhomKinhDoanhServices;
            _nhomKiemSoatServices = nhomKiemSoatServices;
            _dieuKienBaoQuanServices = dieuKienBaoQuanServices;
            _dinhHuongSanPhamService = dinhHuongSanPhamServices;
            _donViTinhService = donViTinhService;
            _loaiSpNoiBoService = loaiSpNoiBoService;
            _sanPhamGopServices = sanPhamGop;
            _danhMucLoaiSpServices = danhMucLoaiSpServices;
            _loaiSpServices = loaiSpServices;
            _canhGiacDuocServices = canhGiacDuocServices;
            _ghiChuSanPhamServices = ghiChuSanPhamServices;
            _thongTinChinhServices = thongTinChinhServices;
            _thongTinPhapLyServices = thongTinPhapLyServices;
            _thongTinNguonGocServices = thongTinNguonGocServices;
            _thongTinNoiBoServices = thongTinNoiBoServices;
            _mapper = mapper;
        }

        

        public SanPhamKinhDoanh MapSanPhamKinhDoanhRequestForSanPham(SanPhamRequest sanPhamRequest, DangBaoChe dang, DinhHuongSanPham dinhHuongSanPham, DieuKienBaoQuan dieuKienBaoQuan, DonViTinh donViTinh, SanPhamGop sanPhamGop, LoaiSp loaiSp, LoaiSpNoiBo loaiSpNoiBo, NhomKiemSoat nhomKiemSoat, NhomKinhDoanh nhomKinhDoanh, ICollection<CanhGiacDuoc> canhGiacDuocs, ICollection<GhiChuSp> ghiChuSps, ICollection<ThongTinChinh> thongTinChinhs, ICollection<ThongTinNguonGoc> thongTinNguonGocs,ICollection<ThongTinNoiBo> thongTinNoiBos, ICollection<ThongTinPhapLy> thongTinPhapLies)
        {
            SanPhamKinhDoanh sanPhamKinhDoanh = _mapper.Map<SanPhamKinhDoanh>(sanPhamRequest);
            sanPhamKinhDoanh.MaDangBaoCheNavigation = dang;
            sanPhamKinhDoanh.MaDinhHuongNavigation = dinhHuongSanPham;
            sanPhamKinhDoanh.MaDkbqNavigation = dieuKienBaoQuan;
            sanPhamKinhDoanh.MaDvtNavigation = donViTinh;
            sanPhamKinhDoanh.MaGopNavigation = sanPhamGop;
            sanPhamKinhDoanh.MaLoaiSpNavigation = loaiSp;
            sanPhamKinhDoanh.MaLoaiSpNoiBoNavigation = loaiSpNoiBo;
            sanPhamKinhDoanh.MaNhomKiemSoatNavigation = nhomKiemSoat;
            sanPhamKinhDoanh.MaNhomKinhDoanhNavigation = nhomKinhDoanh;
            sanPhamKinhDoanh.CanhGiacDuocs = canhGiacDuocs;
            sanPhamKinhDoanh.GhiChuSps = ghiChuSps;
            sanPhamKinhDoanh.ThongTinChinhs = thongTinChinhs;
            sanPhamKinhDoanh.ThongTinNguonGocs = thongTinNguonGocs;
            sanPhamKinhDoanh.ThongTinPhapLies = thongTinPhapLies;
            sanPhamKinhDoanh.ThongTinNoiBos = thongTinNoiBos;
            return sanPhamKinhDoanh;
        }


        public SanPhamKinhDoanh MapSanPhamKinhDoanh(SanPhamRequest sanPhamRequest, DangBaoChe dang, DinhHuongSanPham dinhHuongSanPham, DieuKienBaoQuan dieuKienBaoQuan, DonViTinh donViTinh, SanPhamGop sanPhamGop, LoaiSp loaiSp, LoaiSpNoiBo loaiSpNoiBo, NhomKiemSoat nhomKiemSoat, NhomKinhDoanh nhomKinhDoanh)
        {
            SanPhamKinhDoanh sanPhamKinhDoanh = _mapper.Map<SanPhamKinhDoanh>(sanPhamRequest);
            sanPhamKinhDoanh.MaDangBaoCheNavigation = dang;
            sanPhamKinhDoanh.MaDinhHuongNavigation = dinhHuongSanPham;
            sanPhamKinhDoanh.MaDkbqNavigation = dieuKienBaoQuan;
            sanPhamKinhDoanh.MaDvtNavigation = donViTinh;
            sanPhamKinhDoanh.MaGopNavigation = sanPhamGop;
            sanPhamKinhDoanh.MaLoaiSpNavigation = loaiSp;
            sanPhamKinhDoanh.MaLoaiSpNoiBoNavigation = loaiSpNoiBo;
            sanPhamKinhDoanh.MaNhomKiemSoatNavigation = nhomKiemSoat;
            sanPhamKinhDoanh.MaNhomKinhDoanhNavigation = nhomKinhDoanh;
            return sanPhamKinhDoanh;
        }

        public async Task<List<SanPhamKinhDoanh>> MapListSanPhamRequestForListSanPham(List<SanPhamRequest> sanPhamRequests)
        {
            List<SanPhamKinhDoanh> sanPhamKinhDoanhs = new List<SanPhamKinhDoanh>();
            foreach(SanPhamRequest sanPhamRequest in sanPhamRequests)
            {
                DangBaoChe dangBaoChe = null;
                if(sanPhamRequest.MaDangBaoChe != null)
                {
                    dangBaoChe = await MapDangBaoCheForSanPham(sanPhamRequest.MaDangBaoChe);                   
                }

                DinhHuongSanPham dinhHuongSanPham = null;
                if(sanPhamRequest.MaDinhHuong != null)
                {
                    dinhHuongSanPham = await MapDinhHuongSanPhamForSanPham(sanPhamRequest.MaDinhHuong);
                }
                DieuKienBaoQuan dieuKienBaoQuan = null;
                if(sanPhamRequest.MaDkbq != null)
                {
                    dieuKienBaoQuan = await MapDieuKienBaoQuanForSanPham(sanPhamRequest.MaDkbq);
                }
                DonViTinh donViTinh = null;
                if(sanPhamRequest.MaDvt != null)
                {
                    donViTinh = await MapDonViTinhForSanPham(sanPhamRequest.MaDvt);
                }
                LoaiSp loaiSp = null;
                if(sanPhamRequest.MaLoaiSp != null)
                {
                    loaiSp = await MapLoaiSanPhamForSanPham(sanPhamRequest.MaLoaiSp);
                }
                SanPhamGop sanPhamGop = null;
                if(sanPhamRequest.MaGop != null)
                {
                    sanPhamGop = await MapSanPhamGopForSanPham(sanPhamRequest.MaGop);
                }
                LoaiSpNoiBo loaiSpNoiBo = null;
                if(sanPhamRequest.MaLoaiSpNoiBo != null)
                {
                    loaiSpNoiBo = await MapLoaiSanPhamNoiBoForSanPham(sanPhamRequest.MaLoaiSpNoiBo);
                }
                NhomKiemSoat nhomKiemSoat = null;
                if(sanPhamRequest.MaNhomKiemSoat != null)
                {
                    nhomKiemSoat = await MapNhomKiemSoatForSanPham(sanPhamRequest.MaNhomKiemSoat);
                }
                NhomKinhDoanh nhomKinhDoanh = null;
                if (sanPhamRequest.MaNhomKinhDoanh != null)
                {
                    nhomKinhDoanh = await MapNhomKinhDoanhForSanPham(sanPhamRequest.MaNhomKinhDoanh);
                }

                List<CanhGiacDuoc> canhGiacDuocs = await MapListCanhGiacDuocForSanPham(sanPhamRequest.CanhGiacDuocs, sanPhamRequest.MaSanPham);
                List<GhiChuSp> ghiChuSps = await MapListGhiChuSpForSanPham(sanPhamRequest.GhiChuSps);
                List<ThongTinChinh> thongTinChinhs = await MapListThongTinChinhForSanPham(sanPhamRequest.ThongTinChinhs);
                List<ThongTinNguonGoc> thongTinNguonGocs = await MapListThongTinNguonGocForSanPham(sanPhamRequest.ThongTinNguonGocs);
                List<ThongTinPhapLy> thongTinPhapLies = await MapListThongTinPhapLyForSanPham(sanPhamRequest.ThongTinPhapLies);
                List<ThongTinNoiBo> thongTinNoiBos = await MapListThongTinNoiBoForSanPham(sanPhamRequest.ThongTinNoiBos);

                sanPhamKinhDoanhs.Add(MapSanPhamKinhDoanhRequestForSanPham(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!, canhGiacDuocs, ghiChuSps, thongTinChinhs, thongTinNguonGocs, thongTinNoiBos, thongTinPhapLies));
            }
            return sanPhamKinhDoanhs;
        }

        public async Task<DangBaoChe> MapDangBaoCheForSanPham(string maDangBaoChe)
        {
            DangBaoChe dangBaoChe = await _dangBaoCheService.GetDangBaoChe(maDangBaoChe);
            if (dangBaoChe == null)
            {
                dangBaoChe = new DangBaoChe
                {
                    MaDangBaoChe = maDangBaoChe,
                    DangBaoCheDacBiet = "temp",
                    DangBaoChe1 = "TEMP",
                    MoTa = "ok"

                };
                await _dangBaoCheService.AddAsync(dangBaoChe);
            }
            return dangBaoChe;
        }

        public async Task<DinhHuongSanPham> MapDinhHuongSanPhamForSanPham(string maDinhHuongSanPham)
        {
            DinhHuongSanPham dinhHuongSanPham = await _dinhHuongSanPhamService.GetDinhHuongSanAsync(maDinhHuongSanPham);
            if (dinhHuongSanPham == null)
            {
                dinhHuongSanPham = new DinhHuongSanPham
                {
                    MaDinhHuong = maDinhHuongSanPham,
                    TenDinhHuong = "temp",
                    MoTa = ""

                };
                await _dinhHuongSanPhamService.AddAsync(dinhHuongSanPham);
            }
            return dinhHuongSanPham;

        }

        public async Task<DieuKienBaoQuan> MapDieuKienBaoQuanForSanPham(string maDkbq)
        {
            DieuKienBaoQuan dieuKienBaoQuan = await _dieuKienBaoQuanServices.GetDieuKienBaoQuan(maDkbq);
            if (dieuKienBaoQuan == null)
            {
                dieuKienBaoQuan = new DieuKienBaoQuan
                {
                    MaDkbq = maDkbq,
                    DieuKienBaoQuan1 = "",
                    MoTa = ""

                };
                await _dieuKienBaoQuanServices.AddAsync(dieuKienBaoQuan);
            }
            return dieuKienBaoQuan;

        }

        public async Task<DonViTinh> MapDonViTinhForSanPham(string maDonViTinh)
        {
            DonViTinh donViTinh = await _donViTinhService.GetDonViTinh(maDonViTinh);
            if (donViTinh == null)
            {
                donViTinh = new DonViTinh
                {
                    MaDvt = maDonViTinh,
                    DvtCoSo = ""

                };
                await _donViTinhService.AddAsync(donViTinh);
            }
            return donViTinh;

        }

        public async Task<SanPhamGop> MapSanPhamGopForSanPham(string maGop)
        {
            SanPhamGop sanPhamGop = await _sanPhamGopServices.GetSanPhamGop(maGop);
            if (sanPhamGop == null)
            {
                sanPhamGop = new SanPhamGop
                {
                    MaGop = maGop,
                    GhiChu = ""
                };
                await _sanPhamGopServices.AddAsync(sanPhamGop);
            }
            return sanPhamGop;
        }

        public async Task<LoaiSp> MapLoaiSanPhamForSanPham(string maLoaiSanPham)
        {
            LoaiSp loaiSp = await _loaiSpServices.GetLoaisp(maLoaiSanPham);
            if (loaiSp == null)
            {
                loaiSp = new LoaiSp
                {
                    MaLoaiSp = maLoaiSanPham,
                    TenLoaiSp = "",
                    DinhNghia = "",
                    MaDanhMucLsp = "" // maDanhMucLoaiSp Phai la so va tu tang.
                };
                await _loaiSpServices.AddAsync(loaiSp);
            }
            return loaiSp;
        }

        public async Task<LoaiSpNoiBo> MapLoaiSanPhamNoiBoForSanPham(string maLoaiSanPhamNoiBo)
        {
            LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoService.GetLoaiSpNoiBo(maLoaiSanPhamNoiBo);
            if (loaiSpNoiBo == null)
            {
                loaiSpNoiBo = new LoaiSpNoiBo
                {
                    MaLoaiSpNoiBo = maLoaiSanPhamNoiBo,
                    TenLoaiSpNoiBo = "",
                    KyHieuVietTat = "",
                    GhiChu = ""
                };
                await _loaiSpNoiBoService.AddAsync(loaiSpNoiBo);
            }
            return loaiSpNoiBo;
        }

        public async Task<NhomKiemSoat> MapNhomKiemSoatForSanPham(string maNhomKiemSoat)
        {
            NhomKiemSoat nhomKiemSoat = await _nhomKiemSoatServices.GetNhomKiemSoat(maNhomKiemSoat);
            if (nhomKiemSoat == null)
            {
                nhomKiemSoat = new NhomKiemSoat
                {
                    MaNhomKiemSoat = maNhomKiemSoat,
                    TenNhomKiemSoat = "",
                    YNghia = "",
                    GhiChu = ""
                };
                await _nhomKiemSoatServices.AddAsync(nhomKiemSoat);
            }
            return nhomKiemSoat;
        }

        public async Task<NhomKinhDoanh> MapNhomKinhDoanhForSanPham(string maNhomKinhDoanh)
        {
            NhomKinhDoanh nhomKinhDoanh = await _nhomKinhDoanhServices.GetNhomKinhDoanhAsync(maNhomKinhDoanh);
            if (nhomKinhDoanh == null)
            {
                nhomKinhDoanh = new NhomKinhDoanh
                {
                    MaNhomKinhDoanh = maNhomKinhDoanh,
                    TenNhomKinhDoanh = "",
                    KyHieuVietTat = "",
                    YNghia = "",
                    GhiChu = ""
                };
                await _nhomKinhDoanhServices.AddAsync(nhomKinhDoanh);
            }
            return nhomKinhDoanh;
        }

        public async Task<List<CanhGiacDuoc>> MapListCanhGiacDuocForSanPham(ICollection<SP_CanhGiacDuocRequest> canhGiacDuocRequests, string maSanPham)
        {
            List<CanhGiacDuoc> canhGiacDuocs = new List<CanhGiacDuoc>();
            foreach(SP_CanhGiacDuocRequest canhGiacDuocRequest in canhGiacDuocRequests)
            {
                CanhGiacDuoc canhGiacDuoc = await _canhGiacDuocServices.GetCanhGiacDuoc(canhGiacDuocRequest.MaCdg);
                if(canhGiacDuoc == null) {
                    canhGiacDuoc = new CanhGiacDuoc
                    {
                        MaCdg = canhGiacDuocRequest.MaCdg,
                        MaSanPham = maSanPham,
                        CanhGiacDuoc1 = canhGiacDuocRequest.CanhGiacDuoc1,
                        TacDungPhu = canhGiacDuocRequest.TacDungPhu,
                        CongDung = canhGiacDuocRequest.CongDung,
                        TuongTacThuoc = canhGiacDuocRequest.TuongTacThuoc
                    };
                     await _canhGiacDuocServices.AddAsync(canhGiacDuoc!);
                }
                canhGiacDuocs.Add(canhGiacDuoc);
            }
            return canhGiacDuocs;
        }

        public async Task<List<GhiChuSp>> MapListGhiChuSpForSanPham(ICollection<SP_GhiChuSanPhamRequest> sP_GhiChuSanPhamRequests)
        {
            List<GhiChuSp> canhGiacDuocs = new List<GhiChuSp>();
            foreach (SP_GhiChuSanPhamRequest ghiChuSanPhamRequest in sP_GhiChuSanPhamRequests)
            {
                GhiChuSp ghiChuSp = await _ghiChuSanPhamServices.FindByNameAsync(ghiChuSanPhamRequest.GhiChu1!);
                if (ghiChuSp == null)
                {
                    ghiChuSp = new GhiChuSp
                    {
                        MaGhiChu = ghiChuSanPhamRequest.MaGhiChu,
                        GhiChu1 = ghiChuSanPhamRequest.GhiChu1,
                        GhiChu2 = ghiChuSanPhamRequest.GhiChu2,
                        GhiChu3 = ghiChuSanPhamRequest.GhiChu3
                    };
                    await _ghiChuSanPhamServices.AddAsync(ghiChuSp!);
                }
                canhGiacDuocs.Add(ghiChuSp);
            }
            return canhGiacDuocs;
        }
        
        public async Task<List<ThongTinChinh>> MapListThongTinChinhForSanPham(ICollection<SP_ThongTinChinhRequest> sP_ThongTinChinhRequests)
        {
            List<ThongTinChinh> thongTinChinhs = new List<ThongTinChinh>();
            foreach (SP_ThongTinChinhRequest thongTinChinhRequest in sP_ThongTinChinhRequests)
            {
                ThongTinChinh thongTinChinh = await _thongTinChinhServices.GetThongTinChinh(thongTinChinhRequest.MaTcc);
                if (thongTinChinh == null)
                {
                    thongTinChinh = new ThongTinChinh
                    {
                        MaTcc = thongTinChinhRequest.MaTcc,
                        HoatChat = thongTinChinhRequest.HoatChat,
                        HamLuong = thongTinChinhRequest.HamLuong,
                        PhamViPhanPhoi = thongTinChinhRequest.PhamViPhanPhoi,
                        DuongDung = thongTinChinhRequest.DuongDung,
                        LieuDung = thongTinChinhRequest.LieuDung,
                        NhomDieuTri = thongTinChinhRequest.NhomDieuTri,
                        HanDung = thongTinChinhRequest.HanDung,
                        KeToa = thongTinChinhRequest.KeToa


                    };
                    await _thongTinChinhServices.AddAsync(thongTinChinh);
                }
                thongTinChinhs.Add(thongTinChinh);
            }
            return thongTinChinhs;
        }
        public async Task<List<ThongTinNguonGoc>> MapListThongTinNguonGocForSanPham(ICollection<SP_ThongTinNguonGocRequest> sP_ThongTinNguonGocRequests)
        {
            List<ThongTinNguonGoc> thongTinNguonGocs = new List<ThongTinNguonGoc>();
            foreach (SP_ThongTinNguonGocRequest thongTinNguonGocRequest in sP_ThongTinNguonGocRequests)
            {
                ThongTinNguonGoc thongTinNguonGoc = await _thongTinNguonGocServices.GetThongTinNguonGoc(thongTinNguonGocRequest.MaTtng);
                if (thongTinNguonGoc == null)
                {
                    thongTinNguonGoc = new ThongTinNguonGoc
                    {
                        MaTtng = thongTinNguonGocRequest.MaTtng,
                        SoDangKy = thongTinNguonGocRequest.SoDangKy,
                        SoQdGiaHan = thongTinNguonGocRequest.SoQdGiaHan,
                        HieuLucSdk = thongTinNguonGocRequest.HieuLucSdk,
                        NuocSanXuat = thongTinNguonGocRequest.NuocSanXuat,
                        NhaSanXuat = thongTinNguonGocRequest.NhaSanXuat,
                        XuatXu = thongTinNguonGocRequest.XuatXu,
                        TieuChuanSanXuat = thongTinNguonGocRequest.TieuChuanSanXuat,
                        SdkVoThoiHan = thongTinNguonGocRequest.SdkVoThoiHan
                        
                    };
                    await _thongTinNguonGocServices.AddAsync(thongTinNguonGoc);
                }
                thongTinNguonGocs.Add(thongTinNguonGoc);
            }
            return thongTinNguonGocs;
        }

        public async Task<List<ThongTinPhapLy>> MapListThongTinPhapLyForSanPham(ICollection<SP_ThongTinPhapLyRequest> sP_ThongTinPhapLyRequests)
        {
            List<ThongTinPhapLy> thongTinPhapLies = new List<ThongTinPhapLy>();
            foreach (SP_ThongTinPhapLyRequest thongTinPhapLyRequest in sP_ThongTinPhapLyRequests)
            {
                ThongTinPhapLy thongTinPhapLy = await _thongTinPhapLyServices.GetThongTinPhapLy(thongTinPhapLyRequest.MaTtpl);
                if (thongTinPhapLy == null)
                {
                    thongTinPhapLy = new ThongTinPhapLy
                    {
                       MaTtpl = thongTinPhapLyRequest.MaTtpl,
                       SttTheoTt3015 = thongTinPhapLyRequest.SttTheoTt3015,
                       SttTheoTt15 =  thongTinPhapLyRequest.SttTheoTt15,
                       NhomTheoTt3015 = thongTinPhapLyRequest.NhomTheoTt3015,
                       NhomTheoTt15 = thongTinPhapLyRequest.NhomTheoTt15
                    };
                    await _thongTinPhapLyServices.AddAsync(thongTinPhapLy);
                }
                thongTinPhapLies.Add(thongTinPhapLy);
            }
            return thongTinPhapLies;
        }

        public async Task<List<ThongTinNoiBo>> MapListThongTinNoiBoForSanPham(ICollection<SP_ThongTinNoiBoRequest> sP_ThongTinNoiBoRequests)
        {
            List<ThongTinNoiBo> thongTinNoiBos = new List<ThongTinNoiBo>();
            foreach (SP_ThongTinNoiBoRequest thongTinNoiBoRequest in sP_ThongTinNoiBoRequests)
            {
                ThongTinNoiBo thongTinNoiBo = await _thongTinNoiBoServices.GetThongTinNoiBo(thongTinNoiBoRequest.MaTtnb);
                if (thongTinNoiBo == null)
                {
                    thongTinNoiBo = new ThongTinNoiBo
                    {
                        MaTtnb = thongTinNoiBoRequest.MaTtnb,
                        NgayTao = thongTinNoiBoRequest.NgayTao,
                        UserTao = thongTinNoiBoRequest.UserTao,
                        NgayNgungSanPham = thongTinNoiBoRequest.NgayNgungSanPham,
                        NgaySinhNhatSp = thongTinNoiBoRequest.NgaySinhNhatSp,
                        TheoDoiSanPham = thongTinNoiBoRequest.TheoDoiSanPham,
                        QuanLySanPham = thongTinNoiBoRequest.QuanLySanPham,
                        TrangThaiHoSo = thongTinNoiBoRequest.TrangThaiHoSo,
                        LamToRoiHayKhong = thongTinNoiBoRequest.LamToRoiHayKhong,
                        XinCapPhepQc = thongTinNoiBoRequest.XinCapPhepQc,
                        DaDuocCapPhepTtThuocQc = thongTinNoiBoRequest.DaDuocCapPhepTtThuocQc,
                        TinhTrangToRoiNcc = thongTinNoiBoRequest.TinhTrangToRoiNcc

                    };
                    await _thongTinNoiBoServices.AddAsync(thongTinNoiBo);
                }
                thongTinNoiBos.Add(thongTinNoiBo);
            }
            return thongTinNoiBos;
        }
    }
}
