﻿using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;
<<<<<<<< HEAD:trackingPlatform/Services/SanPhamServices/BussinessServices/SanPhamServices/DangBaoCheService.cs
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
========
>>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912:trackingPlatform/Services/BussinessServices/SanPhamServices/DangBaoCheService.cs

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class DangBaoCheService
    {
        public readonly DangBaoCheRepositoryServices _dangBaoCheRepositoryServices;
        private readonly IMapper _mapper;


        public DangBaoCheService(DangBaoCheRepositoryServices dangBaoCheRepositoryServices, IMapper mapper)
        {
            _dangBaoCheRepositoryServices = dangBaoCheRepositoryServices;
            _mapper = mapper;
        }

        public async Task<DangBaoChe> FindByNameAsync(string dangBaoChe1)
        {
            return await _dangBaoCheRepositoryServices.FindByTenDangBaoChe(dangBaoChe1);
        }

        public async Task<DangBaoChe> GetDangBaoChe(string maDangBaoChe)
        {
            return await _dangBaoCheRepositoryServices.FindByMaDangBaoChe(maDangBaoChe);

        }

        public async Task<IEnumerable<DangBaoChe>> GetAllDangBaoChe(int top, int skip, string? filter)
        {
            return await _dangBaoCheRepositoryServices.FindAllAsync(top, skip, filter);
        }

        public async Task AddAsync(DangBaoChe dangBaoChe)
        {
            await _dangBaoCheRepositoryServices.AddAsync(dangBaoChe);
        }

        public async Task<DangBaoChe> DeleteAsync(string maDangBaoChe)
        {
            DangBaoChe dangBaoChe = await GetDangBaoChe(maDangBaoChe);
            if (dangBaoChe != null)
            {
                await _dangBaoCheRepositoryServices.DeleteAsync(dangBaoChe);
            }
            return dangBaoChe;
        }

        public async Task<PostDto> AddorUpdateDangBaoChe(List<DangBaoCheRequest> dangBaoCheRequests)
        {
            List<DangBaoChe> dangBaoChes = _mapper.Map<List<DangBaoChe>>(dangBaoCheRequests);
            return await _dangBaoCheRepositoryServices.AddorUpdateDangBaoChes(dangBaoChes);
        }
    }
}
