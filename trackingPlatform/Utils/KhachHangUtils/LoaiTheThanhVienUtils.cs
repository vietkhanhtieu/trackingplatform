using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class LoaiTheThanhVienUtils
    {
        public static LoaiTheThanhVien UpdateLoaiTheThanhVien(LoaiTheThanhVien oldLoaiTheThanhVien, LoaiTheThanhVien newLoaiTheThanhVien)
        {
            oldLoaiTheThanhVien.TenLoaiThe = newLoaiTheThanhVien.TenLoaiThe;
            oldLoaiTheThanhVien.KyHieuVietTat = newLoaiTheThanhVien.KyHieuVietTat;
            return oldLoaiTheThanhVien;
        }
    }
}
