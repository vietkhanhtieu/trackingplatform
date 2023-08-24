
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangB2cController : Controller
    {
        private readonly KhachHangB2CServices _khachHangB2CServices;
        public KhachHangB2cController(KhachHangB2CServices khachHangB2CServices)
        {
            _khachHangB2CServices = khachHangB2CServices;
        }
        /// <summary>
        /// Lấy tất cả các khách hàng B2c
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHangB2c>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _khachHangB2CServices.GetAllKhachHangB2c(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy KhachHangB2c theo maKhachHangB2b
        /// </summary>
        [HttpGet("{maKhachHang}")]
        public async Task<ActionResult<KhachHangB2c>> Get(string maKhachHang)
        {
            try
            {
                KhachHangB2c khachHangB2C = await _khachHangB2CServices.GetKhachHangB2c(maKhachHang);
                if (khachHangB2C == null)
                {
                    return NotFound();
                }
                return Ok(khachHangB2C);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update KhachHangB2c
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<KhachHangB2cRequest> khachHangB2CRequests)
        {
            try
            {
                return Ok(await _khachHangB2CServices.AddorUpdateKhachHangB2c(khachHangB2CRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete KhachHangB2c theo maKhachHangB2c
        /// </summary>
        [HttpDelete("{maKhachHangB2c}")]
        public async Task<ActionResult> Delete(string maKhachHangB2c)
        {
            try
            {
                KhachHangB2c khachHangB2C = await _khachHangB2CServices.DeleteAsync(maKhachHangB2c);
                if (khachHangB2C == null)
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
