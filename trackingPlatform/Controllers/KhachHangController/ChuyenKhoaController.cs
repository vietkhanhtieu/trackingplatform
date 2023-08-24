
using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class ChuyenKhoaController : Controller
    {
        private readonly ChuyenKhoaServices _chuyenKhoaServices;
        public ChuyenKhoaController(ChuyenKhoaServices chuyenKhoaServices)
        {
            _chuyenKhoaServices = chuyenKhoaServices;
        }

        /// <summary>
        /// Lấy tất cả các chuyên khoa
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuyenKhoa>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _chuyenKhoaServices.GetAllChuyenKhoa(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy Chuyen Khoa theo maChuyenKhoa
        /// </summary>

        [HttpGet("{maChuyenKhoa}")]
        public async Task<ActionResult<ChuyenKhoa>> Get(string maChuyenKhoa)
        {
            try
            {
                ChuyenKhoa chuyenKhoa = await _chuyenKhoaServices.GetChuyenKhoa(maChuyenKhoa);
                if (chuyenKhoa == null)
                {
                    return NotFound();
                }
                return Ok(chuyenKhoa);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Update hoặc Create ChuyenKhoa
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<ChuyenKhoaRequest> chuyenKhoaRequests)
        {
            try
            {
                return Ok(await _chuyenKhoaServices.AddorUpdateChuyenKhoa(chuyenKhoaRequests));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Xóa Chuyên Khoa theo maChuyenKhoa
        /// </summary>
        [HttpDelete("{maChuyenKhoa}")]
        public async Task<ActionResult> Delete(string maChuyenKhoa)
        {
            try
            {
                ChuyenKhoa chuyenKhoa = await _chuyenKhoaServices.DeleteAsync(maChuyenKhoa);
                if (chuyenKhoa == null)
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
