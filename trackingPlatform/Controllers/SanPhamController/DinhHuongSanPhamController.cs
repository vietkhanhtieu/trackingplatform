using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
using trackingPlatform.Services.BussinessServices.SanPhamServices;
=======
using trackingPlatform.Service.BussinessServices;
using trackingPlatform.Models.SanPhamModels;
using trackingPlatform.Models.Request.SanPhamRequest.CreateUpdate;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class DinhHuongSanPhamController : Controller
    {
        private readonly DinhHuongSanPhamServices _dinhHuongSanPhamServices;
        public DinhHuongSanPhamController(DinhHuongSanPhamServices dinhHuongSanPhamServices)
        {
            _dinhHuongSanPhamServices = dinhHuongSanPhamServices;
        }

        /// <summary>
        /// Get Định hướng sản phẩm by maDinhHuong
        /// </summary>

        [HttpGet("{maDinhHuong}")]
        public async Task<ActionResult<DinhHuongSanPham>> Get(string maDinhHuong)
        {
            try
            {
                DinhHuongSanPham dinhHuongSanPham = await _dinhHuongSanPhamServices.GetDinhHuongSanAsync(maDinhHuong);
                if (dinhHuongSanPham == null)
                {
                    return NotFound();
                }
                return Ok(dinhHuongSanPham);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all Định hướng sản phẩm
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DinhHuongSanPham>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _dinhHuongSanPhamServices.GetAllDinhHuongSanPhamsAsync(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Create or Update Định hướng sản phẩm by 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DinhHuongSanPhamRequest> dinhHuongSanPhamRequests)
        {
            try
            {
                return Ok(await _dinhHuongSanPhamServices.AddorUpdateDinhHuonSanPham(dinhHuongSanPhamRequests));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete Định hướng sản phẩm by maDinhHuong
        /// </summary>
        [HttpDelete("{maDinhHuongSanPham}")]
        public async Task<ActionResult> Delete(string maDinhHuongSanPham)
        {
            try
            {
                DinhHuongSanPham dinhHuongSanPham = await _dinhHuongSanPhamServices.DeleteAsync(maDinhHuongSanPham);
                if (dinhHuongSanPham == null)
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
