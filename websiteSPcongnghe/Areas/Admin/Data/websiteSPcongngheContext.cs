using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Data
{
    public class websiteSPcongngheContext : DbContext
    {
        public websiteSPcongngheContext (DbContextOptions<websiteSPcongngheContext> options)
            : base(options)
        {
        }

        public DbSet<websiteSPcongnghe.Models.Quyenhan> Quyenhan { get; set; } = default!;

        public DbSet<websiteSPcongnghe.Models.Danhmuc>? Danhmuc { get; set; }

        public DbSet<websiteSPcongnghe.Models.Thuonghieu>? Thuonghieu { get; set; }

        public DbSet<websiteSPcongnghe.Models.DanhsachBanner>? DanhsachBanner { get; set; }

        public DbSet<websiteSPcongnghe.Models.Sanpham>? Sanpham { get; set; }

        public DbSet<websiteSPcongnghe.Models.Taikhoan>? Taikhoan { get; set; }

        public DbSet<websiteSPcongnghe.Models.Donvitinh>? Donvitinh { get; set; }

        public DbSet<websiteSPcongnghe.Models.Nhacungcap>? Nhacungcap { get; set; }

        public DbSet<websiteSPcongnghe.Models.Nhapsanpham>? Nhapsanpham { get; set; }

        public DbSet<websiteSPcongnghe.Models.Nhapchitiet>? Nhapchitiet { get; set; }

        public DbSet<websiteSPcongnghe.Models.Thongtin>? Thongtin { get; set; }

        public DbSet<websiteSPcongnghe.Models.Thongso>? Thongso { get; set; }

        public DbSet<websiteSPcongnghe.Models.Hinhanh>? Hinhanh { get; set; }

        public DbSet<websiteSPcongnghe.Models.Dondathang>? Dondathang { get; set; }

        public DbSet<websiteSPcongnghe.Models.Dathangchitiet>? Dathangchitiet { get; set; }

        public DbSet<websiteSPcongnghe.Models.Loaisanpham>? Loaisanpham { get; set; }
    }
}
