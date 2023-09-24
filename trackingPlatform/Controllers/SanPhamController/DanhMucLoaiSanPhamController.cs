using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class DanhMucLoaiSanPhamController : Controller
    {
        private readonly DanhMucLoaiSpServices _danhMucLoaiSpServices;

        public DanhMucLoaiSanPhamController(DanhMucLoaiSpServices DanhMucLoaiSpServices)
        {
            _danhMucLoaiSpServices = DanhMucLoaiSpServices;
        }
        /// <summary>
        /// Get Danh mục loại sản phẩm by maDanhMucLoaiSp
        /// </summary>

        [HttpGet("{maDanhMucLoaiSp}")]
        public async Task<ActionResult<DanhMucLoaiSp>> Get(string maDanhMucLoaiSp)
        {
            try
            {
                DanhMucLoaiSp DanhMucLoaiSp = await _danhMucLoaiSpServices.GetDanhMucLoaiSp(maDanhMucLoaiSp);
                if (DanhMucLoaiSp == null)
                {
                    return NotFound();
                }
                return Ok(DanhMucLoaiSp);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all  Danh mục loại sản phẩm 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMucLoaiSp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _danhMucLoaiSpServices.GetAllDanhMucLoaiSp(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update  Danh mục loại sản phẩm 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DanhMucLoaiSpRequest> DanhMucLoaiSpRequest)
        {
            try
            {
                return Ok(await _danhMucLoaiSpServices.AddorUpdateDanhMucLoaiSp(DanhMucLoaiSpRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete  Danh mục loại sản phẩm by maDanhMucLoaiSp
        /// </summary>
        [HttpDelete("{maDanhMucLoaiSp}")]
        public async Task<ActionResult> Delete(string maDanhMucLoaiSp)
        {
            try
            {
                DanhMucLoaiSp DanhMucLoaiSp = await _danhMucLoaiSpServices.DeleteAsync(maDanhMucLoaiSp);
                if (DanhMucLoaiSp == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
