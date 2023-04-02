namespace websiteSPcongnghe.Models
{
    public class Dathangchitiet
    {
        public int DathangchitietID { get; set; }

        public int DondathangID { get; set; }
        public Dondathang? Dondathang { get; set; }

        public int SanphamID { get; set; }
        public Sanpham? Sanpham { get; set; }

        public int Dongia { get; set; }

        public int Soluong { get; set; }

        public int Thanhtien { get; set; }
    }
}
