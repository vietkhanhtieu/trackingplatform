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
        private readonly IMapper _mapper;

        public ManualMapper(DangBaoCheService dangBaoCheService, DinhHuongSanPhamServices dinhHuongSanPhamServices, NhomKinhDoanhServices nhomKinhDoanhServices, NhomKiemSoatServices nhomKiemSoatServices, DieuKienBaoQuanServices dieuKienBaoQuanServices, DonViTinhService donViTinhService, LoaiSpNoiBoServices loaiSpNoiBoService, SanPhamGopServices sanPhamGop, DanhMucLoaiSpServices danhMucLoaiSpServices, LoaiSpServices loaiSpServices, CanhGiacDuocServices canhGiacDuocServices, IMapper mapper)
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
            _mapper = mapper;
        }

        

        public SanPhamKinhDoanh MapSanPhamKinhDoanhRequestForSanPham(SanPhamRequest sanPhamRequest, DangBaoChe dang, DinhHuongSanPham dinhHuongSanPham, DieuKienBaoQuan dieuKienBaoQuan, DonViTinh donViTinh, SanPhamGop sanPhamGop, LoaiSp loaiSp, LoaiSpNoiBo loaiSpNoiBo, NhomKiemSoat nhomKiemSoat, NhomKinhDoanh nhomKinhDoanh, ICollection<CanhGiacDuoc> canhGiacDuocs)
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

                List<CanhGiacDuoc> canhGiacDuocs = await MapListCanhGiacDuocForSanPham(sanPhamRequest.CanhGiacDuocs);
                sanPhamKinhDoanhs.Add(MapSanPhamKinhDoanhRequestForSanPham(sanPhamRequest, dangBaoChe!, dinhHuongSanPham!, dieuKienBaoQuan!, donViTinh!, sanPhamGop!, loaiSp!, loaiSpNoiBo!, nhomKiemSoat!, nhomKinhDoanh!, canhGiacDuocs));
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
                    MaDanhMucLsp = ""
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

        public async Task<List<CanhGiacDuoc>> MapListCanhGiacDuocForSanPham(ICollection<SP_CanhGiacDuocRequest> canhGiacDuocRequests)
        {
            List<CanhGiacDuoc> canhGiacDuocs = new List<CanhGiacDuoc>();
            foreach(SP_CanhGiacDuocRequest canhGiacDuocRequest in canhGiacDuocRequests)
            {
                CanhGiacDuoc canhGiacDuoc = await _canhGiacDuocServices.FindByNameAsync(canhGiacDuocRequest.CanhGiacDuoc1!);
                if(canhGiacDuoc == null) {
                    canhGiacDuoc = new CanhGiacDuoc
                    {
                        MaCdg = "7777",
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
    }
}
