﻿using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
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
