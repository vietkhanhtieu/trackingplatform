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
    public class ThongTinNoiBoController : Controller
    {
        private readonly ThongTinNoiBoServices _thongTinNoiBoServices;

        public ThongTinNoiBoController(ThongTinNoiBoServices ThongTinNoiBoServices)
        {
            _thongTinNoiBoServices = ThongTinNoiBoServices;
        }
        /// <summary>
        /// Get thông tin nội bộ by maThongTinNoiBo
        /// </summary>

        [HttpGet("{maThongTinNoiBo}")]
        public async Task<ActionResult<ThongTinNoiBo>> Get(string maThongTinNoiBo)
        {
            try
            {
                ThongTinNoiBo thongTinNoiBo = await _thongTinNoiBoServices.GetThongTinNoiBo(maThongTinNoiBo);
                if (thongTinNoiBo == null)
                {
                    return NotFound();
                }
                return Ok(thongTinNoiBo);
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Get all thông tin nội bộ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinNoiBo>>> Get(int top, int skip, string? filter)
        {
            try
            {
                return Ok(await _thongTinNoiBoServices.GetAllThongTinNoiBo(top, skip, filter));
            }
            catch
            {
                return Problem();
            }
        }
        /// <summary>
        /// Delete thông tin nội bộ by maThongTinNoiBo
        /// </summary>
        [HttpDelete("{maThongTinNoiBo}")]
        public async Task<ActionResult> Delete(string maThongTinNoiBo)
        {
            try
            {
                ThongTinNoiBo thongTinNoiBo = await _thongTinNoiBoServices.DeleteAsync(maThongTinNoiBo);
                if (thongTinNoiBo == null)
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
