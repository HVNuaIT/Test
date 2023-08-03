using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Sevices;

using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Reflection.PortableExecutable;

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
        
        [HttpGet("DS")]
        [Authorize(Roles = "GiaoVien,Admin")]
      
        public IActionResult getALL(int page=1)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            if (check == null)
            {
                return BadRequest();
            }
            var checkmon = db.DeThis.SingleOrDefault(x=>x.TenGiaoVien == check.Name);
            if (checkmon != null || check.maQuyen ==1) {
                return Ok(dt.getAll(page));
            }
            return NotFound("Chua Up De Thi ");
        }
        [HttpGet("XemChiTiet")]
        [Authorize(Roles = "GiaoVien,Admin")]
        public async Task<IActionResult> XemChiTiet(int id)
        {
            var dethi = dt.XemChiTietDeThi(id);
            string Filename = dethi.TenBaiThi + ".pdf";
            return File(dethi.Content.ToArray(), "application/pdf", Filename);
        }
        [HttpPost("ThemDeThiTuLuan")]
        [Authorize(Roles = "GiaoVien")]
        public async Task<IActionResult> DethiTuLuan(string TenBaiThi,string mon,string hinhThuc, [FromBody] List<TuLuan> s ,string gio , string phut)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            if (check == null)
            {
                return BadRequest();
            }
          
            return Ok(dt.themDeThiTuLuan(TenBaiThi,mon,hinhThuc,s,gio,phut));

        }
      
        [HttpPost("ThemDeThiTracNghiem")]
        [Authorize(Roles = "GiaoVien")]
        public async Task<IActionResult> DethiNghiem(string TenBaiThi, string mon, string hinhThuc, [FromBody] List<CauHoiTracNghiem> s, string gio, string phut)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            if (check == null)
            {
                return BadRequest();
            }

            return Ok(dt.themDeThiTracNghiem(TenBaiThi, mon, hinhThuc, s, gio, phut));

        }



    }
}
