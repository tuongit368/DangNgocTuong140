using System.ComponentModel.DataAnnotations;

namespace DangNgocTuong140.Models
{
    public class HocSinh
    {
        [Key]
        public string MaHocSinh { get; set; }
        public int SoDienThoai { get; set; }
        public float Diem { get; set; }
    }
}