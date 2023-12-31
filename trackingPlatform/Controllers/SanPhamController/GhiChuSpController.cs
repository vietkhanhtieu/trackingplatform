﻿using Microsoft.AspNetCore.Mvc;
using trackingPlatform.Models.SanPhamModels;
<<<<<<< HEAD
using trackingPlatform.Services.BussinessServices.SanPhamServices;
using trackingPlatform.Services.SanPhamServices.BussinessServices.SanPhamServices;
=======
using trackingPlatform.Service.BussinessServices;
>>>>>>> 4bacfd5602449a84006f53f353eb1bad2a3a2912

namespace trackingPlatform.Controllers.SanPhamController
{

    [ApiController]
    [Route("api/[controller]")]
    public class GhiChuSpController : Controller
    {
        private readonly GhiChuSanPhamServices _ghiChuSanPhamServices;

        public GhiChuSpController(GhiChuSanPhamServices ghiChuSanPhamServices)
        {
            _ghiChuSanPhamServices = ghiChuSanPhamServices;
        }
        /// <summary>
        /// Get ghi chú sản phẩm by maGhiChuSp
        /// </summary>

        [HttpGet("{maGhiChuSp}")]
        public async Task<ActionResult<GhiChuSp>> Get(string maGhiChuSp)
        {
            try
            {
                GhiChuSp GhiChuSp = await _ghiChuSanPhamServices.GetGhiChuSanPham(maGhiChuSp);
                if (GhiChuSp == null)
                {
                    return NotFound();
                }
                return Ok(GhiChuSp);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all ghi chú sản phẩm
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GhiChuSp>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _ghiChuSanPhamServices.GetAllGhiChuSanPham(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }




        /// <summary>
        /// Delete ghi chú sản phẩm by maGhiChuSp
        /// </summary>
        [HttpDelete("{maGhiChuSp}")]
        public async Task<ActionResult> Delete(string maGhiChuSp)
        {
            try
            {
                GhiChuSp GhiChuSp = await _ghiChuSanPhamServices.DeleteAsync(maGhiChuSp);
                if (GhiChuSp == null)
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
