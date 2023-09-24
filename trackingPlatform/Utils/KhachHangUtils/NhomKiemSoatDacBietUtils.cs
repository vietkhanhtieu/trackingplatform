

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdateKhachHang;

namespace trackingPlatform.Utils.KhachHangUtils
{
    public class NhomKiemSoatDacBietUtils
    {
        public static NhomKiemSoatDacBiet UpdateNhomKiemSoatDacBiet(NhomKiemSoatDacBiet oldNhomKiemSoatDacBiet, NhomKiemSoatDacBiet newNhomKiemSoatDacBiet)
        {
            oldNhomKiemSoatDacBiet.ThuocHanCheBanLe = newNhomKiemSoatDacBiet.ThuocHanCheBanLe;
            oldNhomKiemSoatDacBiet.ThuocTienChat = newNhomKiemSoatDacBiet.ThuocTienChat;
            oldNhomKiemSoatDacBiet.NguyenLieuLaDcGayNghienHuongThanPxaTchat = newNhomKiemSoatDacBiet.NguyenLieuLaDcGayNghienHuongThanPxaTchat;
            oldNhomKiemSoatDacBiet.ThuocPhongXa = newNhomKiemSoatDacBiet.ThuocPhongXa;
            oldNhomKiemSoatDacBiet.ThuocDocNlieuDocLamThuoc = newNhomKiemSoatDacBiet.ThuocDocNlieuDocLamThuoc;
            oldNhomKiemSoatDacBiet.CamTrongMotSoLinhVuc = newNhomKiemSoatDacBiet.CamTrongMotSoLinhVuc;
            oldNhomKiemSoatDacBiet.DangPhChuaDchatHuongThan = newNhomKiemSoatDacBiet.DangPhChuaDchatHuongThan;
            oldNhomKiemSoatDacBiet.ThuocHuongThan = newNhomKiemSoatDacBiet.ThuocHuongThan;
            oldNhomKiemSoatDacBiet.ThuocGayNghien = newNhomKiemSoatDacBiet.ThuocGayNghien;
            oldNhomKiemSoatDacBiet.DangPhChuaDcGayNghien = newNhomKiemSoatDacBiet.DangPhChuaDcGayNghien;
            oldNhomKiemSoatDacBiet.DangPhChuaTienChat = newNhomKiemSoatDacBiet.DangPhChuaTienChat;
            return oldNhomKiemSoatDacBiet;
        }

        public static NhomKiemSoatDacBiet UpdateNhomKiemSoatDacBietRequest(NhomKiemSoatDacBiet oldNhomKiemSoatDacBiet, KHB2B_NhomKiemSoatDacBietRequest newNhomKiemSoatDacBiet)
        {
            oldNhomKiemSoatDacBiet.ThuocHanCheBanLe = newNhomKiemSoatDacBiet.ThuocHanCheBanLe;
            oldNhomKiemSoatDacBiet.ThuocTienChat = newNhomKiemSoatDacBiet.ThuocTienChat;
            oldNhomKiemSoatDacBiet.NguyenLieuLaDcGayNghienHuongThanPxaTchat = newNhomKiemSoatDacBiet.NguyenLieuLaDcGayNghienHuongThanPxaTchat;
            oldNhomKiemSoatDacBiet.ThuocPhongXa = newNhomKiemSoatDacBiet.ThuocPhongXa;
            oldNhomKiemSoatDacBiet.ThuocDocNlieuDocLamThuoc = newNhomKiemSoatDacBiet.ThuocDocNlieuDocLamThuoc;
            oldNhomKiemSoatDacBiet.CamTrongMotSoLinhVuc = newNhomKiemSoatDacBiet.CamTrongMotSoLinhVuc;
            oldNhomKiemSoatDacBiet.DangPhChuaDchatHuongThan = newNhomKiemSoatDacBiet.DangPhChuaDchatHuongThan;
            oldNhomKiemSoatDacBiet.ThuocHuongThan = newNhomKiemSoatDacBiet.ThuocHuongThan;
            oldNhomKiemSoatDacBiet.ThuocGayNghien = newNhomKiemSoatDacBiet.ThuocGayNghien;
            oldNhomKiemSoatDacBiet.DangPhChuaDcGayNghien = newNhomKiemSoatDacBiet.DangPhChuaDcGayNghien;
            oldNhomKiemSoatDacBiet.DangPhChuaTienChat = newNhomKiemSoatDacBiet.DangPhChuaTienChat;
            return oldNhomKiemSoatDacBiet;
        }
    }
}
