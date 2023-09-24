using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;
=======
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhomKinhDoanhController : Controller
    {
        private readonly NhomKinhDoanhServices _nhomKinhDoanhServices;
        public NhomKinhDoanhController(NhomKinhDoanhServices nhomKinhDoanhServices)
        {
            _nhomKinhDoanhServices = nhomKinhDoanhServices;
        }

        /// <summary>
        /// Get Nhóm kinh doanh by maNhomKinhDoanh
        /// </summary>

        [HttpGet("{maNhomKinhDoanh}")]
        public async Task<ActionResult<NhomKinhDoanh>> Get(string maNhomKinhDoanh)
        {
            try
            {
                NhomKinhDoanh nhomKinhDoanh = await _nhomKinhDoanhServices.GetNhomKinhDoanhAsync(maNhomKinhDoanh);
                if (nhomKinhDoanh == null)
                {
                    return NotFound();
                }
                return Ok(nhomKinhDoanh);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Nhóm kinh doanh 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomKinhDoanh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _nhomKinhDoanhServices.GetAllNhomKinhDoanh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Nhóm kinh doanh 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NhomKinhDoanhRequest> nhomKinhDoanhRequests)
        {
            try
            {
                return Ok(await _nhomKinhDoanhServices.AddorUpdateNhomKinhDoanh(nhomKinhDoanhRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Nhóm kinh doanh by maNhomKinhDoanh
        /// </summary>
        [HttpDelete("{maNhomKinhDoanh}")]
        public async Task<ActionResult> Delete(string maNhomKinhDoanh)
        {
            try
            {
                NhomKinhDoanh nhomKinhDoanh = await _nhomKinhDoanhServices.DeleteAsync(maNhomKinhDoanh);
                if (nhomKinhDoanh == null)
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
