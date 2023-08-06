using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface ICauHoi
    {
        CauHoiDTO DatCauHoi(string tieuDe,string nguoiDatCauHoi,bool like,string noiDung,string mon);
        List<ListHoiDap> GetAllHoiDap(string name,int page = 1);
        List<ListHoiDap> GetAll( int page = 1);
        void Delete(int id);
        void Update(CauHoiDTO x , int id );
        void Like(int id ,bool Like);

    }
}
