﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using websiteSPcongnghe.Data;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    [DbContext(typeof(websiteSPcongngheContext))]
    [Migration("20230415064005_Init2")]
    partial class Init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("websiteSPcongnghe.Models.Danhmuc", b =>
                {
                    b.Property<int>("DanhmucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhmucID"), 1L, 1);

                    b.Property<string>("Tendanhmuc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhmucID");

                    b.ToTable("Danhmuc");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.DanhsachBanner", b =>
                {
                    b.Property<int>("DanhsachBannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhsachBannerID"), 1L, 1);

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhsachBannerID");

                    b.ToTable("DanhsachBanner");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Donvitinh", b =>
                {
                    b.Property<int>("DonvitinhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonvitinhID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonvitinhID");

                    b.ToTable("Donvitinh");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhacungcap", b =>
                {
                    b.Property<int>("NhacungcapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhacungcapID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NhacungcapID");

                    b.ToTable("Nhacungcap");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Quyenhan", b =>
                {
                    b.Property<int>("QuyenhanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenhanID"), 1L, 1);

                    b.Property<string>("Quyen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenhanID");

                    b.ToTable("Quyenhan");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Sanpham", b =>
                {
                    b.Property<int>("SanphamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanphamID"), 1L, 1);

                    b.Property<int>("DanhMucID")
                        .HasColumnType("int");

                    b.Property<int>("Dongia")
                        .HasColumnType("int");

                    b.Property<string>("Hinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sale")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("Tensanpham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Thanhtien")
                        .HasColumnType("int");

                    b.Property<int>("ThuongHieuID")
                        .HasColumnType("int");

                    b.HasKey("SanphamID");

                    b.HasIndex("DanhMucID");

                    b.HasIndex("ThuongHieuID");

                    b.ToTable("Sanpham");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Taikhoan", b =>
                {
                    b.Property<int>("TaikhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaikhoanID"), 1L, 1);

                    b.Property<string>("Diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HovaTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matkhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenhanID")
                        .HasColumnType("int");

                    b.Property<string>("Sodt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tendangnhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaikhoanID");

                    b.HasIndex("QuyenhanID");

                    b.ToTable("Taikhoan");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Thuonghieu", b =>
                {
                    b.Property<int>("ThuonghieuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThuonghieuID"), 1L, 1);

                    b.Property<string>("Tenthuonghieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThuonghieuID");

                    b.ToTable("Thuonghieu");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Sanpham", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Danhmuc", "Danhmucs")
                        .WithMany()
                        .HasForeignKey("DanhMucID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Thuonghieu", "Thuonghieus")
                        .WithMany()
                        .HasForeignKey("ThuongHieuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Danhmucs");

                    b.Navigation("Thuonghieus");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Taikhoan", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Quyenhan", "Quyenhans")
                        .WithMany()
                        .HasForeignKey("QuyenhanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyenhans");
                });
#pragma warning restore 612, 618
        }
    }
}