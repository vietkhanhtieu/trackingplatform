using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class DonViTinhController : Controller
    {
        private readonly DonViTinhService _donViTinhService;

        public DonViTinhController(DonViTinhService donViTinhService)
        {
            _donViTinhService = donViTinhService;
        }

        /// <summary>
        /// Get Đơn vị tính by maDonViTinh
        /// </summary>

        [HttpGet("{maDonViTinh}")]
        public async Task<ActionResult<DonViTinh>> Get(string maDonViTinh)
        {
            try
            {
                DonViTinh donViTinh = await _donViTinhService.GetDonViTinh(maDonViTinh);
                if (donViTinh == null)
                {
                    return NotFound();
                }
                return Ok(donViTinh);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Đơn vị tính 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViTinh>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _donViTinhService.GetAllDonViTinh(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Đơn vị tính 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DonViTinhRequest> donViTinhRequest)
        {
            try
            {
                return Ok(await _donViTinhService.AddorUpdateDonViTinh(donViTinhRequest));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Đơn vị tính by maDonViTinh
        /// </summary>
        [HttpDelete("{maDonViTinh}")]
        public async Task<ActionResult> Delete(string maDonViTinh)
        {
            try
            {
                DonViTinh donViTinh = await _donViTinhService.DeleteAsync(maDonViTinh);
                if (donViTinh == null)
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
