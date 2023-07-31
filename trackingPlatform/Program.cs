using Microsoft.EntityFrameworkCore;
using System.Reflection;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Service.ExternalServices;
using trackingPlatform.Service.RepositoryServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<CnnDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("CnnDbContext")));



builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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
builder.Services.AddScoped<ManualMapper>();

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

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
