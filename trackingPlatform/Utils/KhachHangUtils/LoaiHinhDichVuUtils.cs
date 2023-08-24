using trackingPlatform.Models.KhachHangModels;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class LoaiHinhDichVuUtils
    {
        public static LoaiHinhDichVu UpdateLoaiHinhDichVu(LoaiHinhDichVu oldLoaiHinhDichVu, LoaiHinhDichVu newLoaiHinhDichVu)
        {
            oldLoaiHinhDichVu.LoaiHinhDv = newLoaiHinhDichVu.LoaiHinhDv;
            oldLoaiHinhDichVu.KyHieuVietTat= newLoaiHinhDichVu.KyHieuVietTat;
            oldLoaiHinhDichVu.PhiDichVu = newLoaiHinhDichVu.PhiDichVu;
            oldLoaiHinhDichVu.MoTa = newLoaiHinhDichVu.MoTa;
            return oldLoaiHinhDichVu;
        }
    }
}
