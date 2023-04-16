using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace websiteSPcongnghe.Models
{
    public class Sanpham
    {
        public int SanphamID { get; set; }

        public string? Tensanpham { get; set; }

        public int DanhmucID { get; set; }
        public Danhmuc? Danhmucs { get; set; }

        public int ThuonghieuID { get; set; }
        public Thuonghieu? Thuonghieus { get; set; }

        public string? Hinhanh { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}đ")]
        public int Dongia { get; set; }

        public int Sale { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}đ")]
        public int Thanhtien { get; set; }

        public int Soluong { get; set; } = 0;

    }
}
