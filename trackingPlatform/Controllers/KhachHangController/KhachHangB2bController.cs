
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangB2bController : Controller
    {
        private readonly KhachHangB2BServices _KhachHangB2BServices;

        public KhachHangB2bController(KhachHangB2BServices KhachHangB2BServices)
        {
            _KhachHangB2BServices = KhachHangB2BServices;
        }
        /// <summary>
        /// Lấy KhachHang theo maKhachHangB2b
        /// </summary>

        [HttpGet("{maKhachHangB2b}")]
        public async Task<ActionResult<KhachHangB2b>> Get(string maKhachHangB2b)
        {
            try
            {
                KhachHangB2b KhachHangB2b = await _KhachHangB2BServices.GetKhachHangB2B(maKhachHangB2b);
                if (KhachHangB2b == null)
                {
                    return NotFound();
                }
                return Ok(KhachHangB2b);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy tất cả các Khách hàng B2b
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHangB2b>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _KhachHangB2BServices.GetAllKhachHangB2b(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update KhachHangB2b
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<KhachHangB2bRequest> khachHangB2BRequests)
        {
            //try
            //{
            //    return Ok(await _KhachHangB2BServices.AddOrUpdateSanPhams(sanPhamRequests));
            //}
            //catch
            //{
            //    return Problem();
            //}
            return Ok(await _KhachHangB2BServices.AddorUpdateKhachHangB2b(khachHangB2BRequests));
        }
        /// <summary>
        /// Delete KhachHang theo maKhachHangB2b
        /// </summary>
        [HttpDelete("{maKhachHangB2b}")]
        public async Task<ActionResult> Delete(string maKhachHangB2b)
        {
            try
            {
                KhachHangB2b KhachHangB2b = await _KhachHangB2BServices.DeleteAsync(maKhachHangB2b);
                if (KhachHangB2b == null)
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
