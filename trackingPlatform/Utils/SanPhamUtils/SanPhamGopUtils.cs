<<<<<<< HEAD
﻿using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.SanPhamModels;
=======
﻿using trackingPlatform.Models.SanPhamModels;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Utils.SanPhamUtils
{
    public class SanPhamGopUtils
    {
        public static SanPhamGop UpdateSanPhamGop(SanPhamGop oldsanPhamGop, SanPhamGop newsanPhamGop)
        {

            oldsanPhamGop.GhiChu = newsanPhamGop.GhiChu;

            return oldsanPhamGop;
        }
    }
}
