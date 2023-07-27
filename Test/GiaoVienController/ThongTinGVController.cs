using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinGVController : ControllerBase
    {
        private readonly Database db;
        public ThongTinGVController(Database db)
        {
            this.db = db;
        }
        [HttpGet("ThongTinGV")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult ThongTin()
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
             var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                if (kiemtra !=null)
                {
                    var qr = (from User in db.Users
                             join GiaoVien in db.GiaoViens on User.Id equals GiaoVien.maTK
                             select new ChiTietThongTinGV
                             {
                                 maGv = GiaoVien.maGiaoVien,
                                 gioTinh = User.gioTinh,
                                 Khoa = GiaoVien.Khoa.tenKhoa,
                                 Email = User.Email,
                                 ten = User.Name,
                                 diaChi = User.DiaChi,            
                                 soDienThoai = User.SDT,
                                 hinhAnh = User.hinhAnh,
                             }).Where(x=>x.Email==check.Email);
                    return Ok(qr);
                }
            }
            return BadRequest();
        }
    }
}
