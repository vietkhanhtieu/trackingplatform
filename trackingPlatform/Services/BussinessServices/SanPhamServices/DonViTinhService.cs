﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/DonViTinhService.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/DonViTinhService.cs

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class DonViTinhService
    {
        private readonly DonViTinhRepositoryServices _donViTinhRepositoryServices;
        private readonly IMapper _mapper;

        public DonViTinhService(DonViTinhRepositoryServices donViTinhRepositoryServices, IMapper mapper)
        {
            _donViTinhRepositoryServices = donViTinhRepositoryServices;
            _mapper = mapper;
        }
        public async Task<DonViTinh> FindByNameAsync(string doViTinhCoSo)
        {
            return await _donViTinhRepositoryServices.FindByDonViTinhCoSo(doViTinhCoSo);
        }

        public async Task<DonViTinh> GetDonViTinh(string maDvt)
        {
            return await _donViTinhRepositoryServices.FindByMaDonViTinh(maDvt);

        }

        public async Task<IEnumerable<DonViTinh>> GetAllDonViTinh(int top, int skip, string? filter)
        {
            return await _donViTinhRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(DonViTinh donViTinh)
        {
            await _donViTinhRepositoryServices.AddAsync(donViTinh);
        }

        public async Task<DonViTinh> DeleteAsync(string maDvt)
        {
            DonViTinh donViTinh = await GetDonViTinh(maDvt);
            if (donViTinh != null)
            {
                await _donViTinhRepositoryServices.DeleteAsync(donViTinh);
            }
            return donViTinh;
        }

        public async Task<PostDto> AddorUpdateDonViTinh(List<DonViTinhRequest> donViTinhRequests)
        {
            List<DonViTinh> donViTinhs = _mapper.Map<List<DonViTinh>>(donViTinhRequests);
            return await _donViTinhRepositoryServices.AddorUpdateDonViTinhs(donViTinhs);
        }
    }
}
