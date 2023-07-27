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
    public class QLMonHocController : ControllerBase
    {
        private readonly IMonHoc mon;
        public QLMonHocController(IMonHoc mon)
        {
            this.mon = mon;
        }
        [HttpPost("ThemMonHocVaPhanCong")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(MonHocDTO monHocDTO)
        {
            try
            {
                return Ok(mon.Add(monHocDTO));
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("CapNhatLaiMonHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(MonHocViewModel x,string id)
        {
            try
            { mon.Update(x,id);
                return Ok("Da Cap Nhat Lai Mon Hoc Co ID La :" + id);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("XoaMonHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {    mon.Delete(id);
                return Ok("Da Xoa Mon Hoc Co ID La : " + id);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
