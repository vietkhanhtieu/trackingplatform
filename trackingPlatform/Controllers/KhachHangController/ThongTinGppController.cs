using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinGppController : Controller
    {
        private readonly ThongTinGppServices _thongTinGppServices;
        public ThongTinGppController(ThongTinGppServices thongTinGppServices)
        {
            _thongTinGppServices = thongTinGppServices;
        }
        /// <summary>
        /// Get all Thông tin Gpp 
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinGpp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinGppServices.GetAllThongTinGpp(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Thông tin Gpp theo maThongTinGpp
        /// </summary>
        [HttpGet("{maThongTinGpp}")]
        public async Task<ActionResult<ThongTinGpp>> Get(string maThongTinGpp)
        {
            try
            {
                ThongTinGpp ThongTinGpp = await _thongTinGppServices.GetThongTinGpp(maThongTinGpp);
                if (ThongTinGpp == null)
                {
                    return NotFound();
                }
                return Ok(ThongTinGpp);
            }
            catch
            {
                return Problem();
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<NguoiNhanTtHoaDonRequest> ThongTinGppRequests)
        //{
        //    try
        //    {
        //        return Ok(await _thongTinGppServices.AddorUpdateThongTinGpp(ThongTinGppRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}

        /// <summary>
        /// Delete Thông tin Gpp theo maThongTinGpp
        /// </summary>
        [HttpDelete("{maThongTinGpp}")]
        public async Task<ActionResult> Delete(string maThongTinGpp)
        {
            try
            {
                ThongTinGpp ThongTinGpp = await _thongTinGppServices.DeleteAsync(maThongTinGpp);
                if (ThongTinGpp == null)
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
