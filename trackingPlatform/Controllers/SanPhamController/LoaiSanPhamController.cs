using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiSanPhamController : Controller
    {
        private readonly LoaiSpServices _loaiSpServices;

        public LoaiSanPhamController(LoaiSpServices loaiSpServices)
        {
            _loaiSpServices = loaiSpServices;
        }

        /// <summary>
        /// Get Loại sản phẩm by maLoaiSanPham
        /// </summary>

        [HttpGet("{maLoaiSanPham}")]
        public async Task<ActionResult<LoaiSp>> Get(string maLoaiSanPham)
        {
            try
            {
                LoaiSp loaiSp = await _loaiSpServices.GetLoaisp(maLoaiSanPham);
                if (loaiSp == null)
                {
                    return NotFound();
                }
                return Ok(loaiSp);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Loại sản phẩm 
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiSpServices.GetAllGetLoaisp(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Loại sản phẩm
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiSpRequest> loaiSpRequest)
        {
            try
            {
                return Ok(await _loaiSpServices.AddorUpdateLoaiSp(loaiSpRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Loại sản phẩm by maLoaiSanPham
        /// </summary>
        [HttpDelete("{maLoaiSanPham}")]
        public async Task<ActionResult> Delete(string maLoaiSanPham)
        {
            try
            {
                LoaiSp loaiSp = await _loaiSpServices.DeleteAsync(maLoaiSanPham);
                if (loaiSp == null)
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
