namespace websiteSPcongnghe.Models
{
    public class Taikhoan
    {
        public int TaikhoanID { get; set; }
        
        public string? Tendangnhap { get; set; }

        public string? Matkhau { get; set; }

        public string? HovaTen { get; set; }

        public string? Diachi { get; set; }

        public string? Sodt { get; set; }

        public string? Email { get; set; }

        public int QuyenhanID { get; set; }
        public Quyenhan? Quyenhans { get; set; }
    }
}
