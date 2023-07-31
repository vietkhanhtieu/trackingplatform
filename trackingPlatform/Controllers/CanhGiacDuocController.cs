using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanhGiacDuocController : Controller
    {
        private readonly CanhGiacDuocServices _canhGiacDuocServices;

        public CanhGiacDuocController(CanhGiacDuocServices canhGiacDuocServices)
        {
            _canhGiacDuocServices = canhGiacDuocServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanhGiacDuoc>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _canhGiacDuocServices.GetAllCanhGiacDuoc(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<CanhGiacDuocRequest> dangBaoCheRequests)
        {
            try
            {
                return Ok(await _canhGiacDuocServices.AddorUpdateCanhGiacDuoc(dangBaoCheRequests));
            }
            catch
            {
                return Problem();
            }
        }
    }
}
