using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLUpdateGVController : ControllerBase
    {
        private readonly IGiaoVien gv;
        public QLUpdateGVController(IGiaoVien gv)
        {
            this.gv = gv;
        }

        [HttpPut("ThayDoiHinhAnhGV")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult suaHinhAnh(IFormFile File, string id)
        {
            try
            {
                gv.Update(File, id);
                return Ok("Da Cap Nhat Hinh Anh Cua Giao Vien Co Ma La:" + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
