using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IDeThi_KiemTra
    {
        DeThi themDeThiTuLuan(string tenBaiThi, string mon, string giaoVien,DateTime time, List<TuLuan>s);
      // DeThi themDeThiTracNghiem(string tenBaiThi, string mon, string giaoVien, DateTime time, List<CauHoiKT> s);
        List<DeThi> getAll();
        DeThi XemChiTietDeThi(int id);
        DeThi DuyetTuLuat(int id,string trangThai);
    }
}
