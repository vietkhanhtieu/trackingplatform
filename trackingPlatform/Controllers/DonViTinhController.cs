using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DonViTinhController : Controller
    {
        private readonly DonViTinhService _donViTinhService;

        public DonViTinhController(DonViTinhService donViTinhService)
        {
            _donViTinhService = donViTinhService;
        }

        [HttpGet("{maDonViTinh}")]
        public async Task<ActionResult<DonViTinh>> Get(string maDonViTinh)
        {
            try
            {
                DonViTinh donViTinh = await _donViTinhService.GetDonViTinh(maDonViTinh);
                if (donViTinh == null)
                {
                    return NotFound();
                }
                return Ok(donViTinh);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViTinh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _donViTinhService.GetAllDonViTinh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DonViTinhRequest> donViTinhRequest)
        {
            try
            {
                return Ok(await _donViTinhService.AddorUpdateDonViTinh(donViTinhRequest));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{maDonViTinh}")]
        public async Task<ActionResult> Delete(string maDonViTinh)
        {
            try
            {
                DonViTinh donViTinh = await _donViTinhService.DeleteAsync(maDonViTinh);
                if (donViTinh == null)
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
