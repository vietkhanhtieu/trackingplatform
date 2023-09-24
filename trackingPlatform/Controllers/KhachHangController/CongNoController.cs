
using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{

    [ApiController]
    [Route("api/[controller]")]
    public class CongNoController : Controller
    {
        private readonly CongNoServices _congNoServices;

        public CongNoController(CongNoServices congNoServices)
        {
            _congNoServices = congNoServices;
        }
        /// <summary>
        /// Lấy công nợ theo maCongNo
        /// </summary>
        [HttpGet("{maCongNo}")]
        public async Task<ActionResult<CongNo>> Get(string maCongNo)
        {
            try
            {
                CongNo congNo = await _congNoServices.GetCongNo(maCongNo);
                if (congNo == null)
                {
                    return NotFound();
                }
                return Ok(congNo);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Lấy tất cả các công nợ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongNo>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _congNoServices.GetAllCongNo(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create hoặc Update Công nợ 
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<CongNoRequest> congNoRequests)
        //{
        //    try
        //    {
        //        return Ok(await _congNoServices.AddorUpdateCongNo(congNoRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}
        /// <summary>
        /// Xóa Công nợ theo maCongNo
        /// </summary>
        [HttpDelete("{maCongNo}")]
        public async Task<ActionResult> Delete(string maCongNo)
        {
            try
            {
                CongNo congNo = await _congNoServices.DeleteAsync(maCongNo);
                if (congNo == null)
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
