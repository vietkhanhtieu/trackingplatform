using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdateSanPham;

namespace trackingPlatform.Utils
{
    public class ThongTinNoiBoUtils
    {
        public static ThongTinNoiBo UpdateThongTinNoiBo(ThongTinNoiBo oldThongTinNoiBo, ThongTinNoiBo newThongTinNoiBo)
        {
            oldThongTinNoiBo.NgayTao = newThongTinNoiBo.NgayTao;
            oldThongTinNoiBo.UserTao = newThongTinNoiBo.UserTao;
            oldThongTinNoiBo.NgayNgungSanPham = newThongTinNoiBo.NgayNgungSanPham;
            oldThongTinNoiBo.NgaySinhNhatSp = newThongTinNoiBo.NgaySinhNhatSp;
            oldThongTinNoiBo.TheoDoiSanPham = newThongTinNoiBo.TheoDoiSanPham;
            oldThongTinNoiBo.QuanLySanPham = newThongTinNoiBo.QuanLySanPham;
            oldThongTinNoiBo.TrangThaiHoSo = newThongTinNoiBo.TrangThaiHoSo;
            oldThongTinNoiBo.LamToRoiHayKhong = newThongTinNoiBo.LamToRoiHayKhong;
            oldThongTinNoiBo.DaDuocCapPhepTtThuocQc = newThongTinNoiBo.DaDuocCapPhepTtThuocQc;
            oldThongTinNoiBo.XinCapPhepQc = newThongTinNoiBo.XinCapPhepQc;
            oldThongTinNoiBo.TinhTrangToRoiNcc = newThongTinNoiBo.TinhTrangToRoiNcc;
            return oldThongTinNoiBo;
        }
        public static ThongTinNoiBo UpdateThongTinNoiBoRequest(ThongTinNoiBo oldThongTinNoiBo, SP_ThongTinNoiBoRequest newThongTinNoiBo)
        {
            oldThongTinNoiBo.NgayTao = newThongTinNoiBo.NgayTao;
            oldThongTinNoiBo.UserTao = newThongTinNoiBo.UserTao;
            oldThongTinNoiBo.NgayNgungSanPham = newThongTinNoiBo.NgayNgungSanPham;
            oldThongTinNoiBo.NgaySinhNhatSp = newThongTinNoiBo.NgaySinhNhatSp;
            oldThongTinNoiBo.TheoDoiSanPham = newThongTinNoiBo.TheoDoiSanPham;
            oldThongTinNoiBo.QuanLySanPham = newThongTinNoiBo.QuanLySanPham;
            oldThongTinNoiBo.TrangThaiHoSo = newThongTinNoiBo.TrangThaiHoSo;
            oldThongTinNoiBo.LamToRoiHayKhong = newThongTinNoiBo.LamToRoiHayKhong;
            oldThongTinNoiBo.DaDuocCapPhepTtThuocQc = newThongTinNoiBo.DaDuocCapPhepTtThuocQc;
            oldThongTinNoiBo.XinCapPhepQc = newThongTinNoiBo.XinCapPhepQc;
            oldThongTinNoiBo.TinhTrangToRoiNcc = newThongTinNoiBo.TinhTrangToRoiNcc;
            return oldThongTinNoiBo;
        }
    }
}
