using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLHocSinhController : ControllerBase
    {
        private readonly IHocSinh hs;
        private readonly IUser user;
        public QLHocSinhController(IHocSinh _hs, IUser _user)
        {
            hs = _hs;
            user = _user;
        }
        [HttpPost("ThemHocSinh")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemHS(HocSinhDTO x)
        {
            try
            {
                var themhs = hs.Add(x);

                return Ok(themhs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpDelete("XoaTaiKhoanHS")]
        [Authorize(Roles = "Admin")]
        public IActionResult XoaTKHS(string ID)
        {

            try
            {
                hs.Delete(ID);
                return Ok("Da Xoa Thanh Cong Tai Khoan Co ID La :" + ID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
