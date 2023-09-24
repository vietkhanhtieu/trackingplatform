using System.Net.NetworkInformation;
using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class NguoiDaiDienPhapLyUtils
    {
        public static NguoiDaiDienPhapLy UpdateNguoiDaiDienPhapLy(NguoiDaiDienPhapLy oldNguoiDaiDienPhapLy, NguoiDaiDienPhapLy newNguoiDaiDienPhapLy)
        {
            oldNguoiDaiDienPhapLy.Email = newNguoiDaiDienPhapLy.Email;
            oldNguoiDaiDienPhapLy.TenNguoiDaiDien = newNguoiDaiDienPhapLy.TenNguoiDaiDien;
            oldNguoiDaiDienPhapLy.SoDt = newNguoiDaiDienPhapLy.SoDt;
            return oldNguoiDaiDienPhapLy;
        }
    }
}
