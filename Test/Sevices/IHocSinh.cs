using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IHocSinh
    {
        HocSinhDTO Add(HocSinhDTO x);
        void Update(IFormFile HinhAnh, string id);
        void Delete(string id);
    }
}
