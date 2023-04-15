namespace websiteSPcongnghe.Models
{
    public class TaikhoanModel
    {
    }

    public class TaiKhoanLogin
    {
        public string? Tendangnhap { get; set; }

        public string Matkhau { get; set; }

        public string? HovaTen { get; set; }

        internal static Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
