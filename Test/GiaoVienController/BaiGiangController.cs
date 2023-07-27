using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiGiangController : ControllerBase
    {
        private readonly IBaiGiang baiGiang;
        private readonly IThongBao thong;
        public BaiGiangController(IBaiGiang baiGiang, IThongBao thong)
        {
            this.baiGiang = baiGiang;
            this.thong = thong;
        }
        [HttpPost("ThemBaiGiang")]
        [Authorize(Roles ="GiaoVien")]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files,string maMonHoc,string tenBaiGiang)
        {
            var uploadResponse = await baiGiang.UploadFile(files,maMonHoc,tenBaiGiang);
            if (uploadResponse.ErrorMessage != "")
                return BadRequest(new { error = uploadResponse.ErrorMessage });
            return Ok(uploadResponse);
        }
        [HttpGet("DownTheoId")]
        [Authorize(Roles = "GiaoVien,Admin")]
        
        public async Task<IActionResult> DownloadFile(int id)
        {
            var stream = await baiGiang.DownloadFile(id);
            if (stream == null)
                return NotFound();
            return new FileContentResult(stream, "application/octet-stream");
        }
        
        [HttpGet("XemDanhSachBaiGiang")]
        [Authorize(Roles = "GiaoVien,Admin")]
      
        public async Task<IActionResult> DanhSachBaiGiangGV(int page=1)
        {
            return Ok(baiGiang.GetALl(page));
        }
        [HttpDelete("Xoa Bai Giang")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Remove(string ten)
        {
            try
            {
                baiGiang.Delete(ten);
                return Ok("Da Xoa Bai Giang");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
