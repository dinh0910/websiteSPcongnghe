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
    }
}
