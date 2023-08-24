
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class NgayCotMocController : Controller
    {
        private readonly NgayCotMocServices _ngayCotMocServices;
        public NgayCotMocController(NgayCotMocServices ngayCotMocServices)
        {
            _ngayCotMocServices = ngayCotMocServices;
        }
        /// <summary>
        /// Get all Ngày cột mốc theo maCotMoc
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NgayCotMoc>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _ngayCotMocServices.GetAllNgayCotMoc(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        ///Get Ngày cột mốc theo maCotMoc
        /// </summary>
        [HttpGet("{maCotMoc}")]
        public async Task<ActionResult<NgayCotMoc>> Get(string maCotMoc)
        {
            try
            {
                NgayCotMoc ngayCotMoc = await _ngayCotMocServices.GetMaCotMoc(maCotMoc);
                if (ngayCotMoc == null)
                {
                    return NotFound();
                }
                return Ok(ngayCotMoc);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Ngày cột mốc
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<NgayCotMocRequest> ngayCotMocRequests)
        {
            try
            {
                return Ok(await _ngayCotMocServices.AddorUpdateNgayCotMoc(ngayCotMocRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete Ngày cột mốc theo maCotMoc
        /// </summary>
        [HttpDelete("{maCotMoc}")]
        public async Task<ActionResult> Delete(string maCotMoc)
        {
            try
            {
                NgayCotMoc ngayCotMoc = await _ngayCotMocServices.DeleteAsync(maCotMoc);
                if (ngayCotMoc == null)
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
