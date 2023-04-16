using System.ComponentModel.DataAnnotations;

namespace websiteSPcongnghe.Models
{
    public class Dathangchitiet
    {
        public int DathangchitietID { get; set; }

        public int DondathangID { get; set; }
        public Dondathang? Dondathang { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanpham { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}đ")]
        public int Dongia { get; set; }

        public int Soluong { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}đ")]
        public int Thanhtien { get; set; }
    }
}
