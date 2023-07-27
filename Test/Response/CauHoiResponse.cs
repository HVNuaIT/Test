using AutoMapper;
using System.Dynamic;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class CauHoiResponse : ICauHoi
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public CauHoiResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public CauHoiDTO DatCauHoi(string tieuDe, string nguoiDatCauHoi, bool like, string noiDung,string mon)
        {
            try
            {
              var cauHoi = new CauHoi();
                cauHoi.tieuDe = tieuDe;
                cauHoi.noiDungCauHoi=noiDung;
                cauHoi.NguoiBinhLuan = nguoiDatCauHoi;
                cauHoi.ngay = DateTime.Now;
                cauHoi.thich = false;
                cauHoi.Mon = mon;
                db.CauHois.Add(cauHoi);
                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = nguoiDatCauHoi + "Da them Cau hoi Vao mon Hoc " + cauHoi.MonHoc.tenMonHoc;
                thongBao.TenNguoiThongBao = nguoiDatCauHoi;
                db.ThongBaos.Add(thongBao);
                db.SaveChanges();
                return new CauHoiDTO
                {
                    nguoiBinhLuan = cauHoi.NguoiBinhLuan,
                    tieuDe = cauHoi.tieuDe,
                    noiDungCauHoi = cauHoi.noiDungCauHoi,
                    thich =cauHoi.thich,
                   ngay = cauHoi.ngay,
                   Mon = cauHoi.Mon
                   
                };
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public List<ListHoiDap>  GetAll(int page = 1)
        {
            var qr = (from a in db.CauHois
                      join b in db.TraLois on a.maCauHoi equals b.maCauHoi
                      select new ListHoiDap
                      {
                          tenNguoiHoi = a.NguoiBinhLuan,
                          tieuDe = a.tieuDe,
                          noiDungCauHoi = a.noiDungCauHoi,
                          ngayHoi = a.ngay,
                          tenNguoiTL = b.tenNguoiTraLoi,
                          NoiDungTL = b.NoiDung,
                          ngayTl = b.ngay,

                      }).Skip((page - 1) * pagesize).Take(pagesize).ToList() ;


            if (qr.Count == 0)
            {
                var cauHoi = db.CauHois.FirstOrDefault();
                // var tl = db.TraLois.SingleOrDefault();
                var kq = new ListHoiDap();
                kq.tenNguoiHoi = cauHoi.NguoiBinhLuan;
                kq.tieuDe = cauHoi.tieuDe;
                kq.noiDungCauHoi = cauHoi.noiDungCauHoi;
                kq.ngayHoi = cauHoi.ngay;
                kq.ngayTl = cauHoi.ngay;
                kq.tenNguoiTL = "";
                kq.NoiDungTL = "";
                var ds = new List<ListHoiDap>();
                ds.Add(kq);
                return ds.ToList();

            }
            else
            {
              return  qr.ToList() ;
            }

        }

        public void Delete(int id)
        {
            var check = db.CauHois.SingleOrDefault(x => x.maCauHoi == id);
            if (check != null)
            {

                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da Xoa Cau Hoi";
                thongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                db.ThongBaos.Add(thongBao);
                db.CauHois.Remove(check);
                db.SaveChanges();
            }
        }

        public void Update(CauHoiDTO x, int id)
        {
          var check = db.CauHois.SingleOrDefault(x=>x.maCauHoi == id);
            if(check != null)
            {
                check.ngay= DateTime.Now;
                check.noiDungCauHoi = x.noiDungCauHoi;
                check.tieuDe = x.tieuDe;
                db.Entry(check).State=Microsoft.EntityFrameworkCore.EntityState.Modified; db.SaveChanges();
             
            }
        }

        public void Like(int id, bool Like)
        {
            var check = db.CauHois.SingleOrDefault(x => x.maCauHoi == id);
            if (check != null)
            {
                check.thich = Like;
                var ThongBao = new ThongBao();
                if (Like == true)
                {
                   
                    ThongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da thich Binh Cau Hoi";
                    ThongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                   
                }
                else
                {
                    
                    ThongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da Bo thich Binh Cau Hoi";
                    ThongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                   
                }
                db.ThongBaos.Add(ThongBao);    
                db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges() ;
            }
        }
    }
}
