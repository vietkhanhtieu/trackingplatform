using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;
namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinThueController : Controller
    {
        private readonly ThongTinThueServices _thongTinThueServices;
        public ThongTinThueController(ThongTinThueServices thongTinThueServices)
        {
            _thongTinThueServices = thongTinThueServices;
        }

        /// <summary>
        /// Get all Thông tin thuế 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinThue>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinThueServices.GetAllThongTinThue(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Thông tin thuế theo maThongTinThue
        /// </summary>
        [HttpGet("{maThongTinThue}")]
        public async Task<ActionResult<ThongTinThue>> Get(string maThongTinThue)
        {
            try
            {
                ThongTinThue thongTinThue = await _thongTinThueServices.GetThongTinThue(maThongTinThue);
                if (thongTinThue == null)
                {
                    return NotFound();
                }
                return Ok(thongTinThue);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Thông tin thuế
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<ThongTinThueRequest> thongTinThueRequests)
        //{
        //    try
        //    {

        //        return Ok(await _thongTinThueServices.AddorUpdateThongTinThue(thongTinThueRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}
        /// <summary>
        /// Delete Thông tin thuế theo maThongTinThue
        /// </summary>
        [HttpDelete("{maThongTinThue}")]
        public async Task<ActionResult> Delete(string maThongTinThue)
        {
            try
            {
                ThongTinThue thongTinThue = await _thongTinThueServices.DeleteAsync(maThongTinThue);
                if (thongTinThue == null)
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
