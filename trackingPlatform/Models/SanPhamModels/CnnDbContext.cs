using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models.GiaoDichModels;
using trackingPlatform.Models.KhachHangModel;

namespace trackingPlatform.Models.SanPhamModels;

public partial class CnnDbContext : DbContext
{
    public CnnDbContext()
    {
    }

    public CnnDbContext(DbContextOptions<CnnDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Api> Apis { get; set; }

    public virtual DbSet<AuditTable> AuditTables { get; set; }

    public virtual DbSet<CanhGiacDuoc> CanhGiacDuocs { get; set; }

    public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }

    public virtual DbSet<ChiPhiVanChuyen> ChiPhiVanChuyens { get; set; }

    public virtual DbSet<ChuyenKhoa> ChuyenKhoas { get; set; }

    public virtual DbSet<CongNo> CongNos { get; set; }

    public virtual DbSet<DangBaoChe> DangBaoChes { get; set; }

    public virtual DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }

    public virtual DbSet<DanhMucLoaiSp> DanhMucLoaiSps { get; set; }

    public virtual DbSet<DieuKienBaoQuan> DieuKienBaoQuans { get; set; }

    public virtual DbSet<DinhHuongSanPham> DinhHuongSanPhams { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<DonViTinh> DonViTinhs { get; set; }

    public virtual DbSet<GhiChuSp> GhiChuSps { get; set; }

    public virtual DbSet<GiaSanPham> GiaSanPhams { get; set; }

    public virtual DbSet<Hub> Hubs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Khb2bCkhoa> Khb2bCkhoas { get; set; }

    public virtual DbSet<LichSuDonHang> LichSuDonHangs { get; set; }

    public virtual DbSet<LoSanPham> LoSanPhams { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<LoaiSpNoiBo> LoaiSpNoiBos { get; set; }

    public virtual DbSet<LoaiTheThanhVien> LoaiTheThanhViens { get; set; }

    public virtual DbSet<MwForm> MwForms { get; set; }

    public virtual DbSet<NgayHetHanLoSanPham> NgayHetHanLoSanPhams { get; set; }

    public virtual DbSet<NguoiDaiDienPhapLy> NguoiDaiDienPhapLies { get; set; }

    public virtual DbSet<NhomApi> NhomApis { get; set; }

    public virtual DbSet<NhomKhachHang> NhomKhachHangs { get; set; }

    public virtual DbSet<NhomKiemSoat> NhomKiemSoats { get; set; }

    public virtual DbSet<NhomKiemSoatDacBiet> NhomKiemSoatDacBiets { get; set; }

    public virtual DbSet<NhomKinhDoanh> NhomKinhDoanhs { get; set; }

    public virtual DbSet<PhanHang> PhanHangs { get; set; }

    public virtual DbSet<PhanNganh> PhanNganhs { get; set; }

    public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }

    public virtual DbSet<RoleApiUser> RoleApiUsers { get; set; }

    public virtual DbSet<SanPhamDonHang> SanPhamDonHangs { get; set; }

    public virtual DbSet<SanPhamGop> SanPhamGops { get; set; }

    public virtual DbSet<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; set; }

    public virtual DbSet<ThongTinChinh> ThongTinChinhs { get; set; }

    public virtual DbSet<ThongTinGdp> ThongTinGdps { get; set; }

    public virtual DbSet<ThongTinGpp> ThongTinGpps { get; set; }

    public virtual DbSet<ThongTinNguonGoc> ThongTinNguonGocs { get; set; }

    public virtual DbSet<ThongTinNoiBo> ThongTinNoiBos { get; set; }

    public virtual DbSet<ThongTinPhapLy> ThongTinPhapLies { get; set; }

    public virtual DbSet<ThongTinThue> ThongTinThues { get; set; }

    public virtual DbSet<ThongTinXuatHoaDon> ThongTinXuatHoaDons { get; set; }

    public virtual DbSet<TonkhoTheohub> TonkhoTheohubs { get; set; }

    public virtual DbSet<UserMiddleware> UserMiddlewares { get; set; }

    public virtual DbSet<UserMwRole> UserMwRoles { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=DBCNN;Username=postgres;Password=0866449437khanh");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Api>(entity =>
        {
            entity.HasKey(e => e.IdApi).HasName("pk_api");

            entity.ToTable("api", "product");

            entity.Property(e => e.IdApi)
                .HasMaxLength(50)
                .HasColumnName("id_api");
            entity.Property(e => e.ApiParameters)
                .HasMaxLength(1000)
                .HasColumnName("api_parameters");
            entity.Property(e => e.EnableApi).HasColumnName("enable_api");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.MaNhomApi)
                .HasMaxLength(20)
                .HasColumnName("ma_nhom_api");
            entity.Property(e => e.UrlApi)
                .HasMaxLength(1000)
                .HasColumnName("url_api");

            entity.HasOne(d => d.MaNhomApiNavigation).WithMany(p => p.Apis)
                .HasForeignKey(d => d.MaNhomApi)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_manhapi_api_nhomapi");
        });

        modelBuilder.Entity<AuditTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("audit_table", "product");

            entity.Property(e => e.ByUser)
                .HasMaxLength(100)
                .HasColumnName("by_user");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.TransacttonDate).HasColumnName("transactton_date");
            entity.Property(e => e.TransacttonName)
                .HasMaxLength(200)
                .HasColumnName("transactton_name");
        });

        modelBuilder.Entity<CanhGiacDuoc>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaCdg }).HasName("pk_cgd");

            entity.ToTable("canh_giac_duoc", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaCdg)
                .HasMaxLength(20)
                .HasColumnName("ma_cdg");
            entity.Property(e => e.CanhGiacDuoc1).HasColumnName("canh_giac_duoc");
            entity.Property(e => e.CongDung).HasColumnName("cong_dung");
            entity.Property(e => e.TacDungPhu).HasColumnName("tac_dung_phu");
            entity.Property(e => e.TuongTacThuoc).HasColumnName("tuong_tac_thuoc");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.CanhGiacDuocs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_cgd_spkd");
        });

        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.MaChiNhanh).HasName("pk_chi_nhanh");

            entity.ToTable("chi_nhanh", "customer");

            entity.Property(e => e.MaChiNhanh)
                .HasMaxLength(20)
                .HasColumnName("ma_chi_nhanh");
            entity.Property(e => e.ChiNhanhMe).HasColumnName("chi_nhanh_me");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MoiQuanHe)
                .HasMaxLength(500)
                .HasColumnName("moi_quan_he");
            entity.Property(e => e.PhuongxaQuanhuyen)
                .HasMaxLength(2000)
                .HasColumnName("phuongxa_quanhuyen");
            entity.Property(e => e.SoDt)
                .HasMaxLength(20)
                .HasColumnName("so_dt");
            entity.Property(e => e.SonhaTenduong)
                .HasMaxLength(2000)
                .HasColumnName("sonha_tenduong");
            entity.Property(e => e.TenChiNhanh)
                .HasMaxLength(2000)
                .HasColumnName("ten_chi_nhanh");
            entity.Property(e => e.ThanhphoTinh)
                .HasMaxLength(2000)
                .HasColumnName("thanhpho_tinh");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.ChiNhanhs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("fk_makhb2b_cnh_khb2b");
        });

        modelBuilder.Entity<ChiPhiVanChuyen>(entity =>
        {
            entity.HasKey(e => e.MaChiPhiVanChuyen).HasName("pk_ma_chi_phi_van_chuyen");

            entity.ToTable("chi_phi_van_chuyen", "transaction");

            entity.Property(e => e.MaChiPhiVanChuyen)
                .HasMaxLength(20)
                .HasColumnName("ma_chi_phi_van_chuyen");
            entity.Property(e => e.ChiPhiDuKien).HasColumnName("chi_phi_du_kien");
            entity.Property(e => e.ThoiGianDuKien).HasColumnName("thoi_gian_du_kien");
            entity.Property(e => e.TinhGiao)
                .HasMaxLength(100)
                .HasColumnName("tinh_giao");
            entity.Property(e => e.TinhNhan)
                .HasMaxLength(100)
                .HasColumnName("tinh_nhan");
        });

        modelBuilder.Entity<ChuyenKhoa>(entity =>
        {
            entity.HasKey(e => e.MaChuyenKhoa).HasName("pk_chuyen_khoa");

            entity.ToTable("chuyen_khoa", "customer");

            entity.Property(e => e.MaChuyenKhoa)
                .HasMaxLength(10)
                .HasColumnName("ma_chuyen_khoa");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenChuyenKhoa)
                .HasMaxLength(1000)
                .HasColumnName("ten_chuyen_khoa");
        });

        modelBuilder.Entity<CongNo>(entity =>
        {
            entity.HasKey(e => new { e.MaKhachHang, e.MaCongNo }).HasName("pk_cong_no");

            entity.ToTable("cong_no", "customer");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaCongNo)
                .HasMaxLength(10)
                .HasColumnName("ma_cong_no");
            entity.Property(e => e.DanhGia)
                .HasMaxLength(2000)
                .HasColumnName("danh_gia");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HanMucCongNo).HasColumnName("han_muc_cong_no");
            entity.Property(e => e.ThoiHanCongNo).HasColumnName("thoi_han_cong_no");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.CongNos)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_makhb2b_cno_khb2b");
        });

        modelBuilder.Entity<DangBaoChe>(entity =>
        {
            entity.HasKey(e => e.MaDangBaoChe).HasName("pk_dang_bao_che");

            entity.ToTable("dang_bao_che", "product");

            entity.Property(e => e.MaDangBaoChe)
                .HasMaxLength(10)
                .HasColumnName("ma_dang_bao_che");
            entity.Property(e => e.DangBaoChe1)
                .HasMaxLength(500)
                .HasColumnName("dang_bao_che");
            entity.Property(e => e.DangBaoCheDacBiet)
                .HasMaxLength(500)
                .HasColumnName("dang_bao_che_dac_biet");
            entity.Property(e => e.MoTa).HasColumnName("mo_ta");
        });

        modelBuilder.Entity<DanhGiaSanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaNhaBan }).HasName("pk_danh_gia_san_pham");

            entity.ToTable("danh_gia_san_pham", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaNhaBan)
                .HasMaxLength(20)
                .HasColumnName("ma_nha_ban");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(20)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Rate).HasColumnName("rate");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DanhGiaSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_ma_san_pham_danh_gia");
        });

        modelBuilder.Entity<DanhMucLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaDanhMucLsp).HasName("pk_danh_muc_loai_sp");

            entity.ToTable("danh_muc_loai_sp", "product");

            entity.Property(e => e.MaDanhMucLsp)
                .HasMaxLength(10)
                .HasColumnName("ma_danh_muc_lsp");
            entity.Property(e => e.DinhNghia)
                .HasMaxLength(2000)
                .HasColumnName("dinh_nghia");
            entity.Property(e => e.TenDanhMucLsp)
                .HasMaxLength(2000)
                .HasColumnName("ten_danh_muc_lsp");
        });

        modelBuilder.Entity<DieuKienBaoQuan>(entity =>
        {
            entity.HasKey(e => e.MaDkbq).HasName("pk_dieu_kien_bao_quan");

            entity.ToTable("dieu_kien_bao_quan", "product");

            entity.Property(e => e.MaDkbq)
                .HasMaxLength(10)
                .HasColumnName("ma_dkbq");
            entity.Property(e => e.DieuKienBaoQuan1)
                .HasMaxLength(500)
                .HasColumnName("dieu_kien_bao_quan");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
        });

        modelBuilder.Entity<DinhHuongSanPham>(entity =>
        {
            entity.HasKey(e => e.MaDinhHuong).HasName("pk_dinh_huong");

            entity.ToTable("dinh_huong_san_pham", "product");

            entity.Property(e => e.MaDinhHuong)
                .HasMaxLength(10)
                .HasColumnName("ma_dinh_huong");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenDinhHuong)
                .HasMaxLength(1000)
                .HasColumnName("ten_dinh_huong");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaSoDonHang).HasName("pk_ma_so_don_hang");

            entity.ToTable("don_hang", "transaction");

            entity.Property(e => e.MaSoDonHang)
                .HasMaxLength(20)
                .HasColumnName("ma_so_don_hang");
            entity.Property(e => e.GhiChu).HasColumnName("ghi_chu");
            entity.Property(e => e.LuuYKhachHang).HasColumnName("luu_y_khach_hang");
            entity.Property(e => e.MaChiPhiVanChuyen)
                .HasMaxLength(20)
                .HasColumnName("ma_chi_phi_van_chuyen");
            entity.Property(e => e.MaGiaoDichNganHang).HasColumnName("ma_giao_dich_ngan_hang");
            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(20)
                .HasColumnName("ma_hoa_don");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaPhuongThuc)
                .HasMaxLength(20)
                .HasColumnName("ma_phuong_thuc");
            entity.Property(e => e.MaVoucher)
                .HasMaxLength(50)
                .HasColumnName("ma_voucher");
            entity.Property(e => e.NgayGiaoHang).HasColumnName("ngay_giao_hang");
            entity.Property(e => e.NgayLapDonHang).HasColumnName("ngay_lap_don_hang");
            entity.Property(e => e.QuanHuyen)
                .HasMaxLength(200)
                .HasColumnName("quan_huyen");
            entity.Property(e => e.SoLanGiaoHang).HasColumnName("so_lan_giao_hang");
            entity.Property(e => e.SoNha)
                .HasMaxLength(200)
                .HasColumnName("so_nha");
            entity.Property(e => e.TachDon).HasColumnName("tach_don");
            entity.Property(e => e.TenDuong)
                .HasMaxLength(200)
                .HasColumnName("ten_duong");
            entity.Property(e => e.ThanhPho)
                .HasMaxLength(200)
                .HasColumnName("thanh_pho");
            entity.Property(e => e.TongGiaTri).HasColumnName("tong_gia_tri");
            entity.Property(e => e.TongThue).HasColumnName("tong_thue");
            entity.Property(e => e.TrangThaiDonHang)
                .HasMaxLength(200)
                .HasColumnName("trang_thai_don_hang");
            entity.Property(e => e.TrangThaiThanhToan).HasColumnName("trang_thai_thanh_toan");
            entity.Property(e => e.XuatHoaDon).HasColumnName("xuat_hoa_don");

            entity.HasOne(d => d.MaChiPhiVanChuyenNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaChiPhiVanChuyen)
                .HasConstraintName("fk_machiphi_donhang_chiphivanchuyen");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ma_kh_donhang_khachhang");

            entity.HasOne(d => d.MaPhuongThucNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaPhuongThuc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_maphuongthuc_donhang_phuongthucthanhtoan");

            entity.HasOne(d => d.MaVoucherNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaVoucher)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_masodonhang_voucher_donhang");
        });

        modelBuilder.Entity<DonViTinh>(entity =>
        {
            entity.HasKey(e => e.MaDvt).HasName("pk_dvt");

            entity.ToTable("don_vi_tinh", "product");

            entity.Property(e => e.MaDvt)
                .HasMaxLength(10)
                .HasColumnName("ma_dvt");
            entity.Property(e => e.DvtCoSo)
                .HasMaxLength(200)
                .HasColumnName("dvt_co_so");
        });

        modelBuilder.Entity<GhiChuSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaGhiChu }).HasName("pk_ghichusp");

            entity.ToTable("ghi_chu_sp", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaGhiChu)
                .HasMaxLength(20)
                .HasColumnName("ma_ghi_chu");
            entity.Property(e => e.GhiChu1)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu_1");
            entity.Property(e => e.GhiChu2)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu_2");
            entity.Property(e => e.GhiChu3)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu_3");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.GhiChuSps)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_gchusp_spkd");
        });

        modelBuilder.Entity<GiaSanPham>(entity =>
        {
            entity.HasKey(e => e.MaGiaSanPham).HasName("pk_ma_gia_san_pham");

            entity.ToTable("gia_san_pham", "product");

            entity.Property(e => e.MaGiaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_gia_san_pham");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.GiaBan).HasColumnName("gia_ban");
            entity.Property(e => e.GiamGiaPhanTram).HasColumnName("giam_gia_phan_tram");
            entity.Property(e => e.GioCapNhatGia).HasColumnName("gio_cap_nhat_gia");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.NgayCapNhatGia).HasColumnName("ngay_cap_nhat_gia");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.GiaSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ma_gia_san_pham");
        });

        modelBuilder.Entity<Hub>(entity =>
        {
            entity.HasKey(e => e.MaHub).HasName("pk_hub");

            entity.ToTable("hub", "product");

            entity.Property(e => e.MaHub)
                .HasMaxLength(20)
                .HasColumnName("ma_hub");
            entity.Property(e => e.MaPhiVanChuyen)
                .HasMaxLength(20)
                .HasColumnName("ma_phi_van_chuyen");
            entity.Property(e => e.PhiVanChuyenNgoai).HasColumnName("phi_van_chuyen_ngoai");
            entity.Property(e => e.PhiVanChuyenNoi).HasColumnName("phi_van_chuyen_noi");
            entity.Property(e => e.QuanHuyen)
                .HasMaxLength(200)
                .HasColumnName("quan_huyen");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("sdt");
            entity.Property(e => e.SoNha).HasColumnName("so_nha");
            entity.Property(e => e.TenDuong)
                .HasMaxLength(200)
                .HasColumnName("ten_duong");
            entity.Property(e => e.TenHub)
                .HasMaxLength(100)
                .HasColumnName("ten_hub");
            entity.Property(e => e.TenNguoiDaiDienHub)
                .HasMaxLength(100)
                .HasColumnName("ten_nguoi_dai_dien_hub");
            entity.Property(e => e.TinhTp)
                .HasMaxLength(200)
                .HasColumnName("tinh_tp");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("pk_khach_hang");

            entity.ToTable("khachhang", "customer");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.Baohiemthanhtoan).HasColumnName("baohiemthanhtoan");
            entity.Property(e => e.CodeMonet)
                .HasMaxLength(50)
                .HasColumnName("code_monet");
            entity.Property(e => e.DoUuTien)
                .HasMaxLength(100)
                .HasColumnName("do_uu_tien");
            entity.Property(e => e.DuocDuyet).HasColumnName("duoc_duyet");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.Giayphepkinhdoanh)
                .HasMaxLength(2000)
                .HasColumnName("giayphepkinhdoanh");
            entity.Property(e => e.LaCsh).HasColumnName("la_csh");
            entity.Property(e => e.LaKhdv).HasColumnName("la_khdv");
            entity.Property(e => e.LaNcc).HasColumnName("la_ncc");
            entity.Property(e => e.LaNhaBan).HasColumnName("la_nha_ban");
            entity.Property(e => e.LaPartner).HasColumnName("la_partner");
            entity.Property(e => e.MaKhachHangEc)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang_ec");
            entity.Property(e => e.MaKhachHangGonsa)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang_gonsa");
            entity.Property(e => e.MaKhachHangOcs)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang_ocs");
            entity.Property(e => e.MaLoaiThe)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_the");
            entity.Property(e => e.MaNguoiDaiDien)
                .HasMaxLength(10)
                .HasColumnName("ma_nguoi_dai_dien");
            entity.Property(e => e.MaNhom)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom");
            entity.Property(e => e.MaPhanHang)
                .HasMaxLength(10)
                .HasColumnName("ma_phan_hang");
            entity.Property(e => e.MaPhanNganh)
                .HasMaxLength(10)
                .HasColumnName("ma_phan_nganh");
            entity.Property(e => e.MaTtXuatHd)
                .HasMaxLength(10)
                .HasColumnName("ma_tt_xuat_hd");
            entity.Property(e => e.Ngaythanhlap).HasColumnName("ngaythanhlap");
            entity.Property(e => e.PhuongxaQuanhuyen)
                .HasMaxLength(2000)
                .HasColumnName("phuongxa_quanhuyen");
            entity.Property(e => e.SoDt)
                .HasMaxLength(50)
                .HasColumnName("so_dt");
            entity.Property(e => e.SonhaTenduong)
                .HasMaxLength(2000)
                .HasColumnName("sonha_tenduong");
            entity.Property(e => e.TenChuNhaThuoc)
                .HasMaxLength(2000)
                .HasColumnName("ten_chu_nha_thuoc");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(2000)
                .HasColumnName("ten_khach_hang");
            entity.Property(e => e.ThanhphoTinh)
                .HasMaxLength(2000)
                .HasColumnName("thanhpho_tinh");
            entity.Property(e => e.TrangThaiHoatDong).HasColumnName("trang_thai_hoat_dong");

            entity.HasOne(d => d.MaLoaiTheNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaLoaiThe)
                .HasConstraintName("fk_malthe_kh_lttv");

            entity.HasOne(d => d.MaNguoiDaiDienNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaNguoiDaiDien)
                .HasConstraintName("fk_mandd_kh_nddpl");

            entity.HasOne(d => d.MaNhomNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaNhom)
                .HasConstraintName("fk_manhom_kh_nkh");

            entity.HasOne(d => d.MaPhanHangNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaPhanHang)
                .HasConstraintName("fk_maphang_kh_phang");

            entity.HasOne(d => d.MaPhanNganhNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaPhanNganh)
                .HasConstraintName("fk_mapn_kh_pnghanh");

            entity.HasOne(d => d.MaTtXuatHdNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.MaTtXuatHd)
                .HasConstraintName("fk_mattxhd_kh_ttxhdon");
        });

        modelBuilder.Entity<Khb2bCkhoa>(entity =>
        {
            entity.HasKey(e => new { e.MaKhachHang, e.MaChuyenKhoa }).HasName("pk_khb2b_ckhoa");

            entity.ToTable("khb2b_ckhoa", "customer");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaChuyenKhoa)
                .HasMaxLength(10)
                .HasColumnName("ma_chuyen_khoa");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");

            entity.HasOne(d => d.MaChuyenKhoaNavigation).WithMany(p => p.Khb2bCkhoas)
                .HasForeignKey(d => d.MaChuyenKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mackhoa_khb2bckhoa_ckhoa");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.Khb2bCkhoas)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_makhb2b_khb2bckhoa_khb2b");
        });

        modelBuilder.Entity<LichSuDonHang>(entity =>
        {
            entity.HasKey(e => e.MaLichSuDonHang).HasName("pk_ma_lich_su_don_hang");

            entity.ToTable("lich_su_don_hang", "transaction");

            entity.Property(e => e.MaLichSuDonHang)
                .HasMaxLength(20)
                .HasColumnName("ma_lich_su_don_hang");
            entity.Property(e => e.GioCapNhat).HasColumnName("gio_cap_nhat");
            entity.Property(e => e.MaSoDonHang)
                .HasMaxLength(20)
                .HasColumnName("ma_so_don_hang");
            entity.Property(e => e.NgayCapNhat).HasColumnName("ngay_cap_nhat");
            entity.Property(e => e.TrangThaiDonHang)
                .HasMaxLength(50)
                .HasColumnName("trang_thai_don_hang");

            entity.HasOne(d => d.MaSoDonHangNavigation).WithMany(p => p.LichSuDonHangs)
                .HasForeignKey(d => d.MaSoDonHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fkmadonhang_líchudonhang_tachdon");
        });

        modelBuilder.Entity<LoSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLo).HasName("pk_lo_san_pham");

            entity.ToTable("lo_san_pham", "product");

            entity.Property(e => e.MaLo)
                .HasMaxLength(20)
                .HasColumnName("ma_lo");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han");
            entity.Property(e => e.NgayNhap).HasColumnName("ngay_nhap");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LoSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_malo_san_pham");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("pk_loai_sp");

            entity.ToTable("loai_sp", "product");

            entity.Property(e => e.MaLoaiSp)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_sp");
            entity.Property(e => e.DinhNghia)
                .HasMaxLength(2000)
                .HasColumnName("dinh_nghia");
            entity.Property(e => e.MaDanhMucLsp)
                .HasMaxLength(10)
                .HasColumnName("ma_danh_muc_lsp");
            entity.Property(e => e.TenLoaiSp)
                .HasMaxLength(2000)
                .HasColumnName("ten_loai_sp");

            entity.HasOne(d => d.MaDanhMucLspNavigation).WithMany(p => p.LoaiSps)
                .HasForeignKey(d => d.MaDanhMucLsp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_malsp_dmlsp_lsp");
        });

        modelBuilder.Entity<LoaiSpNoiBo>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSpNoiBo).HasName("pk_loai_sp_noi_bo");

            entity.ToTable("loai_sp_noi_bo", "product");

            entity.Property(e => e.MaLoaiSpNoiBo)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_sp_noi_bo");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.KyHieuVietTat)
                .HasMaxLength(10)
                .HasColumnName("ky_hieu_viet_tat");
            entity.Property(e => e.TenLoaiSpNoiBo)
                .HasMaxLength(2000)
                .HasColumnName("ten_loai_sp_noi_bo");
        });

        modelBuilder.Entity<LoaiTheThanhVien>(entity =>
        {
            entity.HasKey(e => e.MaLoaiThe).HasName("pk_loai_the");

            entity.ToTable("loai_the_thanh_vien", "customer");

            entity.Property(e => e.MaLoaiThe)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_the");
            entity.Property(e => e.KyHieuVietTat)
                .HasMaxLength(10)
                .HasColumnName("ky_hieu_viet_tat");
            entity.Property(e => e.TenLoaiThe)
                .HasMaxLength(500)
                .HasColumnName("ten_loai_the");
        });

        modelBuilder.Entity<MwForm>(entity =>
        {
            entity.HasKey(e => e.MaForm).HasName("pk_mw_form");

            entity.ToTable("mw_form", "product");

            entity.Property(e => e.MaForm)
                .HasMaxLength(20)
                .HasColumnName("ma_form");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.TenForm)
                .HasMaxLength(200)
                .HasColumnName("ten_form");
        });

        modelBuilder.Entity<NgayHetHanLoSanPham>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ngay_het_han_lo_san_pham", "product");

            entity.Property(e => e.HanDung).HasColumnName("han_dung");
            entity.Property(e => e.MaLo)
                .HasMaxLength(20)
                .HasColumnName("ma_lo");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han");
            entity.Property(e => e.NgaySanXuat).HasColumnName("ngay_san_xuat");
        });

        modelBuilder.Entity<NguoiDaiDienPhapLy>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDaiDien).HasName("pk_nguoi_dai_dien");

            entity.ToTable("nguoi_dai_dien_phap_ly", "customer");

            entity.Property(e => e.MaNguoiDaiDien)
                .HasMaxLength(20)
                .HasColumnName("ma_nguoi_dai_dien");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.SoDt)
                .HasMaxLength(20)
                .HasColumnName("so_dt");
            entity.Property(e => e.TenNguoiDaiDien)
                .HasMaxLength(500)
                .HasColumnName("ten_nguoi_dai_dien");
        });

        modelBuilder.Entity<NhomApi>(entity =>
        {
            entity.HasKey(e => e.MaNhomApi).HasName("pk_nhom_api");

            entity.ToTable("nhom_api", "product");

            entity.Property(e => e.MaNhomApi)
                .HasMaxLength(20)
                .HasColumnName("ma_nhom_api");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.TenNhomApi)
                .HasMaxLength(500)
                .HasColumnName("ten_nhom_api");
        });

        modelBuilder.Entity<NhomKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("pk_nhom_khach_hang_b2b");

            entity.ToTable("nhom_khach_hang", "customer");

            entity.Property(e => e.MaNhom)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom");
            entity.Property(e => e.KyHieuVietTat)
                .HasMaxLength(10)
                .HasColumnName("ky_hieu_viet_tat");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenNhom)
                .HasMaxLength(500)
                .HasColumnName("ten_nhom");
        });

        modelBuilder.Entity<NhomKiemSoat>(entity =>
        {
            entity.HasKey(e => e.MaNhomKiemSoat).HasName("pk_nhom_kiem_soat");

            entity.ToTable("nhom_kiem_soat", "product");

            entity.Property(e => e.MaNhomKiemSoat)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kiem_soat");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.TenNhomKiemSoat)
                .HasMaxLength(2000)
                .HasColumnName("ten_nhom_kiem_soat");
            entity.Property(e => e.YNghia)
                .HasMaxLength(2000)
                .HasColumnName("y_nghia");
        });

        modelBuilder.Entity<NhomKiemSoatDacBiet>(entity =>
        {
            entity.HasKey(e => new { e.MaKhachHang, e.MaNksdb }).HasName("pk_nksdb");

            entity.ToTable("nhom_kiem_soat_dac_biet", "customer");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaNksdb)
                .HasMaxLength(10)
                .HasColumnName("ma_nksdb");
            entity.Property(e => e.CamTrongMotSoLinhVuc).HasColumnName("cam_trong_mot_so_linh_vuc");
            entity.Property(e => e.DangPhChuaDcGayNghien).HasColumnName("dang_ph_chua_dc_gay_nghien");
            entity.Property(e => e.DangPhChuaDchatHuongThan).HasColumnName("dang_ph_chua_dchat_huong_than");
            entity.Property(e => e.DangPhChuaTienChat).HasColumnName("dang_ph_chua_tien_chat");
            entity.Property(e => e.NguyenLieuLaDcGayNghienHuongThanPxaTchat).HasColumnName("nguyen_lieu_la_dc_gay_nghien_huong_than_pxa_tchat");
            entity.Property(e => e.ThuocDocNlieuDocLamThuoc).HasColumnName("thuoc_doc_nlieu_doc_lam_thuoc");
            entity.Property(e => e.ThuocGayNghien).HasColumnName("thuoc_gay_nghien");
            entity.Property(e => e.ThuocHanCheBanLe).HasColumnName("thuoc_han_che_ban_le");
            entity.Property(e => e.ThuocHuongThan).HasColumnName("thuoc_huong_than");
            entity.Property(e => e.ThuocPhongXa).HasColumnName("thuoc_phong_xa");
            entity.Property(e => e.ThuocTienChat).HasColumnName("thuoc_tien_chat");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.NhomKiemSoatDacBiets)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_makhb2b_nksdb_khb2b");
        });

        modelBuilder.Entity<NhomKinhDoanh>(entity =>
        {
            entity.HasKey(e => e.MaNhomKinhDoanh).HasName("pk_nhom_kinh_doanh");

            entity.ToTable("nhom_kinh_doanh", "product");

            entity.Property(e => e.MaNhomKinhDoanh)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kinh_doanh");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.KyHieuVietTat)
                .HasMaxLength(10)
                .HasColumnName("ky_hieu_viet_tat");
            entity.Property(e => e.TenNhomKinhDoanh)
                .HasMaxLength(2000)
                .HasColumnName("ten_nhom_kinh_doanh");
            entity.Property(e => e.YNghia)
                .HasMaxLength(2000)
                .HasColumnName("y_nghia");
        });

        modelBuilder.Entity<PhanHang>(entity =>
        {
            entity.HasKey(e => e.MaPhanHang).HasName("pk_phan_hang");

            entity.ToTable("phan_hang", "customer");

            entity.Property(e => e.MaPhanHang)
                .HasMaxLength(10)
                .HasColumnName("ma_phan_hang");
            entity.Property(e => e.Hang)
                .HasMaxLength(100)
                .HasColumnName("hang");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
        });

        modelBuilder.Entity<PhanNganh>(entity =>
        {
            entity.HasKey(e => e.MaPhanNganh).HasName("pk_phan_nganh");

            entity.ToTable("phan_nganh", "customer");

            entity.Property(e => e.MaPhanNganh)
                .HasMaxLength(10)
                .HasColumnName("ma_phan_nganh");
            entity.Property(e => e.MoTa)
                .HasMaxLength(2000)
                .HasColumnName("mo_ta");
            entity.Property(e => e.PhanNganh1)
                .HasMaxLength(500)
                .HasColumnName("phan_nganh");
        });

        modelBuilder.Entity<PhuongThucThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaPhuongThuc).HasName("pk_ma_phuong_thuc");

            entity.ToTable("phuong_thuc_thanh_toan", "transaction");

            entity.Property(e => e.MaPhuongThuc)
                .HasMaxLength(20)
                .HasColumnName("ma_phuong_thuc");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.TenPhuongThuc)
                .HasMaxLength(1000)
                .HasColumnName("ten_phuong_thuc");
        });

        modelBuilder.Entity<RoleApiUser>(entity =>
        {
            entity.HasKey(e => new { e.Username, e.IdApi }).HasName("pk_roleapiuser");

            entity.ToTable("role_api_user", "product");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.IdApi)
                .HasMaxLength(50)
                .HasColumnName("id_api");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");

            entity.HasOne(d => d.IdApiNavigation).WithMany(p => p.RoleApiUsers)
                .HasForeignKey(d => d.IdApi)
                .HasConstraintName("fk_idapi_roleapius_api");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.RoleApiUsers)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("fk_usname_roleapius_usmw");
        });

        modelBuilder.Entity<SanPhamDonHang>(entity =>
        {
            entity.HasKey(e => e.MaSanPhamDonHang).HasName("pk_ma_san_pham_don_hang");

            entity.ToTable("san_pham_don_hang", "transaction");

            entity.Property(e => e.MaSanPhamDonHang)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham_don_hang");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaSoDonHang)
                .HasMaxLength(20)
                .HasColumnName("ma_so_don_hang");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.SanPhamDonHangs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_madonhang_giasanphamtachdon_giasanpham");

            entity.HasOne(d => d.MaSoDonHangNavigation).WithMany(p => p.SanPhamDonHangs)
                .HasForeignKey(d => d.MaSoDonHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fkmadonhang_giasanphamtachdon_tachdon");
        });

        modelBuilder.Entity<SanPhamGop>(entity =>
        {
            entity.HasKey(e => e.MaGop).HasName("pk_spgop");

            entity.ToTable("san_pham_gop", "product");

            entity.Property(e => e.MaGop)
                .HasMaxLength(50)
                .HasColumnName("ma_gop");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
        });

        modelBuilder.Entity<SanPhamKinhDoanh>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("pk_san_pham_kinh_doanh");

            entity.ToTable("san_pham_kinh_doanh", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AmThanh).HasColumnName("am_thanh");
            entity.Property(e => e.DonviHop).HasColumnName("donvi_hop");
            entity.Property(e => e.GiaCoVat).HasColumnName("gia_co_vat");
            entity.Property(e => e.GiaKeKhai).HasColumnName("gia_ke_khai");
            entity.Property(e => e.GiongNoi).HasColumnName("giong_noi");
            entity.Property(e => e.HanCheBanLe).HasColumnName("han_che_ban_le");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(2000)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.MaChuSoHuu)
                .HasMaxLength(10)
                .HasColumnName("ma_chu_so_huu");
            entity.Property(e => e.MaDangBaoChe)
                .HasMaxLength(10)
                .HasColumnName("ma_dang_bao_che");
            entity.Property(e => e.MaDinhHuong)
                .HasMaxLength(10)
                .HasColumnName("ma_dinh_huong");
            entity.Property(e => e.MaDkbq)
                .HasMaxLength(10)
                .HasColumnName("ma_dkbq");
            entity.Property(e => e.MaDvt)
                .HasMaxLength(10)
                .HasColumnName("ma_dvt");
            entity.Property(e => e.MaGop)
                .HasMaxLength(50)
                .HasColumnName("ma_gop");
            entity.Property(e => e.MaLoaiSp)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_sp");
            entity.Property(e => e.MaLoaiSpNoiBo)
                .HasMaxLength(10)
                .HasColumnName("ma_loai_sp_noi_bo");
            entity.Property(e => e.MaNhaBan)
                .HasMaxLength(50)
                .HasColumnName("ma_nha_ban");
            entity.Property(e => e.MaNhomKiemSoat)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kiem_soat");
            entity.Property(e => e.MaNhomKinhDoanh)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kinh_doanh");
            entity.Property(e => e.MaRfid)
                .HasMaxLength(20)
                .HasColumnName("ma_rfid");
            entity.Property(e => e.MaSanPhamEc)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham_ec");
            entity.Property(e => e.MaSanPhamGonsa)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham_gonsa");
            entity.Property(e => e.MaSpNcc)
                .HasMaxLength(50)
                .HasColumnName("ma_sp_ncc");
            entity.Property(e => e.MaTichHop)
                .HasMaxLength(20)
                .HasColumnName("ma_tich_hop");
            entity.Property(e => e.PhienAm).HasColumnName("phien_am");
            entity.Property(e => e.QrCode).HasColumnName("qr_code");
            entity.Property(e => e.QuyCachDongGoi)
                .HasMaxLength(2000)
                .HasColumnName("quy_cach_dong_goi");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(2000)
                .HasColumnName("ten_san_pham");
            entity.Property(e => e.TenThuongMai)
                .HasMaxLength(2000)
                .HasColumnName("ten_thuong_mai");
            entity.Property(e => e.ThueVat).HasColumnName("thue_vat");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(500)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaDangBaoCheNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaDangBaoChe)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_madbc_spkd_dbc");

            entity.HasOne(d => d.MaDinhHuongNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaDinhHuong)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_madh_spkd_dhsp");

            entity.HasOne(d => d.MaDkbqNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaDkbq)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_madkbq_spkd_dkbq");

            entity.HasOne(d => d.MaDvtNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaDvt)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_madvt_spkd_dvt");

            entity.HasOne(d => d.MaGopNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaGop)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_magop_spkd_spgop");

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaLoaiSp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_malsp_spkd_lsp");

            entity.HasOne(d => d.MaLoaiSpNoiBoNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaLoaiSpNoiBo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_mlspnb_spkd_lspnb");

            entity.HasOne(d => d.MaNhaBanNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaNhaBan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ma_nha_ban");

            entity.HasOne(d => d.MaNhomKiemSoatNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaNhomKiemSoat)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_manks_spkd_nks");

            entity.HasOne(d => d.MaNhomKinhDoanhNavigation).WithMany(p => p.SanPhamKinhDoanhs)
                .HasForeignKey(d => d.MaNhomKinhDoanh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_manks_spkd_nkd");
        });

        modelBuilder.Entity<ThongTinChinh>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaTcc }).HasName("pk_ttc");

            entity.ToTable("thong_tin_chinh", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaTcc)
                .HasMaxLength(10)
                .HasColumnName("ma_tcc");
            entity.Property(e => e.DuongDung)
                .HasMaxLength(1000)
                .HasColumnName("duong_dung");
            entity.Property(e => e.GiaBanMoi).HasColumnName("gia_ban_moi");
            entity.Property(e => e.HamLuong)
                .HasMaxLength(1000)
                .HasColumnName("ham_luong");
            entity.Property(e => e.HanDung).HasColumnName("han_dung");
            entity.Property(e => e.HangGiaTot).HasColumnName("hang_gia_tot");
            entity.Property(e => e.HoatChat)
                .HasMaxLength(2000)
                .HasColumnName("hoat_chat");
            entity.Property(e => e.KeToa).HasColumnName("ke_toa");
            entity.Property(e => e.LieuDung).HasColumnName("lieu_dung");
            entity.Property(e => e.MaAtc)
                .HasMaxLength(100)
                .HasColumnName("ma_atc");
            entity.Property(e => e.NhomDieuTri)
                .HasMaxLength(1000)
                .HasColumnName("nhom_dieu_tri");
            entity.Property(e => e.PhamViPhanPhoi)
                .HasMaxLength(2000)
                .HasColumnName("pham_vi_phan_phoi");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ThongTinChinhs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_ttc_spkd");
        });

        modelBuilder.Entity<ThongTinGdp>(entity =>
        {
            entity.HasKey(e => e.MaTtGdp).HasName("pk_thong_tin_gdp");

            entity.ToTable("thong_tin_gdp", "customer");

            entity.Property(e => e.MaTtGdp)
                .HasMaxLength(20)
                .HasColumnName("ma_tt_gdp");
            entity.Property(e => e.FilePdf)
                .HasMaxLength(500)
                .HasColumnName("file_pdf");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.HoatDong).HasColumnName("hoat_dong");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.NgayCap).HasColumnName("ngay_cap");
            entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han");
            entity.Property(e => e.SoChungNhanGdp)
                .HasMaxLength(50)
                .HasColumnName("so_chung_nhan_gdp");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.ThongTinGdps)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("fk_makhb2b_ttgdp_khb2b");
        });

        modelBuilder.Entity<ThongTinGpp>(entity =>
        {
            entity.HasKey(e => e.MaTtGpp).HasName("pk_thong_tin_gpp");

            entity.ToTable("thong_tin_gpp", "customer");

            entity.Property(e => e.MaTtGpp)
                .HasMaxLength(10)
                .HasColumnName("ma_tt_gpp");
            entity.Property(e => e.FilePdf)
                .HasMaxLength(500)
                .HasColumnName("file_pdf");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.HoatDong).HasColumnName("hoat_dong");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.NgayCap).HasColumnName("ngay_cap");
            entity.Property(e => e.NgayHetHan).HasColumnName("ngay_het_han");
            entity.Property(e => e.SoChungNhanGpp)
                .HasMaxLength(50)
                .HasColumnName("so_chung_nhan_gpp");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.ThongTinGpps)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("fk_makhb2b_ttgpp_khb2b");
        });

        modelBuilder.Entity<ThongTinNguonGoc>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaTtng }).HasName("pk_ttng");

            entity.ToTable("thong_tin_nguon_goc", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaTtng)
                .HasMaxLength(10)
                .HasColumnName("ma_ttng");
            entity.Property(e => e.HieuLucSdk).HasColumnName("hieu_luc_sdk");
            entity.Property(e => e.NhaSanXuat)
                .HasMaxLength(2000)
                .HasColumnName("nha_san_xuat");
            entity.Property(e => e.NuocSanXuat)
                .HasMaxLength(2000)
                .HasColumnName("nuoc_san_xuat");
            entity.Property(e => e.SdkVoThoiHan).HasColumnName("sdk_vo_thoi_han");
            entity.Property(e => e.SoDangKy)
                .HasMaxLength(50)
                .HasColumnName("so_dang_ky");
            entity.Property(e => e.SoQdGiaHan)
                .HasMaxLength(200)
                .HasColumnName("so_qd_gia_han");
            entity.Property(e => e.TieuChuanSanXuat)
                .HasMaxLength(100)
                .HasColumnName("tieu_chuan_san_xuat");
            entity.Property(e => e.XuatXu)
                .HasMaxLength(1000)
                .HasColumnName("xuat_xu");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ThongTinNguonGocs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_ttng_sp");
        });

        modelBuilder.Entity<ThongTinNoiBo>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaTtnb }).HasName("pk_ttnb");

            entity.ToTable("thong_tin_noi_bo", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaTtnb)
                .HasMaxLength(10)
                .HasColumnName("ma_ttnb");
            entity.Property(e => e.DaDuocCapPhepTtThuocQc).HasColumnName("da_duoc_cap_phep_tt_thuoc_qc");
            entity.Property(e => e.LamToRoiHayKhong).HasColumnName("lam_to_roi_hay_khong");
            entity.Property(e => e.NgayNgungSanPham).HasColumnName("ngay_ngung_san_pham");
            entity.Property(e => e.NgaySinhNhatSp).HasColumnName("ngay_sinh_nhat_sp");
            entity.Property(e => e.NgayTao).HasColumnName("ngay_tao");
            entity.Property(e => e.QuanLySanPham)
                .HasMaxLength(1000)
                .HasColumnName("quan_ly_san_pham");
            entity.Property(e => e.TheoDoiSanPham)
                .HasMaxLength(1000)
                .HasColumnName("theo_doi_san_pham");
            entity.Property(e => e.TinhTrangToRoiNcc).HasColumnName("tinh_trang_to_roi_ncc");
            entity.Property(e => e.TrangThaiHoSo)
                .HasMaxLength(1000)
                .HasColumnName("trang_thai_ho_so");
            entity.Property(e => e.UserTao)
                .HasMaxLength(1000)
                .HasColumnName("user_tao");
            entity.Property(e => e.XinCapPhepQc).HasColumnName("xin_cap_phep_qc");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ThongTinNoiBos)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_ttnb_spkd");
        });

        modelBuilder.Entity<ThongTinPhapLy>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaTtpl }).HasName("pk_ttpl");

            entity.ToTable("thong_tin_phap_ly", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaTtpl)
                .HasMaxLength(10)
                .HasColumnName("ma_ttpl");
            entity.Property(e => e.NhomTheoTt15).HasColumnName("nhom_theo_tt15");
            entity.Property(e => e.NhomTheoTt3015).HasColumnName("nhom_theo_tt30_15");
            entity.Property(e => e.SttTheoTt15).HasColumnName("stt_theo_tt15");
            entity.Property(e => e.SttTheoTt3015).HasColumnName("stt_theo_tt30_15");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ThongTinPhapLies)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_masp_spkd_ttpl");
        });

        modelBuilder.Entity<ThongTinThue>(entity =>
        {
            entity.HasKey(e => new { e.MaTtThue, e.MaKhachHang }).HasName("pk_thong_tin_thue");

            entity.ToTable("thong_tin_thue", "customer");

            entity.Property(e => e.MaTtThue)
                .HasMaxLength(20)
                .HasColumnName("ma_tt_thue");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.HoatDong).HasColumnName("hoat_dong");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(50)
                .HasColumnName("ma_so_thue");
            entity.Property(e => e.XacNhanThue).HasColumnName("xac_nhan_thue");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.ThongTinThues)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_makhb2b_ttthue_khb2b");
        });

        modelBuilder.Entity<ThongTinXuatHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaTtXuatHd).HasName("pk_thong_tin_xuat_hd");

            entity.ToTable("thong_tin_xuat_hoa_don", "customer");

            entity.Property(e => e.MaTtXuatHd)
                .HasMaxLength(10)
                .HasColumnName("ma_tt_xuat_hd");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(2000)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.LuuY)
                .HasMaxLength(2000)
                .HasColumnName("luu_y");
            entity.Property(e => e.SoDt)
                .HasMaxLength(20)
                .HasColumnName("so_dt");
            entity.Property(e => e.TenDonVi)
                .HasMaxLength(2000)
                .HasColumnName("ten_don_vi");
            entity.Property(e => e.TenKhachHangXuatHoaDon)
                .HasMaxLength(2000)
                .HasColumnName("ten_khach_hang_xuat_hoa_don");
            entity.Property(e => e.TenNguoiMuaHang)
                .HasMaxLength(500)
                .HasColumnName("ten_nguoi_mua_hang");
        });

        modelBuilder.Entity<TonkhoTheohub>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaHub }).HasName("pk_tonkho_theohub");

            entity.ToTable("tonkho_theohub", "product");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaHub)
                .HasMaxLength(20)
                .HasColumnName("ma_hub");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.GioCapNhatTonKho).HasColumnName("gio_cap_nhat_ton_kho");
            entity.Property(e => e.MaNhaBan)
                .HasMaxLength(20)
                .HasColumnName("ma_nha_ban");
            entity.Property(e => e.NgayCapNhatTonKho).HasColumnName("ngay_cap_nhat_ton_kho");
            entity.Property(e => e.SoLuongTonKho).HasColumnName("so_luong_ton_kho");

            entity.HasOne(d => d.MaHubNavigation).WithMany(p => p.TonkhoTheohubs)
                .HasForeignKey(d => d.MaHub)
                .HasConstraintName("fk_ma_hub");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.TonkhoTheohubs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_ma_san_pham");
        });

        modelBuilder.Entity<UserMiddleware>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("pk_user_middleware");

            entity.ToTable("user_middleware", "product");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .HasColumnName("ma_nhan_vien");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasColumnName("note");
            entity.Property(e => e.Passwd)
                .HasMaxLength(100)
                .HasColumnName("passwd");
            entity.Property(e => e.UserPrivilege)
                .HasMaxLength(50)
                .HasColumnName("user_privilege");
        });

        modelBuilder.Entity<UserMwRole>(entity =>
        {
            entity.HasKey(e => e.Marole).HasName("pk_user_mw_role");

            entity.ToTable("user_mw_role", "product");

            entity.Property(e => e.Marole)
                .HasMaxLength(50)
                .HasColumnName("marole");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.MaForm)
                .HasMaxLength(20)
                .HasColumnName("ma_form");
            entity.Property(e => e.Tenrole)
                .HasMaxLength(200)
                .HasColumnName("tenrole");

            entity.HasOne(d => d.MaFormNavigation).WithMany(p => p.UserMwRoles)
                .HasForeignKey(d => d.MaForm)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_maform_usermwrole_mwform");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.Username, e.Marole }).HasName("pk_user_role");

            entity.ToTable("user_role", "product");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Marole)
                .HasMaxLength(50)
                .HasColumnName("marole");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");

            entity.HasOne(d => d.MaroleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Marole)
                .HasConstraintName("fk_marole_userrole_usmwrole");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("fk_username_usrole_usmw");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.MaVoucher).HasName("pk_ma_voucher");

            entity.ToTable("voucher", "transaction");

            entity.Property(e => e.MaVoucher)
                .HasMaxLength(50)
                .HasColumnName("ma_voucher");
            entity.Property(e => e.GiaGiam).HasColumnName("gia_giam");
            entity.Property(e => e.MoTa).HasColumnName("mo_ta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
