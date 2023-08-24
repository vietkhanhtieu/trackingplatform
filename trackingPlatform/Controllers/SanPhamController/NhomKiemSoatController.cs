using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;

namespace trackingPlatform.Controllers.SanPhamController
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
        /// <summary>
        /// Get Nhóm kiểm soát by maNhomKiemSoat
        /// </summary>

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
        /// <summary>
        /// Get all Nhóm kiểm soát 
        /// </summary>
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
        /// <summary>
        /// Create or Update Nhóm kiểm soát 
        /// </summary>
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
        /// <summary>
        /// Delete Nhóm kiểm soát by maNhomKiemSoat
        /// </summary>
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
