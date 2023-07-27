using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IChuDe
    {
        ChuDeDTO Add(ChuDeDTO x);
        void Delete(int id);
        void Update(ChuDeDTO x,int id);
        List<ChuDeViewModel> GetAll(string maMon);
    }
}
