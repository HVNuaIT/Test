using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetBaiThiController : ControllerBase
    {
        private readonly IDeThi_KiemTra dt;
        public DuyetBaiThiController(IDeThi_KiemTra _dt)
        {
           dt = _dt;
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public IActionResult DuyetBaiThiTuLuan(string trangThai, int id)
        {    
            return Ok(dt.DuyetTuLuat(id,trangThai));
        }
    }
}
