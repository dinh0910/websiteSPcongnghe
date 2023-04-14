using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace websiteSPcongnghe.Models
{
    public class Nhapchitiet
    {
        public int NhapchitietID { get; set; }

        public int NhapsanphamID { get; set; }
        public Nhapsanpham? Nhapsanphams { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanphams { get; set; }

        public int DonvitinhID { get; set; }
        public Donvitinh? Donvitinhs { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int Dongia { get; set; }

        public int Soluong { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int Thanhtien { get; set; }
    }
}
