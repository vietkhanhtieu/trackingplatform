﻿using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
{
    public class LoaiSpUtils
    {
        public static LoaiSp UpdateLoaiSp(LoaiSp oldLsp, LoaiSp newLsp)
        {
            oldLsp.TenLoaiSp = newLsp.TenLoaiSp;
            oldLsp.DinhNghia = newLsp.DinhNghia;
            oldLsp.MaDanhMucLsp = newLsp.MaDanhMucLsp;
            return oldLsp;
        }
    }
}
