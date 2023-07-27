using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IRole
    {
        RoleDTO Add(RoleDTO role);
        void Remove(int id);
        List<RoleDTO> GetAll();
        void Update(int id, RoleDTO role);
    }
}
