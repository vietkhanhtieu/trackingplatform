﻿using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.Request.CreateUpdate;
using trackingPlatform.Models;
using trackingPlatform.Service.BussinessServices;

namespace trackingPlatform.Controllers
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
