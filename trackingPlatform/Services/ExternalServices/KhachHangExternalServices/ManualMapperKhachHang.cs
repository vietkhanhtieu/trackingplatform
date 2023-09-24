using AutoMapper;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;
using trackingPlatform.Services.BussinessServices.KhachHangServices;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.ExternalServices.KhachHangExternalServices
{
    public class ManualMapperKhachHang
    {
        private readonly PhuongThucLienLacServices _phuongThucLienLacServices;
        private readonly KhachHangB2CServices _khachHangB2CServices;
        private readonly LoaiTheThanhVienServices _loaiTheThanhVienServices;
        private readonly NhomKiemSoatDacBietServices _nhomKiemSoatDacBietServices;
        private readonly PhanHangServices _phanHangServices;
        private readonly PhanNganhServices _phanNganhServices;
        private readonly NhomKhachHangB2BServices _nhomKhachHangB2BServices;
        private readonly NguoiDaiDienPhapLyServices _nguoiDaiDienPhapLyServices;
        private readonly LoaiHinhDichVuServices _loaiHinhDichVuServices;
        private readonly NgayCotMocServices _ngayCotMocServices;
        private readonly ChuyenKhoaServices _chuyenKhoaServices;
        private readonly NguoiNhanTtHdonServices _nguoiNhanTtHdonServices;
        private readonly ThongTinKhachGdpServices _thongTinKhachGdpServices;
        private readonly ThongTinGppServices _thongTinGppServices;
        private readonly ThongTinThueServices _thongTinThueServices;
        private readonly CbnvKhachHangServices _cbnvKhachHangServices;
        private readonly ChiNhanhServices _chiNhanhServices;
        private readonly CongNoServices _congNoServices;
        private readonly ThongTinXuatHoaDonServices _thongTinXuatHoaDonServices;


        private readonly IMapper _mapper;

        public ManualMapperKhachHang(PhuongThucLienLacServices phuongThucLienLacServices, KhachHangB2CServices khachHangB2CServices, LoaiTheThanhVienServices loaiTheThanhVienServices, NhomKiemSoatDacBietServices nhomKiemSoatDacBietServices, PhanHangServices phanHangServices, PhanNganhServices phanNganhServices, NhomKhachHangB2BServices nhomKhachHangB2B, NguoiDaiDienPhapLyServices nguoiDaiDienPhapLyServices, LoaiHinhDichVuServices loaiHinhDichVuServices, NgayCotMocServices ngayCotMocServices, ChuyenKhoaServices chuyenKhoaServices, NguoiNhanTtHdonServices nguoiNhanTtHdonServices, ThongTinKhachGdpServices thongTinKhachGdpServices, ThongTinGppServices thongTinGppServices, ThongTinThueServices thongTinThueServices, CbnvKhachHangServices cbnvKhachHangServices, ChiNhanhServices chiNhanhServices, CongNoServices congNoServices, ThongTinXuatHoaDonServices thongTinXuatHoaDonServices, IMapper mapper)
        {
            _phuongThucLienLacServices = phuongThucLienLacServices;
            _khachHangB2CServices = khachHangB2CServices;
            _loaiTheThanhVienServices = loaiTheThanhVienServices;
            _nhomKiemSoatDacBietServices = nhomKiemSoatDacBietServices;
            _phanHangServices = phanHangServices;
            _phanNganhServices = phanNganhServices;
            _nhomKhachHangB2BServices = nhomKhachHangB2B;
            _nguoiDaiDienPhapLyServices = nguoiDaiDienPhapLyServices;
            _loaiHinhDichVuServices = loaiHinhDichVuServices;
            _ngayCotMocServices = ngayCotMocServices;
            _chuyenKhoaServices = chuyenKhoaServices;
            _nguoiNhanTtHdonServices = nguoiNhanTtHdonServices;
            _thongTinKhachGdpServices = thongTinKhachGdpServices;
            _thongTinGppServices = thongTinGppServices;
            _thongTinThueServices = thongTinThueServices;
            _cbnvKhachHangServices = cbnvKhachHangServices;
            _chiNhanhServices = chiNhanhServices;
            _congNoServices = congNoServices;
            _thongTinXuatHoaDonServices = thongTinXuatHoaDonServices;
            _mapper = mapper;
        }
        public KhachHang MapKhachHangRequestForKhachHang(KhachHangRequest khachHangRequest, KhachHangB2b khachHangB2B, KhachHangB2c khachHangB2C, LoaiTheThanhVien loaiTheThanhVien, PhuongThucLienLac phuongThucLienLac, ThongTinXuatHoaDon thongTinXuatHoaDon)
        {
            KhachHang khachHang = _mapper.Map<KhachHang>(khachHangRequest);
            khachHang.MaKhachHangB2bNavigation = khachHangB2B;
            khachHang.MaKhachHangB2cNavigation = khachHangB2C;
            khachHang.MaLoaiTheNavigation = loaiTheThanhVien;
            khachHang.MaPhuongThucNavigation = phuongThucLienLac;
            khachHang.MaTtXuatHdNavigation = thongTinXuatHoaDon;
            return khachHang;
        }
        public KhachHangB2b MapKhachHangB2BRequestForKhachHangB2B(KhachHangB2bRequest khachHangB2BRequest, PhanHang phanHang, PhanNganh phanNganh, NhomKhachHangB2b nhomKhachHangB2B, NguoiDaiDienPhapLy nguoiDaiDienPhapLy)
        {
            KhachHangB2b khachHangB2B = _mapper.Map<KhachHangB2b>(khachHangB2BRequest);
            khachHangB2B.MaNguoiDaiDienNavigation = nguoiDaiDienPhapLy;
            khachHangB2B.MaNhomNavigation = nhomKhachHangB2B;
            khachHangB2B.MaPhanHangNavigation = phanHang;
            khachHangB2B.MaPhanNganhNavigation = phanNganh;
            return khachHangB2B;

        }
        public async Task<PhuongThucLienLac> MapPhuongThucLienLacForKhachHang(PhuongThucLienLac phuongThuc)
        {
            PhuongThucLienLac phuongThucLienLac = await _phuongThucLienLacServices.GetPhuongThucLienLac(phuongThuc.MaPhuongThuc);
            if (phuongThucLienLac == null)
            {
                phuongThucLienLac = new PhuongThucLienLac
                {
                    MaPhuongThuc = phuongThuc.MaPhuongThuc,
                    PhuongThuc = phuongThuc.PhuongThuc,
                    MoTa = phuongThuc.MoTa,
                };
                await _phuongThucLienLacServices.AddAsync(phuongThucLienLac);
            }
            return phuongThucLienLac;
        }
        public async Task<KhachHangB2c> MapKhachHangB2CForKhachHang(KhachHangB2c khB2c)
        {
            KhachHangB2c khachHangB2C = await _khachHangB2CServices.GetKhachHangB2c(khB2c.MaKhachHangB2c);
            if (khachHangB2C == null)
            {
                khachHangB2C = new KhachHangB2c
                {
                    MaKhachHangB2c = khB2c.MaKhachHangB2c,
                    MoTa = khB2c.MoTa,
                };
                await _khachHangB2CServices.AddAsync(khachHangB2C);
            }
            return khachHangB2C;
        }
        public async Task<LoaiTheThanhVien> MapLoaiTheThanhVienForKhachHang(LoaiTheThanhVien loaiThanhVien)
        {
            LoaiTheThanhVien loaiTheThanhVien = await _loaiTheThanhVienServices.GetLoaiTheThanhVien(loaiThanhVien.MaLoaiThe);
            if (loaiTheThanhVien == null)
            {
                loaiTheThanhVien = new LoaiTheThanhVien
                {
                    MaLoaiThe = loaiThanhVien.MaLoaiThe,
                    TenLoaiThe = loaiThanhVien.TenLoaiThe,
                    KyHieuVietTat = loaiThanhVien.KyHieuVietTat,

                };
                await _loaiTheThanhVienServices.AddAsync(loaiTheThanhVien);
            }
            return loaiTheThanhVien;
        }
        public async Task<ThongTinXuatHoaDon> MapThongTinXuatHoaDonForKhachHang(ThongTinXuatHoaDon thongTinXuat)
        {
            ThongTinXuatHoaDon thongTinXuatHoaDon = await _thongTinXuatHoaDonServices.GetThongTinXuatHoaDon(thongTinXuat.MaTtXuatHd);
            if (thongTinXuatHoaDon == null)
            {
                thongTinXuatHoaDon = new ThongTinXuatHoaDon
                {
                    MaTtXuatHd = thongTinXuat.MaTtXuatHd,
                    TenNguoiMuaHang = thongTinXuat.TenNguoiMuaHang,
                    TenDonVi = thongTinXuat.TenDonVi,
                    TenKhachHangXuatHoaDon = thongTinXuat.TenKhachHangXuatHoaDon,
                    Email = thongTinXuat.Email,
                    SoDt = thongTinXuat.SoDt,
                    LuuY = thongTinXuat.LuuY,
                    DiaChi = thongTinXuat.DiaChi,

                };
                await _thongTinXuatHoaDonServices.AddAsync(thongTinXuatHoaDon);
            }
            return thongTinXuatHoaDon;
        }



        public async Task<List<NhomKiemSoatDacBiet>> MapNhomKiemSoatForKhachHangB2B(ICollection<KHB2B_NhomKiemSoatDacBietRequest> kH_NhomKiemSoatDacBietRequests, string maKhachHang)
        {
            List<NhomKiemSoatDacBiet> nhomKiemSoatDacBiets = new List<NhomKiemSoatDacBiet>();
            foreach (KHB2B_NhomKiemSoatDacBietRequest nhomKiemSoatDatBietRequest in kH_NhomKiemSoatDacBietRequests)
            {
                NhomKiemSoatDacBiet nhomKiemSoatDacBiet = await _nhomKiemSoatDacBietServices.GetNhomKiemSoat(nhomKiemSoatDatBietRequest.MaNksdb);
                if (nhomKiemSoatDacBiet == null)
                {
                    nhomKiemSoatDacBiet = new NhomKiemSoatDacBiet
                    {
                        MaNksdb = nhomKiemSoatDatBietRequest.MaNksdb,
                        MaKhachHangB2b = maKhachHang,
                        ThuocHanCheBanLe = nhomKiemSoatDatBietRequest.ThuocHanCheBanLe,
                        ThuocTienChat = nhomKiemSoatDatBietRequest.DangPhChuaTienChat,
                        NguyenLieuLaDcGayNghienHuongThanPxaTchat = nhomKiemSoatDatBietRequest.NguyenLieuLaDcGayNghienHuongThanPxaTchat,
                        ThuocPhongXa = nhomKiemSoatDatBietRequest.ThuocPhongXa,
                        ThuocDocNlieuDocLamThuoc = nhomKiemSoatDatBietRequest.ThuocDocNlieuDocLamThuoc,
                        CamTrongMotSoLinhVuc = nhomKiemSoatDatBietRequest.CamTrongMotSoLinhVuc,
                        DangPhChuaDchatHuongThan = nhomKiemSoatDatBietRequest.DangPhChuaTienChat,
                        ThuocHuongThan = nhomKiemSoatDatBietRequest.ThuocHuongThan,
                        ThuocGayNghien = nhomKiemSoatDatBietRequest.ThuocGayNghien,
                        DangPhChuaDcGayNghien = nhomKiemSoatDatBietRequest.DangPhChuaDcGayNghien,
                        DangPhChuaTienChat = nhomKiemSoatDatBietRequest.DangPhChuaTienChat,
                    };
                    await _nhomKiemSoatDacBietServices.AddAsync(nhomKiemSoatDacBiet);
                }
                else
                {
                    nhomKiemSoatDacBiet = NhomKiemSoatDacBietUtils.UpdateNhomKiemSoatDacBietRequest(nhomKiemSoatDacBiet, nhomKiemSoatDatBietRequest);
                }
                nhomKiemSoatDacBiets.Add(nhomKiemSoatDacBiet);
            }

            return nhomKiemSoatDacBiets;
        }
        public async Task<List<NguoiNhanTtHdon>> MapNguoiNhanTtHdonForKhachHangB2B(ICollection<KHB2B_NguoiNhanTtHdonRequest> kHB2B_NguoiNhanTtHdonRequests, string maKhachHang)
        {
            List<NguoiNhanTtHdon> nguoiNhanTtHdons = new List<NguoiNhanTtHdon>();
            foreach (KHB2B_NguoiNhanTtHdonRequest nguoiNhanTtHdonRequest in kHB2B_NguoiNhanTtHdonRequests)
            {
                NguoiNhanTtHdon nguoiNhanTtHdon = await _nguoiNhanTtHdonServices.GetNguoiNhanTtHdon(nguoiNhanTtHdonRequest.MaNguoiNhan);
                if (nguoiNhanTtHdon == null)
                {
                    nguoiNhanTtHdon = new NguoiNhanTtHdon
                    {
                        MaNguoiNhan = nguoiNhanTtHdonRequest.MaNguoiNhan,
                        MaKhachHangB2b = maKhachHang,
                        TenNguoiNhan = nguoiNhanTtHdonRequest.TenNguoiNhan,
                        Email = nguoiNhanTtHdonRequest.Email,
                        SoDt = nguoiNhanTtHdonRequest.SoDt

                    };
                    await _nguoiNhanTtHdonServices.AddAsync(nguoiNhanTtHdon);
                }
                else
                {
                    nguoiNhanTtHdon = NguoiNhanThongTinHoaDonUtils.UpdateNguoiNhanTtHdonRequest(nguoiNhanTtHdon, nguoiNhanTtHdonRequest);
                }
                nguoiNhanTtHdons.Add(nguoiNhanTtHdon);
            }

            return nguoiNhanTtHdons;
        }
        public async Task<List<ThongTinGdp>> MapThongTinGdpForKhachHangB2B(ICollection<KHB2B_ThongTinGdpRequest> kHB2B_ThongTinGdps, string maKhachHang)
        {
            List<ThongTinGdp> thongTinGdps = new List<ThongTinGdp>();
            foreach (KHB2B_ThongTinGdpRequest thongTinGdpRequest in kHB2B_ThongTinGdps)
            {
                ThongTinGdp thongTinGdp = await _thongTinKhachGdpServices.GetThongTinGdp(thongTinGdpRequest.MaTtGdp);
                if (thongTinGdp == null)
                {
                    thongTinGdp = new ThongTinGdp
                    {
                        MaTtGdp = thongTinGdpRequest.MaTtGdp,
                        MaKhachHangB2b = maKhachHang,
                        SoChungNhanGdp = thongTinGdpRequest.SoChungNhanGdp,
                        NgayCap = thongTinGdpRequest.NgayCap,
                        NgayHetHan = thongTinGdpRequest.NgayHetHan,
                        HoatDong = thongTinGdpRequest.HoatDong,
                        HinhAnh = thongTinGdpRequest.HinhAnh,
                        FilePdf = thongTinGdpRequest.FilePdf

                    };
                    await _thongTinKhachGdpServices.AddAsync(thongTinGdp);
                }
                else
                {
                    thongTinGdp = ThongTinGdpUtils.UpdateThongTinGdpRequest(thongTinGdp, thongTinGdpRequest);
                }
                thongTinGdps.Add(thongTinGdp);
            }

            return thongTinGdps;
        }
        public async Task<List<ThongTinGpp>> MapThongTinGppForKhachHangB2B(ICollection<KHB2B_ThongTinGppRequest> kHB2B_ThongTinGpps, string maKhachHang)
        {
            List<ThongTinGpp> thongTinGpps = new List<ThongTinGpp>();
            foreach (KHB2B_ThongTinGppRequest thongTinGdpRequest in kHB2B_ThongTinGpps)
            {
                ThongTinGpp thongTinGpp = await _thongTinGppServices.GetThongTinGpp(thongTinGdpRequest.MaTtGpp);
                if (thongTinGpp == null)
                {
                    thongTinGpp = new ThongTinGpp
                    {
                        MaTtGpp = thongTinGdpRequest.MaTtGpp,
                        MaKhachHangB2b = maKhachHang,
                        SoChungNhanGpp = thongTinGdpRequest.SoChungNhanGpp,
                        NgayCap = thongTinGdpRequest.NgayCap,
                        NgayHetHan = thongTinGdpRequest.NgayHetHan,
                        HoatDong = thongTinGdpRequest.HoatDong,
                        HinhAnh = thongTinGdpRequest.HinhAnh,
                        FilePdf = thongTinGdpRequest.FilePdf

                    };
                    await _thongTinGppServices.AddAsync(thongTinGpp);
                }
                else
                {
                    thongTinGpp = ThongTinGppUtils.UpdateThongTinGppRequest(thongTinGpp, thongTinGdpRequest);
                }
                thongTinGpps.Add(thongTinGpp);
            }

            return thongTinGpps;
        }
        public async Task<List<ThongTinThue>> MapThongTinThueForKhachHangB2B(ICollection<KHB2B_ThongTinThueRequest> kHB2B_ThongTinThueRequests, string maKhachHang)
        {
            List<ThongTinThue> thongTinThues = new List<ThongTinThue>();
            foreach (KHB2B_ThongTinThueRequest thongTinThueRequest in kHB2B_ThongTinThueRequests)
            {
                ThongTinThue thongTinThue = await _thongTinThueServices.GetThongTinThue(thongTinThueRequest.MaTtThue);
                if (thongTinThue == null)
                {
                    thongTinThue = new ThongTinThue
                    {
                        MaTtThue = thongTinThueRequest.MaTtThue,
                        MaKhachHangB2b = maKhachHang,
                        MaSoThue = thongTinThueRequest.MaSoThue,
                        HoatDong = thongTinThueRequest.HoatDong,
                        XacNhanThue = thongTinThueRequest.XacNhanThue

                    };
                    await _thongTinThueServices.AddAsync(thongTinThue);
                }
                else
                {
                    thongTinThue = ThongTinThueUtils.UpdateThongTinThueRequest(thongTinThue, thongTinThueRequest);
                }
                thongTinThues.Add(thongTinThue);
            }

            return thongTinThues;
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
        public async Task<List<ChiNhanh>> MapChiNhanhForKhachHangB2B(ICollection<KHB2B_ChiNhanhRequest> kHB2B_ChiNhanhRequests, string maKhachHang)
        {
            List<ChiNhanh> chiNhanhs = new List<ChiNhanh>();
            foreach (KHB2B_ChiNhanhRequest chiNhanhRequest in kHB2B_ChiNhanhRequests)
            {
                ChiNhanh chiNhanh = await _chiNhanhServices.GetChiNhanh(chiNhanhRequest.MaChiNhanh);
                if (chiNhanh == null)
                {
                    chiNhanh = new ChiNhanh
                    {
                        MaChiNhanh = chiNhanhRequest.MaChiNhanh,
                        MaKhachHangB2b = maKhachHang,
                        TenChiNhanh = chiNhanhRequest.TenChiNhanh,
                        ChiNhanhMe = chiNhanhRequest.ChiNhanhMe,
                        Email = chiNhanhRequest.Email,
                        SoDt = chiNhanhRequest.SoDt,
                        MoiQuanHe = chiNhanhRequest.MoiQuanHe,
                        DiaChi = chiNhanhRequest.DiaChi,
                    };
                    await _chiNhanhServices.AddAsync(chiNhanh);
                }
                else
                {
                    chiNhanh = ChiNhanhUtils.UpdateChiNhanhRequest(chiNhanh, chiNhanhRequest);
                }
                chiNhanhs.Add(chiNhanh);
            }

            return chiNhanhs;
        }
        public async Task<List<CongNo>> MapCongNoForKhachHangB2B(ICollection<KHB2B_CongNoRequest> kHB2B_CongNoRequests, string maKhachHang)
        {
            List<CongNo> congNos = new List<CongNo>();
            foreach (KHB2B_CongNoRequest congNoRequest in kHB2B_CongNoRequests)
            {
                CongNo congNo = await _congNoServices.GetCongNo(congNoRequest.MaCongNo);
                if (congNo == null)
                {
                    congNo = new CongNo
                    {
                        MaCongNo = congNoRequest.MaCongNo,
                        MaKhachHangB2b = maKhachHang,
                        ThoiHanCongNo = congNoRequest.ThoiHanCongNo,
                        HanMucCongNo = congNoRequest.HanMucCongNo,
                        DanhGia = congNoRequest.DanhGia,
                        GhiChu = congNoRequest.GhiChu,
                    };
                    await _congNoServices.AddAsync(congNo);
                }
                else
                {
                    congNo = CongNoUtils.UpdateCongNoRequest(congNo, congNoRequest);
                }
                congNos.Add(congNo);
            }
            return congNos;
        }
        public async Task<PhanHang> MapPhanHangForKhachHangB2B(PhanHang pHang)
        {
            PhanHang phanHang = await _phanHangServices.GetPhanHang(pHang.MaPhanHang);
            if (phanHang == null)
            {
                phanHang = new PhanHang
                {
                    MaPhanHang = pHang.MaPhanHang,
                    Hang = pHang.Hang,
                    MoTa = pHang.MoTa

                };
                await _phanHangServices.AddAsync(phanHang);
            }
            return phanHang;
        }
        public async Task<PhanNganh> MapPhanNganhForKhachHangB2B(PhanNganh pNganh)
        {
            PhanNganh phanNganh = await _phanNganhServices.GetPhanNganh(pNganh.MaPhanNganh);
            if (phanNganh == null)
            {
                phanNganh = new PhanNganh
                {
                    MaPhanNganh = pNganh.MaPhanNganh,
                    PhanNganh1 = pNganh.PhanNganh1,
                    MoTa = pNganh.MoTa

                };
                await _phanNganhServices.AddAsync(phanNganh);
            }
            return phanNganh;
        }

        public async Task<NhomKhachHangB2b> MapNhomKhachHangB2BForKhachHangB2B(NhomKhachHangB2b nhomKhachHang)
        {
            NhomKhachHangB2b nhomKhachHangB2B = await _nhomKhachHangB2BServices.GetNhomKhachHangB2B(nhomKhachHang.MaNhom);
            if (nhomKhachHangB2B == null)
            {
                nhomKhachHangB2B = new NhomKhachHangB2b
                {
                    MaNhom = nhomKhachHang.MaNhom,
                    TenNhom = nhomKhachHang.TenNhom,
                    KyHieuVietTat = nhomKhachHang.KyHieuVietTat,
                    MoTa = nhomKhachHang.MoTa

                };
                await _nhomKhachHangB2BServices.AddAsync(nhomKhachHangB2B);
            }
            return nhomKhachHangB2B;
        }

        public async Task<NguoiDaiDienPhapLy> MapNguoiDaiDienPhapLyForKhachHangB2B(NguoiDaiDienPhapLy nguoiDaiDien)
        {
            NguoiDaiDienPhapLy nguoiDaiDienPhapLy = await _nguoiDaiDienPhapLyServices.GetNguoiDaiDienPhapLy(nguoiDaiDien.MaNguoiDaiDien);
            if (nguoiDaiDienPhapLy == null)
            {
                nguoiDaiDienPhapLy = new NguoiDaiDienPhapLy
                {
                    MaNguoiDaiDien = nguoiDaiDien.MaNguoiDaiDien,
                    TenNguoiDaiDien = nguoiDaiDien.TenNguoiDaiDien,
                    Email = nguoiDaiDien.Email,
                    SoDt = nguoiDaiDien.SoDt
                };
                await _nguoiDaiDienPhapLyServices.AddAsync(nguoiDaiDienPhapLy);
            }
            return nguoiDaiDienPhapLy;
        }

        public async Task<LoaiHinhDichVu> MapLoaiHinhDichVuForKhachHangB2B(string maLoaiDichVu)
        {
            LoaiHinhDichVu loaiHinhDichVu = await _loaiHinhDichVuServices.GetLoaiHinhDichVu(maLoaiDichVu);
            if (loaiHinhDichVu == null)
            {
                loaiHinhDichVu = new LoaiHinhDichVu
                {
                    MaLoaiHinhDv = maLoaiDichVu,
                    LoaiHinhDv = "",
                    KyHieuVietTat = "",
                    PhiDichVu = "",
                    MoTa = ""
                };
                await _loaiHinhDichVuServices.AddAsync(loaiHinhDichVu);
            }
            return loaiHinhDichVu;
        }

        public async Task<NgayCotMoc> MapNgayCotMocForKhachHangB2B(string maCotMoc)
        {
            NgayCotMoc ngayCotMoc = await _ngayCotMocServices.GetMaCotMoc(maCotMoc);
            if (ngayCotMoc == null)
            {
                ngayCotMoc = new NgayCotMoc
                {
                    MaCotMoc = maCotMoc,
                    MoTa = ""
                };
                await _ngayCotMocServices.AddAsync(ngayCotMoc);
            }
            return ngayCotMoc;
        }

        public async Task<ChuyenKhoa> MapChuyenKhoaForKhachHangB2B(string maChuyenKhoa)
        {
            ChuyenKhoa chuyenKhoa = await _chuyenKhoaServices.GetChuyenKhoa(maChuyenKhoa);
            if (chuyenKhoa == null)
            {
                chuyenKhoa = new ChuyenKhoa
                {
                    MaChuyenKhoa = maChuyenKhoa,
                    TenChuyenKhoa = "",
                    MoTa = ""
                };
                await _chuyenKhoaServices.AddAsync(chuyenKhoa);
            }
            return chuyenKhoa;
        }

    }
}
