using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils
{
    public class DinhHuongSanPhamUtils
    {
        public static DinhHuongSanPham UpdateDinhHuongSanPham(DinhHuongSanPham oldDinhHuongSanPham, DinhHuongSanPham newDinhHuongSanPham)
        {
            oldDinhHuongSanPham.TenDinhHuong = newDinhHuongSanPham.TenDinhHuong;
            oldDinhHuongSanPham.MoTa = newDinhHuongSanPham.MoTa;
            return oldDinhHuongSanPham;
        }
    }
}
