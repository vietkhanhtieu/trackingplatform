using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;
=======
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdateSanPham;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Controllers.SanPhamController
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
            try
            {
                return Ok(await _sanPhamKinhDoanhServices.AddOrUpdateSanPhams(sanPhamRequests));
            }
            catch
            {
                return Problem();
            }
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

        /// <summary>
        /// Create or Update Sản phẩm kinh doanh EcDb
        /// </summary>

        //[HttpPost("sync-ec")]
        //public async Task<IActionResult> PostEc([FromBody] List<SanPhamRequest> sanPhamRequests)
        //{
        //    try
        //    {
        //        return Ok(await _sanPhamKinhDoanhServices.AddOrUpdateSanPhamsSyncEc(sanPhamRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}
    }
}
