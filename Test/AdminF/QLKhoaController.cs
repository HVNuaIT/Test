using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLKhoaController : ControllerBase
    {
        private readonly IKhoa khoa;
        public QLKhoaController(IKhoa khoa)
        {
            this.khoa = khoa;
        }
        [HttpPost("ThemKhoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(KhoaDTO x)
        {
            try
            {
                return Ok(khoa.Add(x));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("DanhSachKhoa")]
        public IActionResult getAll(int page=1)
        {
            try
            {
                return Ok(khoa.GetAll(page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("CapNhatKhoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id,string TenKhoa)
        {
            try
            {
                khoa.update(id, TenKhoa);
                return Ok("Cap Nhat Thanh Cong Khoa Co Ma La :" + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Xoa Khoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {   khoa.Delete(id);
                return Ok("Xoa Thanh Cong Khoa Co ID :" +id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
