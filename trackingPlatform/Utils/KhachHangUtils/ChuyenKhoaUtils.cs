using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class ChuyenKhoaUtils
    {
        public static ChuyenKhoa UpdateChuyenKhoa(ChuyenKhoa oldChuyenKhoa, ChuyenKhoa newChuyenKhoa)
        {
            oldChuyenKhoa.TenChuyenKhoa = newChuyenKhoa.TenChuyenKhoa;
            oldChuyenKhoa.MoTa= newChuyenKhoa.MoTa;

            return oldChuyenKhoa;
        }
    }
}
