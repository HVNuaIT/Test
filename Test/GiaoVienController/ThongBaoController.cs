using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly IThongBao thongBao;
        public ThongBaoController(IThongBao thongBao)
        {
            this.thongBao = thongBao;
        }
        [HttpGet("DanhSachThongBao")]
        public IActionResult getAll(int page=1)
        {
            return Ok(thongBao.ThongBaoList(page));
        }
        [HttpDelete("XoaTheoMa")]
        public IActionResult delete(int id)
        {
            try
            {
                thongBao.Delete(id);
                return Ok("Da Xoa Thong Bao");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaToanBoThongBao")]
        public IActionResult Deleteall()
        {
            try
            {
                thongBao.DeleteAll();
                return Ok("Da Xoa Thong Bao");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ThemThongBaoChoLop")]
        public IActionResult Add(ThongBao_LopViewModel x)
        {
            try
            {
              
                return Ok(thongBao.themThongBaoChoLop(x));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
