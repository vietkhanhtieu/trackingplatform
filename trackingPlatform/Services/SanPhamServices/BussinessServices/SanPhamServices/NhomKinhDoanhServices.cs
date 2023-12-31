﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/NhomKinhDoanhServices.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/NhomKinhDoanhServices.cs

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class NhomKinhDoanhServices
    {
        private readonly NhomKinhDoanhRepositoryServices _nhomKinhDoanhRepositoryServices;
        private readonly IMapper _mapper;

        public NhomKinhDoanhServices(NhomKinhDoanhRepositoryServices nhomKinhDoanhRepositoryServices, IMapper mapper)
        {
            _nhomKinhDoanhRepositoryServices = nhomKinhDoanhRepositoryServices;
            _mapper = mapper;
        }
        public async Task<NhomKinhDoanh> FindByNameAsync(string tenNhomKinhDoanh)
        {
            return await _nhomKinhDoanhRepositoryServices.FindByTenNhomKinhDoanh(tenNhomKinhDoanh);
        }

        public async Task<NhomKinhDoanh> GetNhomKinhDoanhAsync(string maNhomKinhDoanh)
        {
            return await _nhomKinhDoanhRepositoryServices.FindByMaNhomKinhDoanh(maNhomKinhDoanh);

        }

        public async Task<IEnumerable<NhomKinhDoanh>> GetAllNhomKinhDoanh(int top, int skip, string? filter)
        {
            return await _nhomKinhDoanhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(NhomKinhDoanh nhomKinhDoanh)
        {
            await _nhomKinhDoanhRepositoryServices.AddAsync(nhomKinhDoanh);
        }

        public async Task<NhomKinhDoanh> DeleteAsync(string maNhomKinhDoanh)
        {
            NhomKinhDoanh nhomKinhDoanh = await GetNhomKinhDoanhAsync(maNhomKinhDoanh);
            if (nhomKinhDoanh != null)
            {
                await _nhomKinhDoanhRepositoryServices.DeleteAsync(nhomKinhDoanh);
            }
            return nhomKinhDoanh;
        }

        public async Task<PostDto> AddorUpdateNhomKinhDoanh(List<NhomKinhDoanhRequest> nhomKinhDoanhRequests)
        {
            List<NhomKinhDoanh> dangBaoChes = _mapper.Map<List<NhomKinhDoanh>>(nhomKinhDoanhRequests);
            return await _nhomKinhDoanhRepositoryServices.AddorUpdateNhomKinhDoanh(dangBaoChes);
        }

    }
}
