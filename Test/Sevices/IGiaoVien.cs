using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IGiaoVien
    {
        GiaoVienDTO Add(GiaoVienDTO x);
        void Update(IFormFile HinhAnh, string id);
        void Delete(string id);

    }
}
