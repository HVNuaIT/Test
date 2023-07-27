using Test.Model;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IBaiGiang
    {
       Task <FileUploadResponse> UploadFile(List<IFormFile>File,string maMonHoc,string tenBaiGiang);
        Task<byte[]> DownloadFile(int id);
        Task<IEnumerable<FileDownloadView>> DownloadFiles(int page=1);
         BaiGiang DuyetBai(bool trangThai,int id,string ghiChu);
        List<BaiGiangViewModel> GetALl(int page = 1);
        void Delete(string tenBaiGiang);
       

    }
}
