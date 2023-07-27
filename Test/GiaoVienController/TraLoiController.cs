using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraLoiController : ControllerBase
    {
        private readonly ITraLoi traLoi;
        private readonly Database db;
        public TraLoiController(ITraLoi traLoi, Database db)
        {
            this.traLoi = traLoi;
            this.db = db;   
        }
        [HttpPost("TraLoi")]
        [Authorize(Roles ="GiaoVien,HocSinh")]
        public IActionResult TraLoi(string noiDung,int maCauHoi)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {

               
                    return Ok(traLoi.TraLoiCauHoi(check.Name,noiDung,maCauHoi));
               
            }
            return BadRequest();
          //  return Ok(traLoi.TraLoiCauHoi(x));

        }
        [HttpDelete("XoaTraLoi")]
        [Authorize(Roles = "GiaoVien,HocSinh")]
        public IActionResult DeLete(int id)
        {
            traLoi.Delete(id);
            return Ok("Da Xoa Thanh Cong");

        }
        [HttpPut("CapNhatLai")]
        [Authorize(Roles = "GiaoVien,HocSinh")]
        public IActionResult Update(int id ,TraLoiDTO x)
        {
            traLoi.Update(id, x);
            return Ok("Da Cap Nhat Thanh Cong");

        }
    }
}
