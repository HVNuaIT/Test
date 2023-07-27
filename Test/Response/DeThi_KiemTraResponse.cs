using System.IO;
using Test.DatabaseContext;

using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class DeThi_KiemTraResponse : IDeThi_KiemTra
    {
        private readonly Database db; 
        public DeThi_KiemTraResponse(Database db)
        {
            this.db = db;
        }

        public DeThi DuyetTuLuat(int id,string trangThai)
        {
            try
            {
                var check = db.DeThis.Where(x => x.Id == id).FirstOrDefault();

                if (check != null)
                {
                    var thongBao = new ThongBao();
                    thongBao.tieuDeThongBao = check.TenBaiThi + "Da Duoc Admin Duyet ";
                    check.TinhTrang = trangThai;
                    db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.ThongBaos.Add(thongBao);
                    db.SaveChanges();
                    return new DeThi
                    {
                        hinhThuc = check.hinhThuc,
                        TinhTrang = check.TinhTrang,
                        TenBaiThi = check.TenBaiThi,
                        TenGiaoVien = check.TenGiaoVien,
                        ThoiGiangThi = check.ThoiGiangThi,
                        maMonHoc = check.maMonHoc,
                        CauHoi = db.TuLuans.Where(a => a.IdDethi == check.Id).ToList(),

                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<DeThi> getAll()
        {
            var ds = db.DeThis.ToList(); 
            foreach (var x in ds)
            {
                x.CauHoi = db.TuLuans.Where(a => a.IdDethi == x.Id).ToList();
            }
            return ds;
        }
        public DeThi themDeThiTuLuan(string tenBaiThi,string giaoVien ,string mon,DateTime time, List<TuLuan>s)
        {
            var kt = new DeThi();
            kt.hinhThuc = "Tu luan";
            kt.ThoiGiangThi = time ;
            kt.maMonHoc = mon;
            kt.TenBaiThi = tenBaiThi;
            kt.TenGiaoVien = giaoVien;
            kt.TinhTrang = "Cho Duyet";
            kt.CauHoi = s;
            db.DeThis.Add(kt);
            db.SaveChanges();
            return kt;
          
        }
        public DeThi XemChiTietDeThi(int id)
        {
           var check = db.DeThis.SingleOrDefault(a => a.Id == id);
            if (check != null)
            {
               
                return new DeThi
                {
                    hinhThuc = check.hinhThuc,
                    TinhTrang = check.TinhTrang,
                    TenBaiThi = check.TenBaiThi,
                    TenGiaoVien = check.TenGiaoVien,
                    ThoiGiangThi=check.ThoiGiangThi,
                    maMonHoc = check.maMonHoc,
                    CauHoi = db.TuLuans.Where(a => a.IdDethi == check.Id).ToList(),

                };
            }
            return null;
        }
    }
}
