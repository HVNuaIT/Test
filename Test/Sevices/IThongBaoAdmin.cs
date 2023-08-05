using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IThongBaoAdmin
    {
       List<ThongBaoAdminDTO>Getall(int page =1);
        void delete(int id);
        void DeleteAll();
    }
}
