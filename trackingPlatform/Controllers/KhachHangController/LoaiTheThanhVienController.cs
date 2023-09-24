
using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoaiTheThanhVienController : Controller
    {
        private readonly LoaiTheThanhVienServices _loaiTheThanhVienServices;
        public LoaiTheThanhVienController(LoaiTheThanhVienServices loaiTheThanhVienServices)
        {
            _loaiTheThanhVienServices = loaiTheThanhVienServices;
        }

        /// <summary>
        /// Lấy tất cả các loại thẻ thành viên
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiTheThanhVien>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _loaiTheThanhVienServices.GetAllLoaiTheThanhVien(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy loại thẻ thành viên theo maLoaiThe
        /// </summary>
        [HttpGet("{maLoaiThe}")]
        public async Task<ActionResult<LoaiTheThanhVien>> Get(string maLoaiThe)
        {
            try
            {
                LoaiTheThanhVien loaiTheThanhVien = await _loaiTheThanhVienServices.GetLoaiTheThanhVien(maLoaiThe);
                if (loaiTheThanhVien == null)
                {
                    return NotFound();
                }
                return Ok(loaiTheThanhVien);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update loại thẻ thành viên 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<LoaiTheThanhVienRequest> loaiTheThanhVienRequests)
        {
            try
            {
                return Ok(await _loaiTheThanhVienServices.AddorUpdateLoaiTheThanhVien(loaiTheThanhVienRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Delete loại thẻ thành viên theo maLoaiThe
        /// </summary>
        [HttpDelete("{maLoaiThe}")]
        public async Task<ActionResult> Delete(string maLoaiThe)
        {
            try
            {
                LoaiTheThanhVien loaiTheThanhVien = await _loaiTheThanhVienServices.DeleteAsync(maLoaiThe);
                if (loaiTheThanhVien == null)
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
