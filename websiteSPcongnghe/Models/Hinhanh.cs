namespace websiteSPcongnghe.Models
{
    public class Hinhanh
    {
        public int HinhanhID { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanphams { get; set; }

        public string? Anh { get; set; }
    }
}
