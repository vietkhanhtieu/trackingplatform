using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class PhuongThucLienLacController : Controller
    {
        private readonly PhuongThucLienLacServices _phuongThucLienLacServices;
        public PhuongThucLienLacController(PhuongThucLienLacServices phuongThucLienLacServices)
        {
            _phuongThucLienLacServices = phuongThucLienLacServices;
        }
        /// <summary>
        /// Get all Phương thức liên lạc
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongThucLienLac>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _phuongThucLienLacServices.GetAllPhuongThucLienLac(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Phương thức liên lạc theo maPhuongThuc
        /// </summary>
        [HttpGet("{maPhuongThuc}")]
        public async Task<ActionResult<PhuongThucLienLac>> Get(string maPhuongThuc)
        {
            try
            {
                PhuongThucLienLac phuongThucLienLac = await _phuongThucLienLacServices.GetPhuongThucLienLac(maPhuongThuc);
                if (phuongThucLienLac == null)
                {
                    return NotFound();
                }
                return Ok(phuongThucLienLac);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Phương thức liên lạc
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<PhuongThucLienLacRequest> phuongThucLienLacRequests)
        {
            try
            {
                return Ok(await _phuongThucLienLacServices.AddorUpdatePhuongThucLienLac(phuongThucLienLacRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete Phương thức liên lạc theo maPhuongThuc
        /// </summary>
        [HttpDelete("{maPhuongThuc}")]
        public async Task<ActionResult> Delete(string maPhuongThuc)
        {
            try
            {
                PhuongThucLienLac phuongThucLienLac = await _phuongThucLienLacServices.DeleteAsync(maPhuongThuc);
                if (phuongThucLienLac == null)
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
