using System.ComponentModel.DataAnnotations;

namespace websiteSPcongnghe.Models
{
    public class Dondathang
    {
        public int DondathangID { get; set; }

        public DateTime Ngaylap {  get; set; }

        public string? HovaTen { get; set; }

        public string? Diachi { get; set; }

        public string? Sdt { get; set; }

        public string? Email { get; set; }

        public string? Ghichu { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}đ")]
        public int Tongtien { get; set; }
    }
}
