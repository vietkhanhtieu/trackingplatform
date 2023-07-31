using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
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
