using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSCacMonDuocPhanCongController : ControllerBase
    {
        private readonly IMonHoc mon;
        private readonly Database db;
        public DSCacMonDuocPhanCongController(IMonHoc _mon, Database _db)
        {
            mon = _mon;
            db = _db;
        }
        [HttpGet("DanhSachMonHocDuocPhanCong_Lop")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult DanhSachPhanCongMonHoc()
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                var ma = db.MonHocs.ToList();
                var kiemtra = db.GiaoViens.SingleOrDefault(x => x.maTK == check.Id);
                //if (kiemtra == null)
                //{
                //    return BadRequest();
                //}
                 if (kiemtra.maGiaoVien == ma.FirstOrDefault().maGiaoVien)
                {
                    var qr = from monhoc in db.MonHocs
                            // join lop in db.Lops on monhoc.GiaoVien.maKhoa equals lop.maKhoa
                             select new ChiTietPhanCongMonHoc
                             {
                                 maMonHoc = monhoc.maMonHoc,
                                 tenMonHoc = monhoc.tenMonHoc,
                                 moTa = monhoc.moTa,
                                 maLop = monhoc.maLop,
                                 tenLop = monhoc.Lop.tenLop,
                                 maGiaoVien = monhoc.GiaoVien.user.Name
                             };
                    return Ok(qr.ToList());
                }
            }
            return BadRequest("Giao Vien Chua Duoc Phan Cong Mon");
        }
    }


}
