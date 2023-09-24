using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
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
