
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiHinhDichVuController : Controller
    {
        private readonly LoaiHinhDichVuServices _loaiHinhDichVuServices;
        public LoaiHinhDichVuController(LoaiHinhDichVuServices loaiHinhDichVuServices)
        {
            _loaiHinhDichVuServices = loaiHinhDichVuServices;
        }

        /// <summary>
        /// Lấy tất cả các loại hình dịch vụ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiHinhDichVu>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiHinhDichVuServices.GetAllLoaiHinhDichVu(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Lấy loại hình dịch vụ maLoaiDichVu
        /// </summary>
        [HttpGet("{maLoaiDichVu}")]
        public async Task<ActionResult<LoaiHinhDichVu>> Get(string maLoaiDichVu)
        {
            try
            {
                LoaiHinhDichVu phanNganh = await _loaiHinhDichVuServices.GetLoaiHinhDichVu(maLoaiDichVu);
                if (phanNganh == null)
                {
                    return NotFound();
                }
                return Ok(phanNganh);
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Create hoặc update loại hình dịch vụ
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiHinhDichVuRequest> loaiHinhDichVuRequests)
        {
            try
            {
                return Ok(await _loaiHinhDichVuServices.AddorUpdateLoaiHinhDichVu(loaiHinhDichVuRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete loại hình dịch vụ theo maLoaiDichVu
        /// </summary>
        [HttpDelete("{maLoaiDichVu}")]
        public async Task<ActionResult> Delete(string maLoaiDichVu)
        {
            try
            {
                LoaiHinhDichVu loaiHinhDichVu = await _loaiHinhDichVuServices.DeleteAsync(maLoaiDichVu);
                if (loaiHinhDichVu == null)
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
