using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
   // [Table("CauHoiTracNghiem")]
    public class CauHoiTracNghiem
    {
        [Key]
        public int maCauHoiTN { get; set; }
      
        public string tieuDeCauHoi { get; set; }
        public string dapAn1 { get; set; }
        public string dapAn2 { get; set; }
        public string dapAn3 { get; set; }
        public string dapAn4 { get; set; }
        public string dapAnChinhXac { get; set; }
       


    }
}
