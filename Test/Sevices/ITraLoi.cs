using Test.Model.DTO;

namespace Test.Sevices
{
    public interface ITraLoi
    {
        TraLoiDTO TraLoiCauHoi(string tenNguoiTL,string NoiDung,int maCauHoi);
        void Update(int id , TraLoiDTO x);
        void Delete(int id);
    }
}
