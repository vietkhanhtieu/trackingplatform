using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CbnvKhachHangController : Controller
    {
        private readonly CbnvKhachHangServices _cbnvKhachHangServices;
        public CbnvKhachHangController(CbnvKhachHangServices cbnvKhachHangServices)
        {
            _cbnvKhachHangServices = cbnvKhachHangServices;
        }

        /// <summary>
        /// Get all cán bộ nhân viên khách hàng
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CbnvKhachHang>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _cbnvKhachHangServices.GetAllCbnvKhachHang(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get cán bộ nhân viên khách hàng theo maCbnvKhachHang
        /// </summary>
        [HttpGet("{maCbnvKhachHang}")]
        public async Task<ActionResult<CbnvKhachHang>> Get(string maCbnvKhachHang)
        {
            CbnvKhachHang CbnvKhachHang = await _cbnvKhachHangServices.GetCbnvKhachHang(maCbnvKhachHang);
            if (CbnvKhachHang == null)
            {
                return NotFound();
            }
            return Ok(CbnvKhachHang);

        }
        /// <summary>
        /// Post cán bộ nhân viên khách hàng 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<CbnvKhachHangRequest> cbnvKhachHangRequests)
        {
            try
            {
                return Ok(await _cbnvKhachHangServices.AddorUpdateCbnvKhachHang(cbnvKhachHangRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete cán bộ nhân viên khách hàng theo maCbnvKhachHang
        /// </summary>

        [HttpDelete("{maCbnvKhachHang}")]
        public async Task<ActionResult> Delete(string maCbnvKhachHang)
        {
            try
            {
                CbnvKhachHang CbnvKhachHang = await _cbnvKhachHangServices.DeleteAsync(maCbnvKhachHang);
                if (CbnvKhachHang == null)
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
