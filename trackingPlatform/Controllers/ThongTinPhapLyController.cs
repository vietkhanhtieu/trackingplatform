using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinPhapLyController : Controller
    {
        private readonly ThongTinPhapLyServices _thongTinPhapLyServices;

        public ThongTinPhapLyController(ThongTinPhapLyServices ThongTinPhapLyServices)
        {
            _thongTinPhapLyServices = ThongTinPhapLyServices;
        }
        /// <summary>
        /// Get thông tin pháp lý by maThongTinPhapLy
        /// </summary>

        [HttpGet("{maThongTinPhapLy}")]
        public async Task<ActionResult<ThongTinPhapLy>> Get(string maThongTinPhapLy)
        {
            try
            {
                ThongTinPhapLy ThongTinPhapLy = await _thongTinPhapLyServices.GetThongTinPhapLy(maThongTinPhapLy);
                if (ThongTinPhapLy == null)
                {
                    return NotFound();
                }
                return Ok(ThongTinPhapLy);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all thông tin pháp lý
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinPhapLy>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinPhapLyServices.GetAllThongTinPhapLy(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete thông tin pháp lý by maThongTinPhapLy
        /// </summary>
        [HttpDelete("{maThongTinPhapLy}")]
        public async Task<ActionResult> Delete(string maThongTinPhapLy)
        {
            try
            {
                ThongTinPhapLy ThongTinPhapLy = await _thongTinPhapLyServices.DeleteAsync(maThongTinPhapLy);
                if (ThongTinPhapLy == null)
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
