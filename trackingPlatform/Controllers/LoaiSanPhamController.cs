using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiSanPhamController : Controller
    {
        private readonly LoaiSpServices _loaiSpServices;

        public LoaiSanPhamController(LoaiSpServices loaiSpServices)
        {
            _loaiSpServices = loaiSpServices;
        }

        [HttpGet("{maLoaiSanPham}")]
        public async Task<ActionResult<LoaiSp>> Get(string maLoaiSanPham)
        {
            try
            {
                LoaiSp loaiSp = await _loaiSpServices.GetLoaisp(maLoaiSanPham);
                if (loaiSp == null)
                {
                    return NotFound();
                }
                return Ok(loaiSp);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiSpServices.GetAllGetLoaisp(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiSpRequest> loaiSpRequest)
        {
            try
            {
                return Ok(await _loaiSpServices.AddorUpdateLoaiSp(loaiSpRequest));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{maLoaiSanPham}")]
        public async Task<ActionResult> Delete(string maLoaiSanPham)
        {
            try
            {
                LoaiSp loaiSp = await _loaiSpServices.DeleteAsync(maLoaiSanPham);
                if (loaiSp == null)
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
