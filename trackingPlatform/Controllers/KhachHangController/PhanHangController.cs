using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhanHangController : Controller
    {
        private readonly PhanHangServices _phanHangServices;
        public PhanHangController(PhanHangServices phanHangServices)
        {
            _phanHangServices = phanHangServices;
        }
        /// <summary>
        /// Get all Phân hạng
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanHang>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _phanHangServices.GetAllPhanHang(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Phân hạng theo maPhanHang
        /// </summary>
        [HttpGet("{maPhanHang}")]
        public async Task<ActionResult<PhanHang>> Get(string maPhanHang)
        {
            try
            {
                PhanHang phanHang = await _phanHangServices.GetPhanHang(maPhanHang);
                if (phanHang == null)
                {
                    return NotFound();
                }
                return Ok(phanHang);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Phân hạng 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<PhanHangRequest> phanHangRequests)
        {
            try
            {
                return Ok(await _phanHangServices.AddorUpdatePhanHang(phanHangRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete Phân hạng theo maPhanHang
        /// </summary>
        [HttpDelete("{maKhachHang}")]
        public async Task<ActionResult> Delete(string maPhanHang)
        {
            try
            {
                PhanHang phanHang = await _phanHangServices.DeleteAsync(maPhanHang);
                if (phanHang == null)
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
