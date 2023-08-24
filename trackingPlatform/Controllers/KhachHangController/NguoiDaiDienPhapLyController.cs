using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDaiDienPhapLyController : Controller
    {
        private readonly NguoiDaiDienPhapLyServices _nguoiDaiDienPhapLyServices;
        public NguoiDaiDienPhapLyController(NguoiDaiDienPhapLyServices nguoiDaiDienPhapLyServices)
        {
            _nguoiDaiDienPhapLyServices = nguoiDaiDienPhapLyServices;
        }

        /// <summary>
        /// Get all Người đại diện pháp lý 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDaiDienPhapLy>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _nguoiDaiDienPhapLyServices.GetAllNguoiDaiDienPhapLy(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Người đại diện pháp lý theo maNguoiDaiDien
        /// </summary>
        [HttpGet("{maNguoiDaiDien}")]
        public async Task<ActionResult<NguoiDaiDienPhapLy>> Get(string maNguoiDaiDien)
        {
            try
            {
                NguoiDaiDienPhapLy NguoiDaiDien = await _nguoiDaiDienPhapLyServices.GetNguoiDaiDienPhapLy(maNguoiDaiDien);
                if (NguoiDaiDien == null)
                {
                    return NotFound();
                }
                return Ok(NguoiDaiDien);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Người đại diện pháp lý 
        /// </summary>
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NguoiDaiDienPhapLyRequest> nguoiDaiDienPhapLies)
        {
            try
            {
                return Ok(await _nguoiDaiDienPhapLyServices.AddorUpdateNguoiDaiDienPhapLy(nguoiDaiDienPhapLies));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Người đại diện pháp lý theo maNguoiDaiDien
        /// </summary>

        [HttpDelete("{maNguoiDaiDien}")]
        public async Task<ActionResult> Delete(string maNguoiDaiDien)
        {
            try
            {
                NguoiDaiDienPhapLy nguoiDaiDien = await _nguoiDaiDienPhapLyServices.DeleteAsync(maNguoiDaiDien);
                if (nguoiDaiDien == null)
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
