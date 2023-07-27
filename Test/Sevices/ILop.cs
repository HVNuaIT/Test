using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface ILop
    {
        LopDTO Add(LopDTO x);
        void Update(string id, LopViewModel x);
        void Delete(string id);
    }
}
