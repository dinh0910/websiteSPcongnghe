namespace websiteSPcongnghe.Models
{
    public class Khuyenmai
    {
        public int KhuyenmaiID { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanphams { get; set; }

        public string Ten { get; set; }
    }
}
