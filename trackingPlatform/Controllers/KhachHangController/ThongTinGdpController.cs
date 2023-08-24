using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinGdpController : Controller
    {
        private readonly ThongTinKhachGdpServices _thongTinGdpServices;
        public ThongTinGdpController(ThongTinKhachGdpServices thongTinGdpServices)
        {
            _thongTinGdpServices = thongTinGdpServices;
        }

        /// <summary>
        /// Get all Thông tin Gdp
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinGdp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinGdpServices.GetAllThongTinGdp(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get Thông tin Gdp theo maThongTinGdp
        /// </summary>
        [HttpGet("{maThongTinGdp}")]
        public async Task<ActionResult<ThongTinGdp>> Get(string maThongTinGdp)
        {
            try
            {
                ThongTinGdp ThongTinGdp = await _thongTinGdpServices.GetThongTinGdp(maThongTinGdp);
                if (ThongTinGdp == null)
                {
                    return NotFound();
                }
                return Ok(ThongTinGdp);
            }
            catch
            {
                return Problem();
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<NguoiNhanTtHoaDonRequest> ThongTinGdpRequests)
        //{
        //    try
        //    {
        //        return Ok(await _thongTinGdpServices.AddorUpdateThongTinGdp(ThongTinGdpRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}

        /// <summary>
        /// Delete Thông tin Gdp theo maThongTinGdp
        /// </summary>
        [HttpDelete("{maThongTinGdp}")]
        public async Task<ActionResult> Delete(string maThongTinGdp)
        {
            try
            {
                ThongTinGdp ThongTinGdp = await _thongTinGdpServices.DeleteAsync(maThongTinGdp);
                if (ThongTinGdp == null)
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
