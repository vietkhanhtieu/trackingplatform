using trackingPlatform.Models;

namespace trackingPlatform.Utils
{
    public class DanhMucLoaiSpUtils
    {
        public static DanhMucLoaiSp UpdateDanhMucLoaiSp(DanhMucLoaiSp oldDanhMucLoaiSanPham, DanhMucLoaiSp newDanhMucLoaiSanPham)
        {
            oldDanhMucLoaiSanPham.TenDanhMucLsp = newDanhMucLoaiSanPham.TenDanhMucLsp;
            oldDanhMucLoaiSanPham.DinhNghia = newDanhMucLoaiSanPham.DinhNghia;
            return oldDanhMucLoaiSanPham;
        }
    }
}
