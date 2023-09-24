using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiSanPhamNoiBoController : Controller
    {
        private readonly LoaiSpNoiBoServices _loaiSpNoiBoServices;

        public LoaiSanPhamNoiBoController(LoaiSpNoiBoServices loaiSpNoiBoServices)
        {
            _loaiSpNoiBoServices = loaiSpNoiBoServices;
        }

        /// <summary>
        /// Get Loại sản phẩm nội bộ by maLoaiSanPhamNoiBo
        /// </summary>

        [HttpGet("{maLoaiSanPhamNoiBo}")]
        public async Task<ActionResult<LoaiSpNoiBo>> Get(string maLoaiSanPhamNoiBo)
        {
            try
            {
                LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoServices.GetLoaiSpNoiBo(maLoaiSanPhamNoiBo);
                if (loaiSpNoiBo == null)
                {
                    return NotFound();
                }
                return Ok(loaiSpNoiBo);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>by maLoaiSanPhamNoiBo
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSpNoiBo>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiSpNoiBoServices.GetAllLoaiSpNoiBo(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Loại sản phẩm nội bộ
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiSanPhamNoiBoRequest> loaiSanPhamNoiBoRequests)
        {
            try
            {
                return Ok(await _loaiSpNoiBoServices.AddorUpdateLoaiSpNoiBo(loaiSanPhamNoiBoRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Loại sản phẩm nội bộ by maLoaiSanPhamNoiBo
        /// </summary>
        [HttpDelete("{maLoaiSanPhamNoiBo}")]
        public async Task<ActionResult> Delete(string maLoaiSanPhamNoiBo)
        {
            try
            {
                LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoServices.DeleteAsync(maLoaiSanPhamNoiBo);
                if (loaiSpNoiBo == null)
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
