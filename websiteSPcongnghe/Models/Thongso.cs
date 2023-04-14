namespace websiteSPcongnghe.Models
{
    public class Thongso
    {
        public int ThongsoID { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanphams { get; set; }

        public string? Tenthongso { get; set; }

        public string? Noidung { get; set; }

    }
}
