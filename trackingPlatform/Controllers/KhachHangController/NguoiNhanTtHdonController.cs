using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Services.BussinessServices.KhachHangServices;

namespace trackingPlatform.Controllers.KhachHangController
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiNhanTtHdonController : Controller
    {
        private readonly NguoiNhanTtHdonServices _nguoiNhanTtHdonServices;
        public NguoiNhanTtHdonController(NguoiNhanTtHdonServices nguoiNhanTtHdonServices)
        {
            _nguoiNhanTtHdonServices = nguoiNhanTtHdonServices;
        }

        /// <summary>
        /// Get all Người nhận thông tin hóa đơn
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiNhanTtHdon>>> Get(int top, int skip, string? filter)
        {
            //try
            //{
                return Ok(await _nguoiNhanTtHdonServices.GetAllNguoiNhanTtHdon(top, skip, filter));
            //}
            //catch
            //{
            //    return Problem();
            //}
        }
        /// <summary>
        /// Get Người nhận thông tin hóa đơn theo maNguoiNhanTtHdon
        /// </summary>
        [HttpGet("{maNguoiNhanTtHdon}")]
        public async Task<ActionResult<NguoiNhanTtHdon>> Get(string maNguoiNhanTtHdon)
        {
            try
            {
                NguoiNhanTtHdon NguoiNhanTtHdon = await _nguoiNhanTtHdonServices.GetNguoiNhanTtHdon(maNguoiNhanTtHdon);
                if (NguoiNhanTtHdon == null)
                {
                    return NotFound();
                }
                return Ok(NguoiNhanTtHdon);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Update Người nhận thông tin hóa đơn 
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<NguoiNhanTtHoaDonRequest> nguoiNhanTtHdonRequests)
        //{
        //    try
        //    {
        //        return Ok(await _nguoiNhanTtHdonServices.AddorUpdateNguoiNhanTtHdon(nguoiNhanTtHdonRequests));
        //    }
        //    catch
        //    {
        //        return Problem();
        //    }
        //}


        /// <summary>
        /// Delete Người nhận thông tin hóa đơn theo maNguoiNhanTtHdon
        /// </summary>

        [HttpDelete("{maNguoiNhanTtHdon}")]
        public async Task<ActionResult> Delete(string maNguoiNhanTtHdon)
        {
            try
            {
                NguoiNhanTtHdon NguoiNhanTtHdon = await _nguoiNhanTtHdonServices.DeleteAsync(maNguoiNhanTtHdon);
                if (NguoiNhanTtHdon == null)
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
