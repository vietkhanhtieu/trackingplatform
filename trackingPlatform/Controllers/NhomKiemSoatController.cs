using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhomKiemSoatController : Controller
    {
        private readonly NhomKiemSoatServices _nhomKiemSoatServices;

        public NhomKiemSoatController(NhomKiemSoatServices nhomKiemSoatServices)
        {
            _nhomKiemSoatServices = nhomKiemSoatServices;
        }

        [HttpGet("{maNhomKiemSoat}")]
        public async Task<ActionResult<NhomKiemSoat>> Get(string maNhomKiemSoat)
        {
            try
            {
                NhomKiemSoat nhomKiemSoat = await _nhomKiemSoatServices.GetNhomKiemSoat(maNhomKiemSoat);
                if (nhomKiemSoat == null)
                {
                    return NotFound();
                }
                return Ok(nhomKiemSoat);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomKiemSoat>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _nhomKiemSoatServices.GetAllNhomKiemSoat(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NhomKiemSoatRequest> nhomKiemSoatRequests)
        {
            try
            {
                return Ok(await _nhomKiemSoatServices.AddorUpdateNhomKiemSoat(nhomKiemSoatRequests));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{maNhomKiemSoat}")]
        public async Task<ActionResult> Delete(string maNhomKiemSoat)
        {
            try
            {
                NhomKiemSoat nhomKiemSoat = await _nhomKiemSoatServices.DeleteAsync(maNhomKiemSoat);
                if (nhomKiemSoat == null)
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
