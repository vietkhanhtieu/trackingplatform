using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Models.SanPhamModels;

namespace trackingPlatform.Utils.SanPhamUtils
{
    public class ThongTinPhapLyUtils
    {
        public static ThongTinPhapLy UpdateThongTinPhapLy(ThongTinPhapLy oldThongTinPhapLy, ThongTinPhapLy newThongTinPhapLy)
        {
            oldThongTinPhapLy.SttTheoTt3015 = newThongTinPhapLy.SttTheoTt3015;
            oldThongTinPhapLy.SttTheoTt15 = newThongTinPhapLy.SttTheoTt15;
            oldThongTinPhapLy.NhomTheoTt3015 = newThongTinPhapLy.NhomTheoTt3015;
            oldThongTinPhapLy.NhomTheoTt15 = newThongTinPhapLy.NhomTheoTt15;
            return oldThongTinPhapLy;
        }
        public static ThongTinPhapLy UpdateThongTinPhapLyRequest(ThongTinPhapLy oldThongTinPhapLy, SP_ThongTinPhapLyRequest newThongTinPhapLy)
        {
            oldThongTinPhapLy.SttTheoTt3015 = newThongTinPhapLy.SttTheoTt3015;
            oldThongTinPhapLy.SttTheoTt15 = newThongTinPhapLy.SttTheoTt15;
            oldThongTinPhapLy.NhomTheoTt3015 = newThongTinPhapLy.NhomTheoTt3015;
            oldThongTinPhapLy.NhomTheoTt15 = newThongTinPhapLy.NhomTheoTt15;
            return oldThongTinPhapLy;
        }
    }
}
