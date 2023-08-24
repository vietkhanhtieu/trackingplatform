
using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiNhanhController : Controller
    {
        private readonly ChiNhanhServices _chiNhanhServices;
        public ChiNhanhController(ChiNhanhServices chiNhanhServices)
        {
            _chiNhanhServices = chiNhanhServices;
        }

        /// <summary>
        /// Lấy tất cả các chi nhánh
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiNhanh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _chiNhanhServices.GetAllChiNhanh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Lấy chi nhánh theo mã chi nhánh
        /// </summary>

        [HttpGet("{maChiNhanh}")]
        public async Task<ActionResult<ChiNhanh>> Get(string maChiNhanh)
        {
            try
            {
                ChiNhanh phanNganh = await _chiNhanhServices.GetChiNhanh(maChiNhanh);
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
        /// Update hoặc thêm Chi nhánh mới theo Id
        /// </summary>

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<ChiNhanhRequest> chiNhanhRequests)
        //{
        //    try
        //    {
        //        return Ok(await _chiNhanhServices.AddorUpdateChiNhanh(chiNhanhRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}
        /// <summary>
        /// Xóa chi nhánh theo mã chi nhánh
        /// </summary>

        [HttpDelete("{maChiNhanh}")]
        public async Task<ActionResult> Delete(string maChiNhanh)
        {
            try
            {
                ChiNhanh chiNhanh = await _chiNhanhServices.DeleteAsync(maChiNhanh);
                if (chiNhanh == null)
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
