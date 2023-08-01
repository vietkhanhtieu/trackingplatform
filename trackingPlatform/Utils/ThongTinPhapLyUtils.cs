using trackingPlatform.Models;

namespace trackingPlatform.Utils
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
    }
}
