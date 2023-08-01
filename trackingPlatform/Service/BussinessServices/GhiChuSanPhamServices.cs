﻿using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.RepositoryServices;
using AutoMapper;

namespace trackingPlatform.Service.BussinessServices
{
    public class GhiChuSanPhamServices
    {
        private readonly GhiChuSanPhamRepositoryServices _ghiChuSanPhamRepositoryServices;
        private readonly IMapper _mapper;
        public GhiChuSanPhamServices(GhiChuSanPhamRepositoryServices ghiChuSanPhamRepositories, IMapper mapper)
        {
            _ghiChuSanPhamRepositoryServices = ghiChuSanPhamRepositories;
            _mapper = mapper;
        }
        public async Task<GhiChuSp> FindByNameAsync(string ghiChu1)
        {
            return await _ghiChuSanPhamRepositoryServices.FindByGhiChu1(ghiChu1);
        }

        public async Task<GhiChuSp> GetCanhGiacDuoc(string maGhiChu)
        {
            return await _ghiChuSanPhamRepositoryServices.FindByMaCgd(maGhiChu);

        }

        public async Task<IEnumerable<GhiChuSp>> GetAllCanhGiacDuoc(int top, int skip, string? filter)
        {
            return await _ghiChuSanPhamRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(GhiChuSp ghiChuSp)
        {
            await _ghiChuSanPhamRepositoryServices.AddAsync(ghiChuSp);
        }

        public async Task<GhiChuSp> DeleteAsync(string maGhiChu)
        {
            GhiChuSp ghiChuSp = await GetCanhGiacDuoc(maGhiChu);
            if (ghiChuSp != null)
            {
                await _ghiChuSanPhamRepositoryServices.DeleteAsync(ghiChuSp);
            }
            return ghiChuSp;
        }

        public async Task<PostDto> AddorUpdateCanhGiacDuoc(List<GhiChuSpRequest> GhiChuSpRequests)
        {
            List<GhiChuSp> ghiChuSps = _mapper.Map<List<GhiChuSp>>(GhiChuSpRequests);
            return await _ghiChuSanPhamRepositoryServices.AddorUpdateGhiChuSps(ghiChuSps);
        }
    }
}