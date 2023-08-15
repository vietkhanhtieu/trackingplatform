using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamGopController : Controller
    {
        private readonly SanPhamGopServices _sanPhamGopServices;

        public SanPhamGopController(SanPhamGopServices sanPhamGopServices)
        {
            _sanPhamGopServices = sanPhamGopServices;
        }
        /// <summary>
        /// Get Sản phẩm gộp by maGop
        /// </summary>
        [HttpGet("{maGop}")]
        public async Task<ActionResult<SanPhamGop>> Get(string maGop)
        {
            try
            {
                SanPhamGop sanPhamGop = await _sanPhamGopServices.GetSanPhamGop(maGop);
                if (sanPhamGop == null)
                {
                    return NotFound();
                }
                return Ok(sanPhamGop);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Sản phẩm gộp 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamGop>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _sanPhamGopServices.GetAllDangBaoChe(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Sản phẩm gộp 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<SanPhamGopRequest> sanPhamGopRequests)
        {
            try
            {
                return Ok(await _sanPhamGopServices.AddorUpdateSanPhamGops(sanPhamGopRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Sản phẩm gộp by maGop
        /// </summary>
        [HttpDelete("{maGop}")]
        public async Task<ActionResult> Delete(string maGop)
        {
            try
            {
                SanPhamGop sanPhamGop = await _sanPhamGopServices.DeleteAsync(maGop);
                if (sanPhamGop == null)
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
