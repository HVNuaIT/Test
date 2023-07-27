using System.Xml.Serialization;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IKhoa
    {
        KhoaDTO Add(KhoaDTO dto);
        void Delete(string id);
        void update(string id,string tenKhoa);
        List<KhoaDTO> GetAll(int page=1);
    }
}
