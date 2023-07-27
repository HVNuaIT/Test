using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IMonHoc
    {
        MonHocDTO Add(MonHocDTO monHocDTO);
        void Delete(string id);
        void Update(MonHocViewModel monHocDTO,string id);
    }
}
