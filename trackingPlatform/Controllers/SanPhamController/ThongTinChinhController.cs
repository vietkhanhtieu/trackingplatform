using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Services.RepositoryServices.SanPhamRepositoryServices;

namespace trackingPlatform.Controllers.SanPhamController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinChinhController : Controller
    {
        private readonly ThongTinChinhServices _thongTinChinhServices;

        public ThongTinChinhController(ThongTinChinhServices ThongTinChinhServices)
        {
            _thongTinChinhServices = ThongTinChinhServices;
        }
        /// <summary>
        /// Get thông tin chính by maThongTinChinh
        /// </summary>

        [HttpGet("{maThongTinChinh}")]
        public async Task<ActionResult<ThongTinChinh>> Get(string maThongTinChinh)
        {
            try
            {
                ThongTinChinh thongTinChinh = await _thongTinChinhServices.GetThongTinChinh(maThongTinChinh);
                if (thongTinChinh == null)
                {
                    return NotFound();
                }
                return Ok(thongTinChinh);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all thông tin chính
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinChinh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinChinhServices.GetAllThongTinChinh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }




        /// <summary>
        /// Delete thông tin chính by maThongTinChinh
        /// </summary>
        [HttpDelete("{maThongTinChinh}")]
        public async Task<ActionResult> Delete(string maThongTinChinh)
        {
            try
            {
                ThongTinChinh ThongTinChinh = await _thongTinChinhServices.DeleteAsync(maThongTinChinh);
                if (ThongTinChinh == null)
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
