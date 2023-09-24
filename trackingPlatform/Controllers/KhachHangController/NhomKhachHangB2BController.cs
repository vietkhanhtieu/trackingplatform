using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class NhomKhachHangB2BController : Controller
    {
        private readonly NhomKhachHangB2BServices _nhomKhachHangB2BServices;
        public NhomKhachHangB2BController(NhomKhachHangB2BServices nhomKhachHangB2BServices)
        {
            _nhomKhachHangB2BServices = nhomKhachHangB2BServices;
        }
        /// <summary>
        /// Get all Nhóm khách hàng B2b
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomKhachHangB2b>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _nhomKhachHangB2BServices.GetAllNhomKhachHangB2B(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Nhóm khách hàng B2b theo maNhom
        /// </summary>
        [HttpGet("{maNhom}")]
        public async Task<ActionResult<NhomKhachHangB2b>> Get(string maNhom)
        {
            try
            {
                NhomKhachHangB2b nhomKhachHangB2B = await _nhomKhachHangB2BServices.GetNhomKhachHangB2B(maNhom);
                if (nhomKhachHangB2B == null)
                {
                    return NotFound();
                }
                return Ok(nhomKhachHangB2B);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Nhóm khách hàng B2b 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NhomKhachHangB2BRequest> nhomKhachHangB2BRequests)
        {
            try
            {
                return Ok(await _nhomKhachHangB2BServices.AddorUpdateNhomKhachHangB2b(nhomKhachHangB2BRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Nhóm khách hàng B2b theo maNhom
        /// </summary>

        [HttpDelete("{maNhom}")]
        public async Task<ActionResult> Delete(string maNhom)
        {
            try
            {
                NhomKhachHangB2b nhomKhachHangB2B = await _nhomKhachHangB2BServices.DeleteAsync(maNhom);
                if (nhomKhachHangB2B == null)
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
