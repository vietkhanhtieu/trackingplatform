using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiSanPhamNoiBoController : Controller
    {
        private readonly LoaiSpNoiBoServices _loaiSpNoiBoServices;

        public LoaiSanPhamNoiBoController(LoaiSpNoiBoServices loaiSpNoiBoServices)
        {
            _loaiSpNoiBoServices = loaiSpNoiBoServices;
        }

        [HttpGet("{maLoaiSanPhamNoiBo}")]
        public async Task<ActionResult<LoaiSpNoiBo>> Get(string maLoaiSanPhamNoiBo)
        {
            try
            {
                LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoServices.GetLoaiSpNoiBo(maLoaiSanPhamNoiBo);
                if (loaiSpNoiBo == null)
                {
                    return NotFound();
                }
                return Ok(loaiSpNoiBo);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSpNoiBo>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiSpNoiBoServices.GetAllLoaiSpNoiBo(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiSanPhamNoiBoRequest> loaiSanPhamNoiBoRequests)
        {
            try
            {
                return Ok(await _loaiSpNoiBoServices.AddorUpdateLoaiSpNoiBo(loaiSanPhamNoiBoRequests));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{maLoaiSanPhamNoiBo}")]
        public async Task<ActionResult> Delete(string maLoaiSanPhamNoiBo)
        {
            try
            {
                LoaiSpNoiBo loaiSpNoiBo = await _loaiSpNoiBoServices.DeleteAsync(maLoaiSanPhamNoiBo);
                if (loaiSpNoiBo == null)
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
