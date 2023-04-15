namespace websiteSPcongnghe.Models
{
    public class CartItem
    {
        public Sanpham? Sanpham { get; set; }
        public int Soluong { get; set; }
    }

    public class ListLove
    {
        public Sanpham? SanPhams { get; set; }
    }

    public class CartImport
    {
        public Sanpham? Sanphams { get; set; }

        public Donvitinh? Donvitinh { get; set; }

        public int Soluong { get; set; }
    }
}
