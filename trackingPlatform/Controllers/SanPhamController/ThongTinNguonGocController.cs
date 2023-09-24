using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
<<<<<<< HEAD
using trackingPlatform.Services.BussinessServices.SanPhamServices;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
=======
using trackingPlatform.Service.BussinessServices;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinNguonGocController : Controller
    {
        private readonly ThongTinNguonGocServices _thongTinNguonGocServices;

        public ThongTinNguonGocController(ThongTinNguonGocServices thongTinNguonGocServices)
        {
            _thongTinNguonGocServices = thongTinNguonGocServices;
        }
        /// <summary>
        /// Get thông tin nguồn gốc by maThongTinNguonGoc
        /// </summary>

        [HttpGet("{maThongTinNguonGoc}")]
        public async Task<ActionResult<ThongTinNguonGoc>> Get(string maThongTinNguonGoc)
        {
            try
            {
                ThongTinNguonGoc thongTinNguonGoc = await _thongTinNguonGocServices.GetThongTinNguonGoc(maThongTinNguonGoc);
                if (thongTinNguonGoc == null)
                {
                    return NotFound();
                }
                return Ok(thongTinNguonGoc);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all thông tin nguồn gốc
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinNguonGoc>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinNguonGocServices.GetAllThongTinNguonGoc(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete thông tin nguồn gốc by maThongTinNguonGoc
        /// </summary>
        [HttpDelete("{maThongTinNguonGoc}")]
        public async Task<ActionResult> Delete(string maThongTinNguonGoc)
        {
            try
            {
                ThongTinNguonGoc thongTinNguonGoc = await _thongTinNguonGocServices.DeleteAsync(maThongTinNguonGoc);
                if (thongTinNguonGoc == null)
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
