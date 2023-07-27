using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLLopController : ControllerBase
    {
        private readonly ILop lop;
        public QLLopController(ILop lop)
        {
            this.lop = lop;
        }
        [HttpPost("ThemLopHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(LopDTO x)
        {
            try
            {
                return Ok(lop.Add(x));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateLopHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(LopViewModel x,string id)
        {
            try
            {
                lop.Update(id, x);
                return Ok("Cap Nhat Thanh Cong Lop Co Id: " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteLopHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete( string id)
        {
            try
            {
                lop.Delete(id);
                return Ok("Xoa Thanh Cong Lop Co Id: " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
