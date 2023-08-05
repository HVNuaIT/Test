using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoAdminController : ControllerBase
    {
        private readonly IThongBaoAdmin tb;
        public ThongBaoAdminController(IThongBaoAdmin tb) { 
        this.tb = tb;
        }
        [HttpGet("ThongBao")]
        [Authorize(Roles ="Admin")]
        public IActionResult Gell(int page = 1)
        {
            return Ok(tb.Getall(page));

        }
        [HttpDelete("XoaThongBao")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            tb.delete(id);
            return Ok("Xoa Thanh Cong");
        }
        [HttpDelete("XoaTatCaThongBao")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAll()
        {
            tb.DeleteAll();
            return Ok("Xoa Thanh Cong");
        }
    }
}
