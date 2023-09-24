using AutoMapper;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Service.ExternalServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.RepositoryServices.SanPhamRepositoryServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Services.BussinessServices.SanPhamServices
{
    public class LoaiSpServices
    {
        private readonly LoaiSpRepositoryServices _loaiSpRepositoryServices;
        private readonly DanhMucLoaiSpServices _danhMucLoaiSpServices;
        private readonly IMapper _mapper;


        public LoaiSpServices(LoaiSpRepositoryServices loaiSpRepositoryServices, IMapper mapper, DanhMucLoaiSpServices danhMucLoaiSpServices)
        {
            _loaiSpRepositoryServices = loaiSpRepositoryServices;
            _danhMucLoaiSpServices = danhMucLoaiSpServices;
            _mapper = mapper;

        }

        public async Task<LoaiSp> FindByNameAsync(string tenLoaiSp)
        {
            return await _loaiSpRepositoryServices.FindByTenLoaiSp(tenLoaiSp);
        }

        public async Task<LoaiSp> GetLoaisp(string maLoaisp)
        {
            return await _loaiSpRepositoryServices.FindByMaLoaiSp(maLoaisp);

        }

        public async Task<IEnumerable<LoaiSp>> GetAllGetLoaisp(int top, int skip, string? filter)
        {
            return await _loaiSpRepositoryServices.FindAllAsync(top, skip, filter);
        }
        public async Task AddAsync(LoaiSp loaiSp)
        {
            await _loaiSpRepositoryServices.AddAsync(loaiSp);
        }
        public async Task<LoaiSp> DeleteAsync(string maLoaisp)
        {
            LoaiSp loaiSp = await GetLoaisp(maLoaisp);
            if (loaiSp != null)
            {
                await _loaiSpRepositoryServices.DeleteAsync(loaiSp);
            }
            return loaiSp;
        }
        public async Task<PostDto> AddorUpdateLoaiSp(List<LoaiSpRequest> loaiSpRequests)
        {
            List<LoaiSp> temp = await MapListLoaiSpRequestToListLoaiSp(loaiSpRequests);

            List<LoaiSp> loaiSps = _mapper.Map<List<LoaiSp>>(temp);
            return await _loaiSpRepositoryServices.AddorUpdateLoaiSp(loaiSps);
        }


        private async Task<DanhMucLoaiSp> MapDanhMucLoaiSpForLoaiSanPham(string maDanhMucLoaiSp)
        {
            DanhMucLoaiSp danhMucLoaiSp = await _danhMucLoaiSpServices.GetDanhMucLoaiSp(maDanhMucLoaiSp);
            if (danhMucLoaiSp == null)
            {
                danhMucLoaiSp = new DanhMucLoaiSp
                {
                    MaDanhMucLsp = maDanhMucLoaiSp,
                    TenDanhMucLsp = "",
                    DinhNghia = ""

                };
                await _danhMucLoaiSpServices.AddAsync(danhMucLoaiSp);
            }
            return danhMucLoaiSp;
        }

        public LoaiSp MapLoaiSpRequestToLoaiSanPham(LoaiSpRequest loaiSpRequest, DanhMucLoaiSp danhMucLoaiSp)
        {
            LoaiSp loaiSp = _mapper.Map<LoaiSp>(loaiSpRequest);
            loaiSp.MaDanhMucLspNavigation = danhMucLoaiSp;
            return loaiSp;
        }

        public async Task<List<LoaiSp>> MapListLoaiSpRequestToListLoaiSp(List<LoaiSpRequest> loaiSpRequests)
        {
            List<LoaiSp> loaiSps = new List<LoaiSp>();
            foreach (LoaiSpRequest loaiSpRequest in loaiSpRequests)
            {
                DanhMucLoaiSp danhMucLoaiSp = null;
                if (loaiSpRequest.MaDanhMucLsp != null)
                {
                    danhMucLoaiSp = await MapDanhMucLoaiSpForLoaiSanPham(loaiSpRequest.MaDanhMucLsp);
                }
                LoaiSp temp = MapLoaiSpRequestToLoaiSanPham(loaiSpRequest, danhMucLoaiSp!);

                loaiSps.Add(temp);
            }
            return loaiSps;
        }



    }


}
