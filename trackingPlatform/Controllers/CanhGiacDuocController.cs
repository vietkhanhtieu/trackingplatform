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


        /// <summary>
        /// Get Cảnh giác dược by maCanhGiacDuoc
        /// </summary>

        [HttpGet("{maCanhGiacDuoc}")]
        public async Task<ActionResult<CanhGiacDuoc>> Get(string maCanhGiacDuoc)
        {
            try
            {
                CanhGiacDuoc canhGiacDuoc = await _canhGiacDuocServices.GetCanhGiacDuoc(maCanhGiacDuoc);
                if (canhGiacDuoc == null)
                {
                    return NotFound();
                }
                return Ok(canhGiacDuoc);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Cảnh giác dược
        /// </summary>
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

       


        /// <summary>
        /// Delete Cảnh giác dược by maCanhGiacDuoc
        /// </summary>
        [HttpDelete("{maCanhGiacDuoc}")]
        public async Task<ActionResult> Delete(string maCanhGiacDuoc)
        {
            try
            {
                CanhGiacDuoc canhGiacDuoc = await _canhGiacDuocServices.DeleteAsync(maCanhGiacDuoc);
                if (canhGiacDuoc == null)
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
