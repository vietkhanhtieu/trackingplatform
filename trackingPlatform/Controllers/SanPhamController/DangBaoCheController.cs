using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.BussinessServices.SanPhamServices;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController

{
    [ApiController]
    [Route("api/[controller]")]
    public class DangBaoCheController : Controller
    {

        private readonly DangBaoCheService _dangBaoCheService;

        public DangBaoCheController(DangBaoCheService dangBaoCheService)
        {
            _dangBaoCheService = dangBaoCheService;
        }

        /// <summary>
        /// Get Dạng bào chế by maDangBaoChe
        /// </summary>

        [HttpGet("{maDangBaoChe}")]
        public async Task<ActionResult<DangBaoChe>> Get(string maDangBaoChe)
        {
            try
            {
                DangBaoChe dangBaoChe = await _dangBaoCheService.GetDangBaoChe(maDangBaoChe);
                if (dangBaoChe == null)
                {
                    return NotFound();
                }
                return Ok(dangBaoChe);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Dạng bào chế 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DangBaoChe>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _dangBaoCheService.GetAllDangBaoChe(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Dạng bào chế 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DangBaoCheRequest> dangBaoCheRequests)
        {
            try
            {
                return Ok(await _dangBaoCheService.AddorUpdateDangBaoChe(dangBaoCheRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Dạng bào chế by maDangBaoChe
        /// </summary>
        [HttpDelete("{maDangBaoChe}")]
        public async Task<ActionResult> Delete(string maDangBaoChe)
        {
            try
            {
                DangBaoChe dangBaoChe = await _dangBaoCheService.DeleteAsync(maDangBaoChe);
                if (dangBaoChe == null)
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
