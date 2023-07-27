using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeThiVaKTController : ControllerBase
    {
        private readonly IDeThi_KiemTra dt;
        private readonly Database db;

        public DeThiVaKTController(IDeThi_KiemTra dt, Database db)
        {
            this.dt = dt;
            this.db = db;
        }
        [HttpPost("ThemDeThiTuLuan")]
        [Authorize(Roles ="GiaoVien")]
        public IActionResult AddTuLuan(string mon, string tenDethi, [FromBody]List<TuLuan>s )
        {
             
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                DateTime times = DateTime.Now;
                
                var them = dt.themDeThiTuLuan(tenDethi, mon, check.Name, times, s);
                return Ok(them);
            }
        }
        //  [HttpPost("ThemDeThiTracNghiem")]
        //public IActionResult AddTracNghiem(string mon, string tenDethi, [FromBody]List<CauHoiKT>s )
        //{
             
        //    var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

        //    if (check == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        DateTime times = DateTime.Now;
        //        var them = dt.themDeThiTuLuan(tenDethi, mon, check.Name, times, s);
        //        return Ok(them);
        //    }
        //}
       
        
        [HttpGet("DS")]
        [Authorize(Roles = "GiaoVien")]
        [Authorize(Roles = "Admin")]
        public IActionResult getALL()
        {

           return Ok(dt.getAll());
        }
        [HttpGet("XemChiTiet")]
        [Authorize(Roles = "GiaoVien")]
        [Authorize(Roles = "Admin")]
        public IActionResult XemChiTiet(int id)
        {

            return Ok(dt.XemChiTietDeThi(id));
        }

    }
}
