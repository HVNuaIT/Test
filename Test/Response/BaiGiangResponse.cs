﻿using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class BaiGiangResponse : IBaiGiang
    {
        private readonly Database db;
        public static int pagesize { get; set; } = 5;
        public BaiGiangResponse(Database db)
        {
            this.db = db;
        }

        public  async Task<byte[]> DownloadFile(int id)
        {
            try
            {
                var selectedFile = db.BaiGiangs
                    .Where(f => f.maBaiGiang == id)
                    .SingleOrDefault();

                if (selectedFile == null)
                    return null;
                return selectedFile.Content;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FileUploadResponse> UploadFile(List<IFormFile> File,string maMonHoc, string tenBaiGiang)
        {
            long size = File.Sum(f => f.Length);

            List<FileUploadResponseData> uploadedFiles = new List<FileUploadResponseData>();

            try
            {
                foreach (var f in File)
                {
                    string name = f.FileName.Replace(@"\\\\", @"\\");

                    if (f.Length > 0)
                    {
                        var memoryStream = new MemoryStream();

                        try
                        {
                            await f.CopyToAsync(memoryStream);
                          
                            if (memoryStream.Length < 20971521111111111)
                            {
                                var check = db.MonHocs.FirstOrDefault(x => x.maMonHoc == maMonHoc);
                                
                                var nameGV = "";
                                var tenLop = "";
                                if (check != null )
                                {
                                   
                                    var giaovien = db.GiaoViens.FirstOrDefault(a => a.maGiaoVien == check.maGiaoVien);
                                    if (giaovien != null)
                                    {
                                        var user = db.Users.FirstOrDefault(b => b.Id == giaovien.maTK);
                                        if (user != null)
                                        {
                                            nameGV = user.Name;
                                           
                                        }
                                    }
                                    var checkLop = db.Lops.FirstOrDefault(c => c.maLop == check.maLop);
                                    if (checkLop != null)
                                    {
                                        tenLop = checkLop.tenLop;
                                    }
                                }
                                var file = new BaiGiang()
                                {
                                    tenBaiGiang = Path.GetFileName(tenBaiGiang),
                                    kichThuc = (byte)memoryStream.Length,
                                    NgayUpload = DateTime.Now,
                                    UpdateByMember = nameGV,
                                    TrangThai = false,
                                    ghiChu = "",
                                    maMonHoc=maMonHoc,
                                    Content = memoryStream.ToArray()
                                };
                                var thongbao = new ThongBao()
                                {
                                    tieuDeThongBao = "Giao Vien " + nameGV + " Da them bai giang" + tenBaiGiang,
                                    TenNguoiThongBao = nameGV,
                                    //maLop = tenLop,
                                    //trangThai= false,
                                    
                                };
                              
                                db.BaiGiangs.Add(file);
                                db.ThongBaos.Add(thongbao);
                                await db.SaveChangesAsync();

                                uploadedFiles.Add(new FileUploadResponseData()
                                {
                                    
                                    Status = "OK",
                                    FileName = Path.GetFileName(name),
                                    ErrorMessage = "",
                                });
                            }
                            else
                            {
                                uploadedFiles.Add(new FileUploadResponseData()
                                {
                                    Id = 0,
                                    Status = "ERROR",
                                    FileName = Path.GetFileName(name),
                                    ErrorMessage = "File " + f + " Upload that bai"
                                });
                            }
                        }
                        finally
                        {
                            memoryStream.Close();
                            memoryStream.Dispose();
                        }
                    }
                }
                return new FileUploadResponse() { Data = uploadedFiles, ErrorMessage = "" };
            }
            catch (Exception ex)
            {
                return new FileUploadResponse() { ErrorMessage = ex.Message.ToString() };
            }
        }
        public async Task<IEnumerable<FileDownloadView>> DownloadFiles(int page =1)
        {
            IEnumerable<FileDownloadView> downloadFiles =
            db.BaiGiangs.ToList().Select(f =>
                new FileDownloadView
                {
                    Id = f.maBaiGiang,
                    FileName = f.tenBaiGiang,
                    FileSize = f.Content.Length
                }
            ).Skip((page-1)*pagesize).Take(pagesize);
            return downloadFiles;
        }

        public BaiGiang DuyetBai(bool trangThai, int id,string ghiChu)
        {
            var check = db.BaiGiangs.SingleOrDefault(x => x.maBaiGiang == id);
            if( check !=null && trangThai == true ) 
            {
                check.TrangThai = true;
                check.ghiChu = ghiChu;
                if(trangThai == false)
                {
                    check.TrangThai = false;
                    check.ghiChu = ghiChu;

                }
                db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
          
           
            return null;
        }
        
        public List<BaiGiangViewModel> GetALl(int page = 1)
        {
            var checkds = db.BaiGiangs.AsQueryable();
            checkds = checkds.Skip((page - 1) * pagesize).Take(pagesize);
            //var checkmonhoc = db.MonHocs.FirstOrDefault();
            var tenMon = "";
            var check = db.MonHocs.FirstOrDefault(x => x.maMonHoc == checkds.FirstOrDefault().maMonHoc);
            var nameGV = "";
            if (check != null)
            {
                tenMon = check.tenMonHoc;
                var giaovien = db.GiaoViens.FirstOrDefault(a => a.maGiaoVien == check.maGiaoVien);
                if (giaovien != null)
                {
                    var user = db.Users.FirstOrDefault(b => b.Id == giaovien.maTK);
                    if (user != null)
                    {
                        nameGV = user.Name;
                    }
                }
            } 
                var kqtv = checkds.Select(x => new BaiGiangViewModel
                {
                   tenBaiGiang = x.tenBaiGiang,
                   monHoc = tenMon,
                   nguoiSoHuu  = nameGV,
                   suaDoiLanCuoi=x.NgayUpload,
                   kichthuoc = x.kichThuc
                });
                return kqtv.ToList();
        }
        public void Delete(string tenBaiGiang)
        {
           var checkBG = db.BaiGiangs.SingleOrDefault(x=>x.tenBaiGiang.Equals(tenBaiGiang));
            if (checkBG != null )
            {
                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = checkBG.UpdateByMember + "DA XOA BAI GIANG " + checkBG.tenBaiGiang;
                thongBao.TenNguoiThongBao = checkBG.UpdateByMember;
                
                db.BaiGiangs.Remove(checkBG);
                db.ThongBaos.Add(thongBao);
                db.SaveChanges();
            }
        }

        public void Update(List<IFormFile> File, int id)
        {
            throw new NotImplementedException();
        }
    }
}