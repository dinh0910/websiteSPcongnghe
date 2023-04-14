namespace websiteSPcongnghe.Models
{
    public class ThongTin
    {
        public int ThongtinID { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanpham { get; set; }

        public string? Tronghop { get; set; }

        public string? Baohanh { get; set; }

        public string? Chinhsach { get; set; }
    }
}
