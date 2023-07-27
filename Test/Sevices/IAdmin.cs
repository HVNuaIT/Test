using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IAdmin
    {
        AdminDTO AddAdmin(AdminDTO adminDTO);
        void UpdateAdmin(IFormFile file,string id);
        void Delete(string id);
      
       

    }
}
