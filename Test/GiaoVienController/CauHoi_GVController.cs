using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauHoi_GVController : ControllerBase
    {
        private readonly ICauHoi cauHoi;
        private readonly Database db;
        public CauHoi_GVController(ICauHoi cauHoi, Database db)
        {
            this.cauHoi = cauHoi;
            this.db = db;
        }
        [HttpPost("DatCauHoiMonHoc")]
        [Authorize(Roles ="GiaoVien")]
        public IActionResult DatDauHoi (string tieuDe, string noiDung, string mon)
        {
            try
            {
                var ten = "";
                var like = false;
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

                var checkM = db.MonHocs.FirstOrDefault();
                var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                if (checkM.maGiaoVien == kiemtra.maGiaoVien)
                {
                    ten = check.Name;
                    return Ok(cauHoi.DatCauHoi(tieuDe, ten, like, noiDung, mon));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpGet("DanhSachAllCauHoi&Dap")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult GetALL(int page = 1)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

                return Ok(cauHoi.GetAllHoiDap(check.Name, page));
            }catch (Exception ex)
            {
                return BadRequest();
            }
           
        }
        [HttpPut("CapNhatCauHoi&Dap")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Update(int id,CauHoiDTO x)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                if (kiemtra != null)
                {
                    cauHoi.Update(x, id);
                    return Ok("Cap Nhat Thanh Cong Cau Hoi");
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaCauHoi&Dap")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Delete(int id)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                if (kiemtra != null)
                {
                    cauHoi.Delete(id);
                    return Ok("Xoa Thanh Cong Cau Hoi");
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPut("ThichCauHoi&Dap")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Like(int id ,bool like)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                if (kiemtra != null)
                {
                    cauHoi.Like(id, like);
                    if (like == true)
                    {
                        return Ok(" Da thich Thanh Cong Cau Hoi");
                    }
                    else
                    {
                        return Ok(" Bo Thich Thanh Cong Cau Hoi");
                    }
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }

    }
}
