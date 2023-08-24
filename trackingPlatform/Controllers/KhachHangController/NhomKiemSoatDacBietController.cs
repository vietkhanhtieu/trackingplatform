using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhomKiemSoatDacBietController : Controller
    {
        private readonly NhomKiemSoatDacBietServices _nhomKiemSoatDacBietServices;
        public NhomKiemSoatDacBietController(NhomKiemSoatDacBietServices nhomKiemSoatDacBietServices)
        {
            _nhomKiemSoatDacBietServices = nhomKiemSoatDacBietServices;
        }
        /// <summary>
        /// Get all Kiểm soát đặc biệt
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomKiemSoatDacBiet>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _nhomKiemSoatDacBietServices.GetAllNhomKiemSoat(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Kiểm soát đặc biệt theo maNhomKiemSoat
        /// </summary>
        [HttpGet("{maNhomKiemSoat}")]
        public async Task<ActionResult<NhomKiemSoatDacBiet>> Get(string maNhomKiemSoat)
        {
            try
            {
                NhomKiemSoatDacBiet nhomKiemSoatDacBiet = await _nhomKiemSoatDacBietServices.GetNhomKiemSoat(maNhomKiemSoat);
                if (nhomKiemSoatDacBiet == null)
                {
                    return NotFound();
                }
                return Ok(nhomKiemSoatDacBiet);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Kiểm soát đặc biệt
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<NhomKiemSoatDatBietRequest> nhomKiemSoatDatBietRequests)
        //{
        //    try
        //    {
        //        return Ok(await _nhomKiemSoatDacBietServices.AddorUpdateNhomKiemSoat(nhomKiemSoatDatBietRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}

        /// <summary>
        /// Delete Kiểm soát đặc biệt theo maNhomKiemSoat
        /// </summary>
        [HttpDelete("{maNhomKiemSoat}")]
        public async Task<ActionResult> Delete(string maNhomKiemSoat)
        {
            try
            {
                NhomKiemSoatDacBiet nhomKiemSoatDacBiet = await _nhomKiemSoatDacBietServices.DeleteAsync(maNhomKiemSoat);
                if (nhomKiemSoatDacBiet == null)
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
