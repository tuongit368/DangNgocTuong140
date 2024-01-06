using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DangNgocTuong140.Models
{
    public class LopHoc
    {
        [Key]
        public string MaLopHoc { get; set; }
        public int SoLopHoc { get; set; }
        
        public string MaHocSinh { get; set; }
        [ForeignKey("MaHocSinh")]

        public HocSinh? HocSinh { get; set; }

    }
}