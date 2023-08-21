﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Serialization;
using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models.Request.CreateUpdateSanPham;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Service.RepositoryServices;
using trackingPlatform.Utils;

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

        public SanPhamKinhDoanh MapSanPhamRequestForSanPham(SanPhamRequest sanPhamRequest, DangBaoChe dang, DinhHuongSanPham dinhHuongSanPham, DieuKienBaoQuan dieuKienBaoQuan, DonViTinh donViTinh, SanPhamGop sanPhamGop, LoaiSp loaiSp, LoaiSpNoiBo loaiSpNoiBo, NhomKiemSoat nhomKiemSoat, NhomKinhDoanh nhomKinhDoanh)
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
        public async Task<DangBaoChe> MapDangBaoCheForSanPham(DangBaoChe dBaoChe)
        {
            DangBaoChe dangBaoChe = await _dangBaoCheService.GetDangBaoChe(dBaoChe.MaDangBaoChe);
            if (dangBaoChe == null)
            {
                dangBaoChe = new DangBaoChe
                {
                    MaDangBaoChe = dBaoChe.MaDangBaoChe,
                    DangBaoCheDacBiet = dBaoChe.DangBaoCheDacBiet,
                    DangBaoChe1 = dBaoChe.DangBaoChe1,
                    MoTa = dBaoChe.MoTa

                };
                await _dangBaoCheService.AddAsync(dangBaoChe);
            }
            return dangBaoChe;
        }

        public async Task<DinhHuongSanPham> MapDinhHuongSanPhamForSanPham(DinhHuongSanPham dhsp)
        {
            DinhHuongSanPham dinhHuongSanPham = await _dinhHuongSanPhamService.GetDinhHuongSanAsync(dhsp.MaDinhHuong);
            if (dinhHuongSanPham == null)
            {
                dinhHuongSanPham = new DinhHuongSanPham
                {
                    MaDinhHuong = dhsp.MaDinhHuong,
                    TenDinhHuong = dhsp.TenDinhHuong,
                    MoTa = dhsp.MoTa

                };
                await _dinhHuongSanPhamService.AddAsync(dinhHuongSanPham);
            }
            return dinhHuongSanPham;

        }

        public async Task<DieuKienBaoQuan> MapDieuKienBaoQuanForSanPham(DieuKienBaoQuan dkbq)
        {
            DieuKienBaoQuan dieuKienBaoQuan = await _dieuKienBaoQuanServices.GetDieuKienBaoQuan(dkbq.MaDkbq);
            if (dieuKienBaoQuan == null)
            {
                dieuKienBaoQuan = new DieuKienBaoQuan
                {
                    MaDkbq = dkbq.MaDkbq,
                    DieuKienBaoQuan1 = dkbq.DieuKienBaoQuan1,
                    MoTa = dkbq.MoTa

                };
                await _dieuKienBaoQuanServices.AddAsync(dieuKienBaoQuan);
            }
            return dieuKienBaoQuan;

        }

        public async Task<DonViTinh> MapDonViTinhForSanPham(DonViTinh dvt)
        {
            DonViTinh donViTinh = await _donViTinhService.GetDonViTinh(dvt.MaDvt);
            if (donViTinh == null)
            {
                donViTinh = new DonViTinh
                {
                    MaDvt = dvt.MaDvt,
                    DvtCoSo = dvt.DvtCoSo

                };
                await _donViTinhService.AddAsync(donViTinh);
            }
            return donViTinh;

        }

        public async Task<SanPhamGop> MapSanPhamGopForSanPham(SanPhamGop spg)
        {
            SanPhamGop sanPhamGop = await _sanPhamGopServices.GetSanPhamGop(spg.MaGop);
            if (sanPhamGop == null)
            {
                sanPhamGop = new SanPhamGop
                {
                    MaGop = spg.MaGop,
                    GhiChu = spg.GhiChu
                };
                await _sanPhamGopServices.AddAsync(sanPhamGop);
            }
            return sanPhamGop;
        }

        public async Task<LoaiSp> MapLoaiSanPhamForSanPham(string maLoaiSp)
        {
            LoaiSp loaiSp = await _loaiSpServices.GetLoaisp(maLoaiSp);
            if (loaiSp == null)
            {
                loaiSp = new LoaiSp
                {
                    MaLoaiSp = maLoaiSp,
                    TenLoaiSp = "",
                    DinhNghia = "",
                    MaDanhMucLsp = "" // maDanhMucLoaiSp Phai la so va tu tang.
                };
                await _loaiSpServices.AddAsync(loaiSp);
            }
            return loaiSp;
        }

        public async Task<LoaiSpNoiBo> MapLoaiSanPhamNoiBoForSanPham(LoaiSpNoiBo lspnb)
        {
            LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoService.GetLoaiSpNoiBo(lspnb.MaLoaiSpNoiBo);
            if (loaiSpNoiBo == null)
            {
                loaiSpNoiBo = new LoaiSpNoiBo
                {
                    MaLoaiSpNoiBo = lspnb.MaLoaiSpNoiBo,
                    TenLoaiSpNoiBo = lspnb.TenLoaiSpNoiBo,
                    KyHieuVietTat = lspnb.KyHieuVietTat,
                    GhiChu = lspnb.GhiChu
                };
                await _loaiSpNoiBoService.AddAsync(loaiSpNoiBo);
            }
            return loaiSpNoiBo;
        }

        public async Task<NhomKiemSoat> MapNhomKiemSoatForSanPham(NhomKiemSoat nks)
        {
            NhomKiemSoat nhomKiemSoat = await _nhomKiemSoatServices.GetNhomKiemSoat(nks.MaNhomKiemSoat);
            if (nhomKiemSoat == null)
            {
                nhomKiemSoat = new NhomKiemSoat
                {
                    MaNhomKiemSoat = nks.MaNhomKiemSoat,
                    TenNhomKiemSoat = nks.TenNhomKiemSoat,
                    YNghia = nks.YNghia,
                    GhiChu = nks.GhiChu
                };
                await _nhomKiemSoatServices.AddAsync(nhomKiemSoat);
            }
            return nhomKiemSoat;
        }

        public async Task<NhomKinhDoanh> MapNhomKinhDoanhForSanPham(NhomKinhDoanh nkd)
        {
            NhomKinhDoanh nhomKinhDoanh = await _nhomKinhDoanhServices.GetNhomKinhDoanhAsync(nkd.MaNhomKinhDoanh);
            if (nhomKinhDoanh == null)
            {
                nhomKinhDoanh = new NhomKinhDoanh
                {
                    MaNhomKinhDoanh = nkd.MaNhomKinhDoanh,
                    TenNhomKinhDoanh = nkd.TenNhomKinhDoanh,
                    KyHieuVietTat = nkd.KyHieuVietTat,
                    YNghia = nkd.YNghia,
                    GhiChu = nkd.GhiChu
                };
                await _nhomKinhDoanhServices.AddAsync(nhomKinhDoanh);
            }
            return nhomKinhDoanh;
        }

        public async Task<List<CanhGiacDuoc>> MapListCanhGiacDuocForSanPham(ICollection<SP_CanhGiacDuocRequest> canhGiacDuocRequests, string maSanPham)
        {
            List<CanhGiacDuoc> canhGiacDuocs = new List<CanhGiacDuoc>();
            foreach (SP_CanhGiacDuocRequest canhGiacDuocRequest in canhGiacDuocRequests)
            {
                CanhGiacDuoc canhGiacDuoc = await _canhGiacDuocServices.GetCanhGiacDuoc(canhGiacDuocRequest.MaCdg);
                if (canhGiacDuoc == null) {
                    canhGiacDuoc = new CanhGiacDuoc
                    {
                        MaCdg = canhGiacDuocRequest.MaCdg,
                        MaSanPham = maSanPham,
                        CanhGiacDuoc1 = canhGiacDuocRequest.CanhGiacDuoc1,
                        TacDungPhu = canhGiacDuocRequest.TacDungPhu,
                        CongDung = canhGiacDuocRequest.CongDung,
                        TuongTacThuoc = canhGiacDuocRequest.TuongTacThuoc
                    };
                    await _canhGiacDuocServices.AddAsync(canhGiacDuoc);
                }
                else
                {
                    canhGiacDuoc = UpdateCanhGiacDuocUtils.UpdateCanhGiacDuocRequest(canhGiacDuoc, canhGiacDuocRequest);
                }
                canhGiacDuocs.Add(canhGiacDuoc);
            }
            return canhGiacDuocs;
        }

        public async Task<List<GhiChuSp>> MapListGhiChuSpForSanPham(ICollection<SP_GhiChuSanPhamRequest> sP_GhiChuSanPhamRequests, string maSanPham)
        {
            List<GhiChuSp> canhGiacDuocs = new List<GhiChuSp>();
            foreach (SP_GhiChuSanPhamRequest ghiChuSanPhamRequest in sP_GhiChuSanPhamRequests)
            {
                GhiChuSp ghiChuSp = await _ghiChuSanPhamServices.GetGhiChuSanPham(ghiChuSanPhamRequest.MaGhiChu);
                if (ghiChuSp == null)
                {
                    ghiChuSp = new GhiChuSp
                    {
                        MaGhiChu = ghiChuSanPhamRequest.MaGhiChu,
                        MaSanPham = maSanPham,
                        GhiChu1 = ghiChuSanPhamRequest.GhiChu1,
                        GhiChu2 = ghiChuSanPhamRequest.GhiChu2,
                        GhiChu3 = ghiChuSanPhamRequest.GhiChu3
                    };
                    await _ghiChuSanPhamServices.AddAsync(ghiChuSp!);
                }
                else
                {
                    ghiChuSp = GhiChuSpUtils.UpdateGhiChuSpRequest(ghiChuSp, ghiChuSanPhamRequest);
                }
                canhGiacDuocs.Add(ghiChuSp);
            }
            return canhGiacDuocs;
        }
        
        public async Task<List<ThongTinChinh>> MapListThongTinChinhForSanPham(ICollection<SP_ThongTinChinhRequest> sP_ThongTinChinhRequests, string maSanPham)
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
                        MaSanPham = maSanPham,
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
                else
                {
                    thongTinChinh = ThongTinChinhUtils.UpdateThongTinChinhRequest(thongTinChinh, thongTinChinhRequest);
                }
                thongTinChinhs.Add(thongTinChinh);
            }
            return thongTinChinhs;
        }
        public async Task<List<ThongTinNguonGoc>> MapListThongTinNguonGocForSanPham(ICollection<SP_ThongTinNguonGocRequest> sP_ThongTinNguonGocRequests, string maSanPham)
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
                        MaSanPham = maSanPham,
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
                else
                {
                    thongTinNguonGoc = ThongTinNguoGocUtils.UpdateThongTinNguonGocRequest(thongTinNguonGoc, thongTinNguonGocRequest);
                }
                thongTinNguonGocs.Add(thongTinNguonGoc);
            }
            return thongTinNguonGocs;
        }

        public async Task<List<ThongTinPhapLy>> MapListThongTinPhapLyForSanPham(ICollection<SP_ThongTinPhapLyRequest> sP_ThongTinPhapLyRequests, string maSanPham)
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
                       MaSanPham = maSanPham,
                       SttTheoTt3015 = thongTinPhapLyRequest.SttTheoTt3015,
                       SttTheoTt15 =  thongTinPhapLyRequest.SttTheoTt15,
                       NhomTheoTt3015 = thongTinPhapLyRequest.NhomTheoTt3015,
                       NhomTheoTt15 = thongTinPhapLyRequest.NhomTheoTt15
                    };
                    await _thongTinPhapLyServices.AddAsync(thongTinPhapLy);
                }
                else
                {
                    thongTinPhapLy = ThongTinPhapLyUtils.UpdateThongTinPhapLyRequest(thongTinPhapLy, thongTinPhapLyRequest);
                }
                thongTinPhapLies.Add(thongTinPhapLy);
            }
            return thongTinPhapLies;
        }

        public async Task<List<ThongTinNoiBo>> MapListThongTinNoiBoForSanPham(ICollection<SP_ThongTinNoiBoRequest> sP_ThongTinNoiBoRequests, string maSanPham)
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
                        MaSanPham = maSanPham,
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
                else
                {
                    thongTinNoiBo = ThongTinNoiBoUtils.UpdateThongTinNoiBoRequest(thongTinNoiBo, thongTinNoiBoRequest);
                }
                thongTinNoiBos.Add(thongTinNoiBo);
            }
            return thongTinNoiBos;
        }
    }
}