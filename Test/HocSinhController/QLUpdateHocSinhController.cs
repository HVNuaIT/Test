using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.HocSinhController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLUpdateHocSinhController : ControllerBase
    {
        private readonly IHocSinh hs;
        public QLUpdateHocSinhController(IHocSinh hs)
        {
            this.hs = hs;
        }

        [HttpPut("CapNhatHinhAnhHocSinh")]
        [Authorize(Roles = "HocSinh")]
        public IActionResult CapNhatHinhAnh(IFormFile file, string id)
        {
            try
            {
                hs.Update(file, id);
                return Ok("Cap Nhat Hinh Anh Thanh Cong Cua Hoc Sinh Co Ma La: " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
