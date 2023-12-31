﻿using trackingPlatform.Models.Dtos;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/SanPhamKinhDoanhServices.cs
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.RestClients;
using trackingPlatform.Service.ExternalServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Utils;
========
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.RestClients;
using trackingPlatform.Services.ExternalServices.SanPhamExternalServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/SanPhamKinhDoanhServices.cs
using WooCommerceNET.Base;
using WooCommerceNET.WooCommerce.v3;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class SanPhamKinhDoanhServices
    {

        private readonly SanPhamKinhDoanhRepositoryServices _sanPhamKinhDoanhRepositoryService;
        private readonly ManualMapper _manualMapper;
        private readonly WooCommerceService _wooCommerceService;
        private const int BatchRange = 100;

        public SanPhamKinhDoanhServices(SanPhamKinhDoanhRepositoryServices sanPhamKinhDoanhRepositoryServices, ManualMapper manualMapper, WooCommerceService wooCommerceService)
        {
            _sanPhamKinhDoanhRepositoryService = sanPhamKinhDoanhRepositoryServices;
            _manualMapper = manualMapper;
            _wooCommerceService = wooCommerceService;
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

                // Workaround
                sanPhamRequest.AmThanh = null;
                sanPhamRequest.GiongNoi = null;
                sanPhamRequest.PhienAm = null;
                sanPhamRequest.QrCode = null;
                sanPhamRequest.MaLoaiSp = null;

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
                if (sanPhamRequest.LoaiSp != null)
                {
                    loaiSp = await _manualMapper.MapLoaiSanPhamForSanPham(sanPhamRequest.LoaiSp);
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

                sanPhamKinhDoanhs.Add(_manualMapper.MapSanPhamRequestForSanPham(sanPhamRequest, dangBaoChe, dinhHuongSanPham, dieuKienBaoQuan, donViTinh, sanPhamGop, loaiSp, loaiSpNoiBo, nhomKiemSoat, nhomKinhDoanh));
            }
            return await _sanPhamKinhDoanhRepositoryService.AddOrUpdateSanPhams(sanPhamKinhDoanhs);

            //PostDto ecDbResult = await SyncProductsToEc(sanPhamKinhDoanhs);

        }

        public async Task<PostDto> AddOrUpdateSanPhamsSyncEc(List<SanPhamRequest> sanPhamRequests)
        {
            List<SanPhamKinhDoanh> sanPhamKinhDoanhs = new List<SanPhamKinhDoanh>();
            foreach (SanPhamRequest sanPhamRequest in sanPhamRequests)
            {

                // Workaround
                sanPhamRequest.AmThanh = null;
                sanPhamRequest.GiongNoi = null;
                sanPhamRequest.PhienAm = null;
                sanPhamRequest.QrCode = null;
                sanPhamRequest.MaLoaiSp = null;


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
                    // DieuKienBaoQuan temp = new DieuKienBaoQuan { MaDkbq = "string12", DieuKienBaoQuan1 = "temp12", MoTa ="Mota12" };
                    dieuKienBaoQuan = await _manualMapper.MapDieuKienBaoQuanForSanPham(sanPhamRequest.DieuKienBaoQuan);
                }
                DonViTinh donViTinh = null;
                if (sanPhamRequest.DonViTinh != null)
                {
                    donViTinh = await _manualMapper.MapDonViTinhForSanPham(sanPhamRequest.DonViTinh);
                }
                LoaiSp loaiSp = null;
                if (sanPhamRequest.LoaiSp != null)
                {
                    loaiSp = await _manualMapper.MapLoaiSanPhamForSanPham(sanPhamRequest.LoaiSp);
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

                sanPhamKinhDoanhs.Add(_manualMapper.MapSanPhamRequestForSanPham(sanPhamRequest, dangBaoChe, dinhHuongSanPham, dieuKienBaoQuan, donViTinh, sanPhamGop, loaiSp, loaiSpNoiBo, nhomKiemSoat, nhomKinhDoanh));
            }
            return await SyncProductsToEc(sanPhamKinhDoanhs);
        }

        public async Task<PostDto> SyncProductsToEc(List<SanPhamKinhDoanh> sanPhams)
        {
            PostDto result = new PostDto();
            List<BatchObject<Product>> productBatches = new List<BatchObject<Product>>();
            for (int start = 0; start < sanPhams.Count(); start += BatchRange)
            {
                int end = start + BatchRange > sanPhams.Count() ? sanPhams.Count() : start + BatchRange;
                productBatches.Add(await _manualMapper.MapListSanPhamToProductBatch(sanPhams.GetRange(start, end)));
            }
            foreach (BatchObject<Product> productBatch in await _wooCommerceService.BatchUpdateProducts(productBatches))
            {
                result.NumberOfCreate += productBatch.create?.Count ?? 0;
                result.NumberOfUpdate += productBatch.update?.Count ?? 0;
            }
            return result;
        }
    }
}
