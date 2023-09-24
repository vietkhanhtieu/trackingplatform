using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.SanPhamRequest;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.BussinessServices.SanPhamServices;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class HubController : Controller
    {
        private readonly HubServices _hubServices;

        public HubController(HubServices hubService)
        {
            _hubServices = hubService;
        }

        /// <summary>
        /// Get Hub by maHub
        /// </summary>

        [HttpGet("{maHub}")]
        public async Task<ActionResult<Hub>> Get(string maHub)
        {
            try
            {
                Hub hub = await _hubServices.GetHub(maHub);
                if (hub == null)
                {
                    return NotFound();
                }
                return Ok(hub);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Hub 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hub>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _hubServices.GetAllHub(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Hub 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<HubRequest> HubRequest)
        {
            try
            {
                return Ok(await _hubServices.AddorUpdateHub(HubRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Hub by maHub
        /// </summary>
        [HttpDelete("{maHub}")]
        public async Task<ActionResult> Delete(string maHub)
        {
            try
            {
                Hub hub = await _hubServices.DeleteAsync(maHub);
                if (hub == null)
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
