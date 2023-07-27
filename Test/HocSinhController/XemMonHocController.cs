using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.HocSinhController
{
    [Route("api/[controller]")]
    [ApiController]
    public class XemMonHocController : ControllerBase
    {
        private readonly IMonHoc mon;
        private readonly Database db;
        public static int size { get;  set; } = 5;
        public XemMonHocController(IMonHoc _mon, Database _db)
        {
            mon = _mon;
            db = _db;
        }
        [HttpGet("DanhSachMonHocDuocPhanCong_HocSinh")]
        [Authorize(Roles = "HocSinh")]
        public IActionResult DanhSachPhanCongMonHoc(int page=1)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                var ma = db.MonHocs.FirstOrDefault();
                var kiemtra = db.HocSinhs.SingleOrDefault(x => x.maTK == check.Id);
                if (kiemtra.maLop == ma.maLop)
                {
                    var qr = (from monhoc in db.MonHocs
                                 join GiaoVien in db.GiaoViens on monhoc.maGiaoVien equals GiaoVien.maGiaoVien
                             select new DanhSachMonHoc_HS
                             {
                                 maMon = monhoc.maMonHoc,
                                 tenMon = monhoc.tenMonHoc,
                                 tengiaoVien = monhoc.GiaoVien.user.Name,
                                 //tenBaiGiang = BaiGiang.tenBaiGiang
                                 
                             }).Skip((page-1)*size).Take(size);
                    return Ok(qr.ToList());
                }
            }
            return BadRequest("Hoc Sinh Chua Duoc Phan Cong Mon Nao De Hoc");
        }
        [HttpGet("ChiTietMonHocDuocPhanCong_HocSinh")]
        [Authorize(Roles = "HocSinh")]
        public IActionResult ChiTietMonHoc_HS(string maMon)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
                var ma = db.MonHocs.ToList();
                var kiemtra = db.HocSinhs.SingleOrDefault(x => x.maTK == check.Id);
                if (kiemtra.maLop == ma.FirstOrDefault().maLop && ma.FirstOrDefault().maMonHoc==maMon)
                {
                    var qr = from ChuDe in db.ChuDes
                             join BaiGiang in db.BaiGiangs on ChuDe.maMonHoc equals BaiGiang.maMonHoc
                             select new ChiTietBaiGiang_ChuDe_HocSinh
                             {
                                 tieuDe = ChuDe.tieuDe,
                                 NoiDung = ChuDe.NoiDung,
                                 tenBaiGiang = BaiGiang.tenBaiGiang,
                                 NgayUpload = BaiGiang.NgayUpload,
                                 kichThuc  = BaiGiang.kichThuc,
                                 UpdateByMember = BaiGiang.UpdateByMember,
                                
                             };
                    return Ok(qr.ToList());
                }
            }
            return BadRequest("Hoc Sinh Ko co Mon Hoc Nao");
        }
    }
}
