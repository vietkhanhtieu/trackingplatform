using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class DieuKienBaoQuanController : Controller
    {
        private readonly DieuKienBaoQuanServices _dieuKienBaoQuanServices;

        public DieuKienBaoQuanController(DieuKienBaoQuanServices dieuKienBaoQuanServices)
        {
            _dieuKienBaoQuanServices = dieuKienBaoQuanServices;
        }
        /// <summary>
        /// Get Điều kiện bảo quản by maDieuKienBaoQuan
        /// </summary>

        [HttpGet("{maDieuKienBaoQuan}")]
        public async Task<ActionResult<DieuKienBaoQuan>> Get(string maDieuKienBaoQuan)
        {
            try
            {
                DieuKienBaoQuan dieuKienBaoQuan = await _dieuKienBaoQuanServices.GetDieuKienBaoQuan(maDieuKienBaoQuan);
                if (dieuKienBaoQuan == null)
                {
                    return NotFound();
                }
                return Ok(dieuKienBaoQuan);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Điều kiện bảo quản 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DieuKienBaoQuan>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _dieuKienBaoQuanServices.GetAllDieuKienBaoQuan(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Điều kiện bảo quản 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DieuKienBaoQuanRequest> dieuKienBaoQuanRequest)
        {
            try
            {
                return Ok(await _dieuKienBaoQuanServices.AddorUpdateDieuKienBaoQuan(dieuKienBaoQuanRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Điều kiện bảo quản by maDieuKienBaoQuan
        /// </summary>
        [HttpDelete("{maDieuKienBaoQuan}")]
        public async Task<ActionResult> Delete(string maDieuKienBaoQuan)
        {
            try
            {
                DieuKienBaoQuan dieuKienBaoQuan = await _dieuKienBaoQuanServices.DeleteAsync(maDieuKienBaoQuan);
                if (dieuKienBaoQuan == null)
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
