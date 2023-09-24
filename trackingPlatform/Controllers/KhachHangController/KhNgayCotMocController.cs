
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhNgayCotMocController : Controller
    {
        private readonly KhNgayCotMocServices _khNgayCotMocServices;
        public KhNgayCotMocController(KhNgayCotMocServices khNgayCotMocServices)
        {
            _khNgayCotMocServices = khNgayCotMocServices;
        }
        /// <summary>
        /// Lấy tất cả các khách hàng - ngày cột mốc
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhNgayCotMoc>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _khNgayCotMocServices.GetAllKhNgayCotMoc(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy khách hàng - Ngày cột mốc theo maKhachHangB2b và maCotMoc
        /// </summary>

        [HttpGet("{maKhachHangB2b}/maCotMoc")]
        public async Task<ActionResult<KhNgayCotMoc>> Get(string maKhachHangB2b, [FromQuery] string maCotMoc)
        {
            try
            {
                KhNgayCotMoc KhNgayCotMoc = await _khNgayCotMocServices.GetKhNgayCotMoc(maKhachHangB2b, maCotMoc);
                if (KhNgayCotMoc == null)
                {
                    return NotFound();
                }
                return Ok(KhNgayCotMoc);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete khách hàng - Ngày cột mốc theo maKhachHangB2b và maCotMoc
        /// </summary>
        [HttpDelete("{maKhachHangB2b}/maCotMoc")]
        public async Task<ActionResult> Delete(string maKhachHangB2b, [FromQuery] string maCotMoc)
        {
            try
            {
                KhNgayCotMoc KhNgayCotMoc = await _khNgayCotMocServices.DeleteAsync(maKhachHangB2b, maCotMoc);
                if (KhNgayCotMoc == null)
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
        /// Create khách hàng - Ngày cột mốc 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<KhNgayCotMocRequest> KhNgayCotMocRequests)
        {

            return Ok(await _khNgayCotMocServices.AddListKhNgayCotMocAsync(KhNgayCotMocRequests));
        }
    }
}
