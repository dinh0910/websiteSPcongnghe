namespace websiteSPcongnghe.Models
{
    public class Danhmuc
    {
        public int DanhmucID { get; set; }

        public int LoaisanphamID { get; set; }
        public Loaisanpham? Loaisanphams { get; set; }

        public string? Tendanhmuc { get; set; }
    }
}
