using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace trackingPlatform.Models;

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

    public virtual DbSet<DangBaoChe> DangBaoChes { get; set; }

    public virtual DbSet<DanhMucLoaiSp> DanhMucLoaiSps { get; set; }

    public virtual DbSet<DieuKienBaoQuan> DieuKienBaoQuans { get; set; }

    public virtual DbSet<DinhHuongSanPham> DinhHuongSanPhams { get; set; }

    public virtual DbSet<DonViTinh> DonViTinhs { get; set; }

    public virtual DbSet<GhiChuSp> GhiChuSps { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<LoaiSpNoiBo> LoaiSpNoiBos { get; set; }

    public virtual DbSet<MwForm> MwForms { get; set; }

    public virtual DbSet<NhomApi> NhomApis { get; set; }

    public virtual DbSet<NhomKiemSoat> NhomKiemSoats { get; set; }

    public virtual DbSet<NhomKinhDoanh> NhomKinhDoanhs { get; set; }

    public virtual DbSet<RoleApiUser> RoleApiUsers { get; set; }

    public virtual DbSet<SanPhamGop> SanPhamGops { get; set; }

    public virtual DbSet<SanPhamKinhDoanh> SanPhamKinhDoanhs { get; set; }

    public virtual DbSet<ThongTinChinh> ThongTinChinhs { get; set; }

    public virtual DbSet<ThongTinNguonGoc> ThongTinNguonGocs { get; set; }

    public virtual DbSet<ThongTinNoiBo> ThongTinNoiBos { get; set; }

    public virtual DbSet<ThongTinPhapLy> ThongTinPhapLies { get; set; }

    public virtual DbSet<UserMiddleware> UserMiddlewares { get; set; }

    public virtual DbSet<UserMwRole> UserMwRoles { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Database=product;Username=postgres;Password=0866449437khanh");
    //{
    //    IConfigurationRoot configuration = new ConfigurationBuilder()
    //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //        .AddJsonFile("appsettings.json")
    //        .Build();
    //    optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging().UseNpgsql(configuration.GetConnectionString("CNN_DB"));
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Api>(entity =>
        {
            entity.HasKey(e => e.IdApi).HasName("pk_api");

            entity.ToTable("api", "product_data");

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
                .ToTable("audit_table", "product_data");

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

            entity.ToTable("canh_giac_duoc", "product_data");

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

        modelBuilder.Entity<DangBaoChe>(entity =>
        {
            entity.HasKey(e => e.MaDangBaoChe).HasName("pk_dang_bao_che");

            entity.ToTable("dang_bao_che", "product_data");

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

        modelBuilder.Entity<DanhMucLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaDanhMucLsp).HasName("pk_danh_muc_loai_sp");

            entity.ToTable("danh_muc_loai_sp", "product_data");

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

            entity.ToTable("dieu_kien_bao_quan", "product_data");

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

            entity.ToTable("dinh_huong_san_pham", "product_data");

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

        modelBuilder.Entity<DonViTinh>(entity =>
        {
            entity.HasKey(e => e.MaDvt).HasName("pk_dvt");

            entity.ToTable("don_vi_tinh", "product_data");

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

            entity.ToTable("ghi_chu_sp", "product_data");

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

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("pk_loai_sp");

            entity.ToTable("loai_sp", "product_data");

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

            entity.ToTable("loai_sp_noi_bo", "product_data");

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

        modelBuilder.Entity<MwForm>(entity =>
        {
            entity.HasKey(e => e.MaForm).HasName("pk_mw_form");

            entity.ToTable("mw_form", "product_data");

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

        modelBuilder.Entity<NhomApi>(entity =>
        {
            entity.HasKey(e => e.MaNhomApi).HasName("pk_nhom_api");

            entity.ToTable("nhom_api", "product_data");

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

        modelBuilder.Entity<NhomKiemSoat>(entity =>
        {
            entity.HasKey(e => e.MaNhomKiemSoat).HasName("pk_nhom_kiem_soat");

            entity.ToTable("nhom_kiem_soat", "product_data");

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

        modelBuilder.Entity<NhomKinhDoanh>(entity =>
        {
            entity.HasKey(e => e.MaNhomKinhDoanh).HasName("pk_nhom_kinh_doanh");

            entity.ToTable("nhom_kinh_doanh", "product_data");

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

        modelBuilder.Entity<RoleApiUser>(entity =>
        {
            entity.HasKey(e => new { e.Username, e.IdApi }).HasName("pk_roleapiuser");

            entity.ToTable("role_api_user", "product_data");

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

        modelBuilder.Entity<SanPhamGop>(entity =>
        {
            entity.HasKey(e => e.MaGop).HasName("pk_spgop");

            entity.ToTable("san_pham_gop", "product_data");

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

            entity.ToTable("san_pham_kinh_doanh", "product_data");

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
            entity.Property(e => e.MaNhomKiemSoat)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kiem_soat");
            entity.Property(e => e.MaNhomKinhDoanh)
                .HasMaxLength(10)
                .HasColumnName("ma_nhom_kinh_doanh");
            entity.Property(e => e.MaRfid)
                .HasMaxLength(20)
                .HasColumnName("ma_rfid");
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

            entity.ToTable("thong_tin_chinh", "product_data");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.MaTcc)
                .HasMaxLength(10)
                .HasColumnName("ma_tcc");
            entity.Property(e => e.DuongDung)
                .HasMaxLength(1000)
                .HasColumnName("duong_dung");
            entity.Property(e => e.HamLuong)
                .HasMaxLength(1000)
                .HasColumnName("ham_luong");
            entity.Property(e => e.HanDung).HasColumnName("han_dung");
            entity.Property(e => e.HoatChat)
                .HasMaxLength(2000)
                .HasColumnName("hoat_chat");
            entity.Property(e => e.KeToa).HasColumnName("ke_toa");
            entity.Property(e => e.LieuDung).HasColumnName("lieu_dung");
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

        modelBuilder.Entity<ThongTinNguonGoc>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaTtng }).HasName("pk_ttng");

            entity.ToTable("thong_tin_nguon_goc", "product_data");

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

            entity.ToTable("thong_tin_noi_bo", "product_data");

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

            entity.ToTable("thong_tin_phap_ly", "product_data");

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

        modelBuilder.Entity<UserMiddleware>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("pk_user_middleware");

            entity.ToTable("user_middleware", "product_data");

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

            entity.ToTable("user_mw_role", "product_data");

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

            entity.ToTable("user_role", "product_data");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
