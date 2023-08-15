using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.Request.CreateUpdateSanPham;

namespace trackingPlatform.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamKinhDoanhController : Controller
    {
        private readonly SanPhamKinhDoanhServices _sanPhamKinhDoanhServices;

        public SanPhamKinhDoanhController(SanPhamKinhDoanhServices sanPhamKinhDoanhServices)
        {
            _sanPhamKinhDoanhServices = sanPhamKinhDoanhServices;
        }

        /// <summary>
        /// Get Sản phẩm kinh doanh by maSanPham
        /// </summary>

        [HttpGet("{maSanPham}")]
        public async Task<ActionResult<SanPhamKinhDoanh>> Get(string maSanPham)
        {
            try
            {
                SanPhamKinhDoanh sanPhamKinhDoanh = await _sanPhamKinhDoanhServices.GetSanPhamKinhDoanh(maSanPham);
                if (sanPhamKinhDoanh == null)
                {
                    return NotFound();
                }
                return Ok(sanPhamKinhDoanh);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Sản phẩm kinh doanh
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamKinhDoanh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _sanPhamKinhDoanhServices.GetAllSanPham(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Sản phẩm kinh doanh 
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<SanPhamRequest> sanPhamRequests)
        {
            //try
            //{
            //    return Ok(await _sanPhamKinhDoanhServices.AddOrUpdateSanPhams(sanPhamRequests));
            //}
            //catch
            //{
            //    return Problem();
            //}
            return Ok(await _sanPhamKinhDoanhServices.AddOrUpdateSanPhams(sanPhamRequests));
        }
        /// <summary>
        /// Delete Sản phẩm kinh doanh by maSanPham
        /// </summary>
        [HttpDelete("{maSanPham}")]
        public async Task<ActionResult> Delete(string maSanPham)
        {
            try
            {
                SanPhamKinhDoanh sanPhamKinhDoanh = await _sanPhamKinhDoanhServices.DeleteAsync(maSanPham);
                if (sanPhamKinhDoanh == null)
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
