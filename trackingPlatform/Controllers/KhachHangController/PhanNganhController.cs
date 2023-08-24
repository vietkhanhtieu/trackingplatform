using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhanNganhController : Controller
    {
        private readonly PhanNganhServices _phanNganhServices;
        public PhanNganhController(PhanNganhServices phanNganhServices)
        {
            _phanNganhServices = phanNganhServices;
        }
        /// <summary>
        /// Get all Phân ngành
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanNganh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _phanNganhServices.GetAllPhanNganh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Phân ngành theo maPhanNganh
        /// </summary>
        [HttpGet("{maPhanNganh}")]
        public async Task<ActionResult<PhanNganh>> Get(string maPhanNganh)
        {
            try
            {
                PhanNganh phanNganh = await _phanNganhServices.GetPhanNganh(maPhanNganh);
                if (phanNganh == null)
                {
                    return NotFound();
                }
                return Ok(phanNganh);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Phân ngành 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<PhanNganhRequest> phanNganhRequests)
        {
            try
            {
                return Ok(await _phanNganhServices.AddorUpdatePhanNganh(phanNganhRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete Phân ngành theo maPhanNganh
        /// </summary>
        [HttpDelete("{maPhanNganh}")]
        public async Task<ActionResult> Delete(string maPhanNganh)
        {
            try
            {
                PhanNganh phanNganh = await _phanNganhServices.DeleteAsync(maPhanNganh);
                if (phanNganh == null)
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
