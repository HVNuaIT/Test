﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;

namespace Test.HocSinhController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinHocSinhController : ControllerBase
    {
        private readonly Database db;
        public ThongTinHocSinhController(Database db)
        {
            this.db = db;
        }
        [HttpGet("ThongTinHS")]
        [Authorize(Roles ="HocSinh")]
        public IActionResult ThongTin()
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (check == null)
            {
                return BadRequest();
            }
            else
            {
              
                var kiemtra = db.HocSinhs.SingleOrDefault(x => x.maTK == check.Id);
               
                if (kiemtra !=null)
                {
                    var qr = (from User in db.Users
                             join HocSinh in db.HocSinhs on User.Id equals HocSinh.maTK
                             select new ChiTietThongTinhHS
                             {
                                 tenHienThi =User.Name,
                                 diaChi =User.DiaChi,
                                 maHocSinh =HocSinh.maHocSinh,
                                 Email=User.Email,
                                 hinhAnh=User.hinhAnh,
                                 Khoa=HocSinh.Khoa.tenKhoa,
                                 maLop = HocSinh.maLop,
                                 SDT = User.SDT,
                                 gioTinh = User.gioTinh,
 
                             }).Where(x=>x.Email==check.Email);
                    return Ok(qr);
                }
            }
            return BadRequest();


        }
    }
}