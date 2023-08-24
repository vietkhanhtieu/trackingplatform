using Microsoft.EntityFrameworkCore;
using System.Reflection;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using trackingPlatform.RestClients;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.ExternalServices.SanPhamExternalServices;
using trackingPlatform.Services.BussinessServices.KhachHangServices;
using trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices;
using trackingPlatform.Services.ExternalServices.KhachHangExternalServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "API Product",
            Version = "v1"
        }
     );

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<CnnDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("CnnDbContext")));



builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddControllers(options => options.UseDateOnlyTimeOnlyStringConverters())
    .AddJsonOptions(options => options.UseDateOnlyTimeOnlyStringConverters());

builder.Services.AddSwaggerGen(options =>
                    {
                        options.UseDateOnlyTimeOnlyStringConverters();
                    });

// sanPham
builder.Services.AddScoped<DangBaoCheService>();
builder.Services.AddScoped<DinhHuongSanPhamServices>();
builder.Services.AddScoped<NhomKinhDoanhServices>();
builder.Services.AddScoped<DieuKienBaoQuanServices>();
builder.Services.AddScoped<NhomKiemSoatServices>();
builder.Services.AddScoped<DonViTinhService>();
builder.Services.AddScoped<LoaiSpNoiBoServices>();
builder.Services.AddScoped<SanPhamGopServices>();
builder.Services.AddScoped<LoaiSpServices>();
builder.Services.AddScoped<DanhMucLoaiSpServices>();
builder.Services.AddScoped<SanPhamKinhDoanhServices>();
builder.Services.AddScoped<CanhGiacDuocServices>();
builder.Services.AddScoped<GhiChuSanPhamServices>();
builder.Services.AddScoped<ThongTinChinhServices>();
builder.Services.AddScoped<ThongTinNguonGocServices>();
builder.Services.AddScoped<ThongTinPhapLyServices>();
builder.Services.AddScoped<ThongTinNoiBoServices>();
builder.Services.AddScoped<ManualMapper>();

builder.Services.AddScoped<ThongTinNoiBoRepositoryServices>();
builder.Services.AddScoped<ThongTinPhapLyRepositoryServices>();
builder.Services.AddScoped<ThongTinNguonGocRepositoryServices>();
builder.Services.AddScoped<ThongTinChinhRepositoryServices>();
builder.Services.AddScoped<GhiChuSanPhamRepositoryServices>();
builder.Services.AddScoped<CanhGiacDuocRepositoryServices>();
builder.Services.AddScoped<SanPhamKinhDoanhRepositoryServices>();
builder.Services.AddScoped<DanhMucLoaiSanPhamRepositoryServices>();
builder.Services.AddScoped<SanPhamGopRepositorySevices>();
builder.Services.AddScoped<LoaiSpRepositoryServices>();
builder.Services.AddScoped<LoaiSpNoiBoRepositoryService>();
builder.Services.AddScoped<DonViTinhRepositoryServices>();
builder.Services.AddScoped<NhomKiemSoatRepositoryService>();
builder.Services.AddScoped<DieuKienBaoQuanRepositoryService>();
builder.Services.AddScoped<NhomKinhDoanhRepositoryServices>();
builder.Services.AddScoped<DinhHuongSanPhamRepositoryServices>();
builder.Services.AddScoped<DangBaoCheRepositoryServices>();
builder.Services.AddScoped<WooCommerceService>();


// khachHang
builder.Services.AddScoped<PhuongThucLienLacRepositoryServices>();
builder.Services.AddScoped<KhachHangB2cRepositoryServices>();
builder.Services.AddScoped<LoaiTheThanhVienRepositoryServices>();
builder.Services.AddScoped<NhomKiemSoatDacBietRepositoryServices>();
builder.Services.AddScoped<PhanHangRepositoryServices>();
builder.Services.AddScoped<PhanNganhRepositoryServices>();
builder.Services.AddScoped<NhomKhachHangB2BRepositoryServices>();
builder.Services.AddScoped<NguoiDaiDienRepositoryServices>();
builder.Services.AddScoped<LoaiHinhDichVuRepositoryServices>();
builder.Services.AddScoped<NgayCotMocRepositoryServices>();
builder.Services.AddScoped<ChuyenKhoaRepositoryServices>();
builder.Services.AddScoped<KhachHangB2bRepositoryServices>();
builder.Services.AddScoped<NguoiNhanTtHdonRepositoryServices>();
builder.Services.AddScoped<ThongTinGdpRepositoryServices>();
builder.Services.AddScoped<ThongTinGppRepositoryServices>();
builder.Services.AddScoped<ThongTinThueRepositoryServices>();
builder.Services.AddScoped<CbnvKhachHangRepositoryServices>();
builder.Services.AddScoped<ChiNhanhRepositoryServices>();
builder.Services.AddScoped<CongNoRepositoryServices>();
builder.Services.AddScoped<ThongTinXuatHoaDonServices>();
builder.Services.AddScoped<KhachHangServices>();
builder.Services.AddScoped<Khb2bLhdvServices>();
builder.Services.AddScoped<KhNgayCotMocServices>();
builder.Services.AddScoped<Khb2bCkhoaServices>();

builder.Services.AddScoped<Khb2bCkhoaRepositoryServices>();
builder.Services.AddScoped<KhNgayCotMocRepositoryServices>();
builder.Services.AddScoped<Khb2bLhdvuRepositoryServices>();
builder.Services.AddScoped<KhachHangRepositoryServices>();
builder.Services.AddScoped<ThongTinXuatHoaDonRepositoryServices>();
builder.Services.AddScoped<CongNoServices>();
builder.Services.AddScoped<ChiNhanhServices>();
builder.Services.AddScoped<CbnvKhachHangServices>();
builder.Services.AddScoped<ThongTinThueServices>();
builder.Services.AddScoped<ThongTinGppServices>();
builder.Services.AddScoped<ThongTinKhachGdpServices>();
builder.Services.AddScoped<NguoiNhanTtHdonServices>();
builder.Services.AddScoped<KhachHangB2BServices>();
builder.Services.AddScoped<ChuyenKhoaServices>();
builder.Services.AddScoped<NgayCotMocServices>();
builder.Services.AddScoped<LoaiHinhDichVuServices>();
builder.Services.AddScoped<NguoiDaiDienPhapLyServices>();
builder.Services.AddScoped<NhomKhachHangB2BServices>();
builder.Services.AddScoped<PhanNganhServices>();
builder.Services.AddScoped<PhanHangServices>();
builder.Services.AddScoped<NhomKiemSoatDacBietServices>();
builder.Services.AddScoped<LoaiTheThanhVienServices>();
builder.Services.AddScoped<KhachHangB2CServices>();
builder.Services.AddScoped<PhuongThucLienLacServices>();
builder.Services.AddScoped<ManualMapperKhachHang>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
