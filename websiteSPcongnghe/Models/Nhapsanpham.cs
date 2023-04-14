using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace websiteSPcongnghe.Models
{
    public class Nhapsanpham
    {
        public int NhapsanphamID { get; set; }

        public int TaikhoanID { get; set; }
        public Taikhoan? Taikhoans { get; set; }

        public int NhacungcapID { get; set; }
        public Nhacungcap? Nhacungcaps { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngaynhap { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int Tongtien { get; set; }

        public ICollection<Nhapchitiet>? Nhapchitiets { get; set; }
    }
}
