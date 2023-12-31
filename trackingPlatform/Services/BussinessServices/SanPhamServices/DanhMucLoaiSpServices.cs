﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/DanhMucLoaiSpServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/DanhMucLoaiSpServices.cs

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class DanhMucLoaiSpServices
    {
        private readonly DanhMucLoaiSanPhamRepositoryServices _danhMucLoaiSanPhamRepositoryServices;
        private readonly IMapper _mapper;

        public DanhMucLoaiSpServices(DanhMucLoaiSanPhamRepositoryServices danhMucLoaiSanPhamRepositoryServices, IMapper mapper)
        {
            _danhMucLoaiSanPhamRepositoryServices = danhMucLoaiSanPhamRepositoryServices;
            _mapper = mapper;
        }

        public async Task<DanhMucLoaiSp> GetDanhMucLoaiSp(string maDanhMuc)
        {
            return await _danhMucLoaiSanPhamRepositoryServices.FindByMaDanhMucLoaiSp(maDanhMuc);

        }

        public async Task AddAsync(DanhMucLoaiSp danhMucLoaiSp)
        {
            await _danhMucLoaiSanPhamRepositoryServices.AddAsync(danhMucLoaiSp);
        }

        public async Task<IEnumerable<DanhMucLoaiSp>> GetAllDanhMucLoaiSp(int top, int skip, string? filter)
        {
            return await _danhMucLoaiSanPhamRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task<DanhMucLoaiSp> DeleteAsync(string maDvt)
        {
            DanhMucLoaiSp DanhMucLoaiSp = await GetDanhMucLoaiSp(maDvt);
            if (DanhMucLoaiSp != null)
            {
                await _danhMucLoaiSanPhamRepositoryServices.DeleteAsync(DanhMucLoaiSp);
            }
            return DanhMucLoaiSp;
        }

        public async Task<PostDto> AddorUpdateDanhMucLoaiSp(List<DanhMucLoaiSpRequest> DanhMucLoaiSpRequests)
        {
            List<DanhMucLoaiSp> DanhMucLoaiSps = _mapper.Map<List<DanhMucLoaiSp>>(DanhMucLoaiSpRequests);
            return await _danhMucLoaiSanPhamRepositoryServices.AddorUpdateDanhMucLoaiSp(DanhMucLoaiSps);
        }
    }
}
