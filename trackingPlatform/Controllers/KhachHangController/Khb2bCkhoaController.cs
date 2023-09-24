
using Microsoft.AspNetCore.Mvc;

using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Models.Request.KhachHangRequest.CreateUpdate;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class Khb2bCkhoaController : Controller
    {
        private readonly Khb2bCkhoaServices _khb2bCkhoaServices;
        public Khb2bCkhoaController(Khb2bCkhoaServices Khb2bCkhoaServices)
        {
            _khb2bCkhoaServices = Khb2bCkhoaServices;
        }
        /// <summary>
        /// Lấy tất cả các Khách hàng b2b chuyên khoa
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khb2bCkhoa>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _khb2bCkhoaServices.GetAllKhb2bCkhoa(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy Khách hàng b2b chuyên khoa theo maKhachHangB2b và maChuyenKhoa
        /// </summary>
        [HttpGet("{maKhachHangB2b}/maChuyenKhoa")]
        public async Task<ActionResult<Khb2bCkhoa>> Get(string maKhachHangB2b, [FromQuery] string maChuyenKhoa)
        {
            try
            {
                Khb2bCkhoa Khb2bCkhoa = await _khb2bCkhoaServices.GetKhb2bCkhoa(maKhachHangB2b, maChuyenKhoa);
                if (Khb2bCkhoa == null)
                {
                    return NotFound();
                }
                return Ok(Khb2bCkhoa);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Khách hàng b2b chuyên khoa theo maKhachHangB2b và maChuyenKhoa
        /// </summary>
        [HttpDelete("{maKhachHangB2b}/maChuyenKhoa")]
        public async Task<ActionResult> Delete(string maKhachHangB2b, [FromQuery] string maChuyenKhoa)
        {
            try
            {
                Khb2bCkhoa Khb2bCkhoa = await _khb2bCkhoaServices.DeleteAsync(maKhachHangB2b, maChuyenKhoa);
                if (Khb2bCkhoa == null)
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
        /// <summary>
        /// Create Khách hàng b2b chuyên khoa
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Khb2bCkhoaRequest> Khb2bCkhoaRequests)
        {

            return Ok(await _khb2bCkhoaServices.AddListKhb2bCkhoaAsync(Khb2bCkhoaRequests));
        }
    }
}
