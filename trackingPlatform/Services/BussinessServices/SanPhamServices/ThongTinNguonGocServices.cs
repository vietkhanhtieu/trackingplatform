﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/ThongTinNguonGocServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/ThongTinNguonGocServices.cs
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class ThongTinNguonGocServices
    {
        private readonly ThongTinNguonGocRepositoryServices _thongTinNguonGocRepositoryServices;
        private readonly IMapper _mapper;
        public ThongTinNguonGocServices(ThongTinNguonGocRepositoryServices thongTinNguonGocRepositoryServices, IMapper mapper)
        {
            _thongTinNguonGocRepositoryServices = thongTinNguonGocRepositoryServices;
            _mapper = mapper;
        }
        //public async Task<GhiChuSp> FindByNameAsync(string ghiChu1)
        //{
        //    return await _thongTinNguonGocRepositoryServices.FindByGhiChu1(ghiChu1);
        //}

        public async Task<ThongTinNguonGoc> GetThongTinNguonGoc(string maTTNG)
        {
            return await _thongTinNguonGocRepositoryServices.FindByMaTTNG(maTTNG);

        }

        public async Task<IEnumerable<ThongTinNguonGoc>> GetAllThongTinNguonGoc(int top, int skip, string? filter)
        {
            return await _thongTinNguonGocRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(ThongTinNguonGoc thongTinNguonGoc)
        {
            await _thongTinNguonGocRepositoryServices.AddAsync(thongTinNguonGoc);
        }
        public async Task UpdateAsync(ThongTinNguonGoc thongTinNguonGoc)
        {
            await _thongTinNguonGocRepositoryServices.UpdateAsync(thongTinNguonGoc);
        }
        public async Task<ThongTinNguonGoc> DeleteAsync(string maTTNG)
        {
            ThongTinNguonGoc thongTinNguonGoc = await GetThongTinNguonGoc(maTTNG);
            if (thongTinNguonGoc != null)
            {
                await _thongTinNguonGocRepositoryServices.DeleteAsync(thongTinNguonGoc);
            }
            return thongTinNguonGoc;
        }

        public async Task<PostDto> AddorUpdateThongTinNguonGoc(List<ThongTinNguonGocRequest> thongTinNguonGocRequests)
        {
            List<ThongTinNguonGoc> thongTinNguonGocs = _mapper.Map<List<ThongTinNguonGoc>>(thongTinNguonGocRequests);
            return await _thongTinNguonGocRepositoryServices.AddorUpdateThongTinNguonGocs(thongTinNguonGocs);
        }
    }
}
