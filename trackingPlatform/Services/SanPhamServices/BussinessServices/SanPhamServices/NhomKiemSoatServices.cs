﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/NhomKiemSoatServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/NhomKiemSoatServices.cs
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class NhomKiemSoatServices
    {
        private readonly NhomKiemSoatRepositoryService _nhomKiemSoatRepositoryService;
        private readonly IMapper _mapper;


        public NhomKiemSoatServices(NhomKiemSoatRepositoryService nhomKiemSoatRepositoryService, IMapper mapper)
        {
            _nhomKiemSoatRepositoryService = nhomKiemSoatRepositoryService;
            _mapper = mapper;
        }

        public async Task<NhomKiemSoat> FindByNameAsync(string tenNhomKiemSoat)
        {
            return await _nhomKiemSoatRepositoryService.FindByTenNhomKiemSoat(tenNhomKiemSoat);
        }

        public async Task<NhomKiemSoat> GetNhomKiemSoat(string maNhomKiemSoat)
        {
            return await _nhomKiemSoatRepositoryService.FindByMaNhomKiemSoat(maNhomKiemSoat);

        }

        public async Task<IEnumerable<NhomKiemSoat>> GetAllNhomKiemSoat(int top, int skip, string? filter)
        {
            return await _nhomKiemSoatRepositoryService.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NhomKiemSoat nhomKiemSoat)
        {
            await _nhomKiemSoatRepositoryService.AddAsync(nhomKiemSoat);
        }

        public async Task<NhomKiemSoat> DeleteAsync(string maNhomKiemSoat)
        {
            NhomKiemSoat nhomKiemSoat = await GetNhomKiemSoat(maNhomKiemSoat);
            if (nhomKiemSoat != null)
            {
                await _nhomKiemSoatRepositoryService.DeleteAsync(nhomKiemSoat);
            }
            return nhomKiemSoat;
        }

        public async Task<PostDto> AddorUpdateNhomKiemSoat(List<NhomKiemSoatRequest> nhomKiemSoatRequest)
        {
            List<NhomKiemSoat> nhomKiemSoats = _mapper.Map<List<NhomKiemSoat>>(nhomKiemSoatRequest);
            return await _nhomKiemSoatRepositoryService.AddorUpdateNhomKiemSoats(nhomKiemSoats);
        }
    }
}
