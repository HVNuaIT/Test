using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class LopResponse : ILop
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public LopResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;

        }
        public LopDTO Add(LopDTO x)
        {
            var map = mapper.Map<Lop>(x);
            var checkLop = db.Lops.FirstOrDefault(a=>a.maLop==map.maLop);
            if(checkLop!=null)
            {
                return null;
            }
            else
            {
                db.Lops.Add(map);
                db.SaveChanges();
                return x;
            }
        }

        public void Delete(string id)
        {
          var checkLop=db.Lops.FirstOrDefault(x=>x.maLop==id);
            if(checkLop!=null)
            {
                db.Lops.Remove(checkLop); db.SaveChanges();
            }
        }

        public void Update(string id, LopViewModel x)
        {
           var checkLop=db.Lops.FirstOrDefault(a=>a.maLop==id);
            
            if(checkLop!=null)
            {
                checkLop.tenLop = x.tenLop;
                   // checkLop.maKhoa = x.maKhoa;
                db.Entry(checkLop).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges() ;
            }
        }

        public List<LopDTO> Getall(int page = 1)
        {
          var check = db.Lops.AsQueryable();
            check = check.Skip((page-1)*pagesize).Take(pagesize);
            var kq = check.Select(x => new LopDTO
            {
                maLop = x.maLop,
                tenLop = x.tenLop,
            }).ToList();
            return kq.ToList();
        }
    }
}
