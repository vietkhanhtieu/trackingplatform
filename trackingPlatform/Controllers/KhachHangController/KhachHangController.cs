
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private readonly KhachHangServices _khachHangServices;

        public KhachHangController(KhachHangServices khachHangServices)
        {
            _khachHangServices = khachHangServices;
        }
        /// <summary>
        /// Lấy KhachHang theo maKhachHang
        /// </summary>
        [HttpGet("{maKhachHang}")]
        public async Task<ActionResult<KhachHang>> Get(string maKhachHang)
        {
            try
            {
                KhachHang khachHang = await _khachHangServices.GetKhachHang(maKhachHang);
                if (khachHang == null)
                {
                    return NotFound();
                }
                return Ok(khachHang);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy tất cả các khách hàng 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _khachHangServices.GetAllKhachHang(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update KhachHang 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<KhachHangRequest> KhachHangRequests)
        {
            //try
            //{
            //    return Ok(await _khachHangServices.AddOrUpdateSanPhams(sanPhamRequests));
            //}
            //catch
            //{
            //    return Problem();
            //}
            return Ok(await _khachHangServices.AddorUpdateKhachHang(KhachHangRequests));
        }
        /// <summary>
        /// Delete KhachHang theo maKhachHang
        /// </summary>
        [HttpDelete("{maKhachHang}")]
        public async Task<ActionResult> Delete(string maKhachHang)
        {
            try
            {
                KhachHang khachHang = await _khachHangServices.DeleteAsync(maKhachHang);
                if (khachHang == null)
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
