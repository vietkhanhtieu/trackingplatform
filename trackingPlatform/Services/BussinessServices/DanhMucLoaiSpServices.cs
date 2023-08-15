using trackingPlatform.Models;
using trackingPlatform.Service.RepositoryServices;

namespace trackingPlatform.Service.BussinessServices
{
    public class DanhMucLoaiSpServices
    {
        private readonly DanhMucLoaiSanPhamRepositoryServices _danhMucLoaiSanPhamRepositoryServices;

        public DanhMucLoaiSpServices(DanhMucLoaiSanPhamRepositoryServices danhMucLoaiSanPhamRepositoryServices)
        {
            _danhMucLoaiSanPhamRepositoryServices = danhMucLoaiSanPhamRepositoryServices;
        }

        public async Task<DanhMucLoaiSp> FindByMaDanhMucLoaiSP(string maDanhMucLoaiSanPham)
        {
            return await _danhMucLoaiSanPhamRepositoryServices.FindByMaDanhMucLoaiSp(maDanhMucLoaiSanPham);
        }

        public async Task AddAsync(DanhMucLoaiSp danhMucLoaiSp)
        {
            await _danhMucLoaiSanPhamRepositoryServices.AddAsync(danhMucLoaiSp);
        }
    }
}
