using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.SanPhamRequest;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TonKhoTheoHubController : Controller
    {
        private readonly TonKhoTheoHubServices _tonKhoTheoTheohubServices;

        public TonKhoTheoHubController(TonKhoTheoHubServices TonkhoTheohubService)
        {
            _tonKhoTheoTheohubServices = TonkhoTheohubService;
        }

        /// <summary>
        /// Get TonkhoTheohub by maTonkhoTheohub
        /// </summary>

        [HttpGet("{maHub}/{maSanPham}")]
        public async Task<ActionResult<TonkhoTheohub>> Get(string maHub, string maSanPham)
        {
            try
            {
                TonkhoTheohub TonkhoTheohub = await _tonKhoTheoTheohubServices.GetTonkhoTheohub(maHub, maSanPham);
                if (TonkhoTheohub == null)
                {
                    return NotFound();
                }
                return Ok(TonkhoTheohub);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all TonkhoTheohub 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TonkhoTheohub>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _tonKhoTheoTheohubServices.GetAllTonkhoTheohub(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or TonkhoTheohub 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<TonKhoTheoHubRequest> TonkhoTheohubRequest)
        {
            try
            {
                return Ok(await _tonKhoTheoTheohubServices.AddorUpdateTonkhoTheohub(TonkhoTheohubRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete TonkhoTheohub by maTonkhoTheohub
        /// </summary>
        [HttpDelete("{maHub}/{maSanPham}")]
        public async Task<ActionResult> Delete(string maHub, string maSanPham)
        {
            try
            {
                TonkhoTheohub TonkhoTheohub = await _tonKhoTheoTheohubServices.DeleteAsync(maHub, maSanPham);
                if (TonkhoTheohub == null)
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
