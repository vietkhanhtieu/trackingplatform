using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers

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
