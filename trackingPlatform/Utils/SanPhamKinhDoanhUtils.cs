using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class SanPhamKinhDoanhUtils
    {
        public static SanPhamKinhDoanh UpdateSanPhamKinhDoanh(SanPhamKinhDoanh oldSpkd, SanPhamKinhDoanh newSpkd)
        {
            oldSpkd.TenSanPham = newSpkd.TenSanPham;
            oldSpkd.MaSanPhamGonsa = newSpkd.MaSanPhamGonsa;
            oldSpkd.MaTichHop = newSpkd.MaTichHop;
            oldSpkd.MaRfid = newSpkd.MaRfid;
            oldSpkd.MaChuSoHuu = newSpkd.MaChuSoHuu;
            oldSpkd.MaSpNcc = newSpkd.MaSpNcc;
            oldSpkd.TenThuongMai = newSpkd.TenThuongMai;
            oldSpkd.QuyCachDongGoi = newSpkd.QuyCachDongGoi;
            oldSpkd.ThueVat = newSpkd.ThueVat;
            oldSpkd.GiaKeKhai = newSpkd.GiaKeKhai;
            oldSpkd.HanCheBanLe = newSpkd.HanCheBanLe;
            oldSpkd.GiaCoVat = newSpkd.GiaCoVat;
            oldSpkd.Active = newSpkd.Active;
            oldSpkd.DonviHop = newSpkd.DonviHop;
            oldSpkd.AmThanh = newSpkd.AmThanh;
            oldSpkd.GiongNoi = newSpkd.GiongNoi;
            oldSpkd.PhienAm = newSpkd.PhienAm;
            oldSpkd.QrCode = newSpkd.QrCode;
            oldSpkd.HinhAnh = newSpkd.HinhAnh;
            oldSpkd.TrangThai = newSpkd.TrangThai;
            oldSpkd.MaDangBaoCheNavigation = newSpkd.MaDangBaoCheNavigation;
            oldSpkd.MaDinhHuongNavigation = newSpkd.MaDinhHuongNavigation;
            oldSpkd.MaDkbqNavigation = newSpkd.MaDkbqNavigation;
            oldSpkd.MaDvtNavigation = newSpkd.MaDvtNavigation;
            oldSpkd.MaGopNavigation = newSpkd.MaGopNavigation;
            oldSpkd.MaLoaiSpNavigation = newSpkd.MaLoaiSpNavigation;
            oldSpkd.MaLoaiSpNoiBoNavigation = newSpkd.MaLoaiSpNoiBoNavigation;
            oldSpkd.MaNhomKiemSoatNavigation = newSpkd.MaNhomKiemSoatNavigation;
            oldSpkd.MaNhomKinhDoanhNavigation = newSpkd.MaNhomKinhDoanhNavigation;
            return oldSpkd;
        }
    }
}
