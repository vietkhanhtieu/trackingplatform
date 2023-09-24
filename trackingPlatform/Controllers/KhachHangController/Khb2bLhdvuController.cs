using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class Khb2bLhdvuController : Controller
    {
        private readonly Khb2bLhdvServices _khb2bLhdvServices;
        public Khb2bLhdvuController(Khb2bLhdvServices khb2BLhdvServices)
        {
            _khb2bLhdvServices = khb2BLhdvServices;
        }
        /// <summary>
        /// Lấy tất cả các Khách hàng b2b liên hệ dịch vụ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khb2bLhdvu>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _khb2bLhdvServices.GetAllKhb2bLhdvu(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy Khách hàng b2b liên hệ dịch vụ theo maKhachHangB2b và maLhdvu
        /// </summary>
        [HttpGet("{maKhachHangB2b}/maLhdvu")]
        public async Task<ActionResult<Khb2bLhdvu>> Get( string maKhachHangB2b, [FromQuery] string maLhdvu)
        {
            try
            {
                Khb2bLhdvu khb2BLhdvu = await _khb2bLhdvServices.GetKhb2bLhdvu(maKhachHangB2b, maLhdvu);
                if (khb2BLhdvu == null)
                {
                    return NotFound();
                }
                return Ok(khb2BLhdvu);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Khách hàng b2b liên hệ dịch vụ theo maKhachHangB2b và maLhdvu
        /// </summary>
        [HttpDelete("{maKhachHangB2b}/maLhdvu")]
        public async Task<ActionResult> Delete(string maKhachHangB2b, [FromQuery] string maLhdvu)
        {
            try
            {
                Khb2bLhdvu khb2BLhdvu = await _khb2bLhdvServices.DeleteAsync(maKhachHangB2b, maLhdvu);
                if (khb2BLhdvu == null)
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
        /// Thêm mới Khách hàng b2b liên hệ dịch vụ 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Khb2bLhdvuRequest> khb2BLhdvuRequests)
        {
           
            return Ok(await _khb2bLhdvServices.AddListKhb2bLhdvuAsync(khb2BLhdvuRequests));
        }
    }
}
