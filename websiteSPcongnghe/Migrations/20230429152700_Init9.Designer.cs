﻿// <auto-generated />
using System;
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
    [Migration("20230429152700_Init9")]
    partial class Init9
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

                    b.Property<int>("LoaisanphamID")
                        .HasColumnType("int");

                    b.Property<string>("Tendanhmuc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhmucID");

                    b.HasIndex("LoaisanphamID");

                    b.ToTable("Danhmuc");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.DanhsachBanner", b =>
                {
                    b.Property<int>("DanhsachBannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhsachBannerID"), 1L, 1);

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhsachBannerID");

                    b.ToTable("DanhsachBanner");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Dathangchitiet", b =>
                {
                    b.Property<int>("DathangchitietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DathangchitietID"), 1L, 1);

                    b.Property<int>("DondathangID")
                        .HasColumnType("int");

                    b.Property<int>("Dongia")
                        .HasColumnType("int");

                    b.Property<int>("SanphamID")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<int>("Thanhtien")
                        .HasColumnType("int");

                    b.HasKey("DathangchitietID");

                    b.HasIndex("DondathangID");

                    b.HasIndex("SanphamID");

                    b.ToTable("Dathangchitiet");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Dondathang", b =>
                {
                    b.Property<int>("DondathangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DondathangID"), 1L, 1);

                    b.Property<string>("Diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HovaTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ngaylap")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tongtien")
                        .HasColumnType("int");

                    b.HasKey("DondathangID");

                    b.ToTable("Dondathang");
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

            modelBuilder.Entity("websiteSPcongnghe.Models.Hinhanh", b =>
                {
                    b.Property<int>("HinhanhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhanhID"), 1L, 1);

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanphamID")
                        .HasColumnType("int");

                    b.HasKey("HinhanhID");

                    b.HasIndex("SanphamID");

                    b.ToTable("Hinhanh");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Loaisanpham", b =>
                {
                    b.Property<int>("LoaisanphamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaisanphamID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaisanphamID");

                    b.ToTable("Loaisanpham");
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

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhapchitiet", b =>
                {
                    b.Property<int>("NhapchitietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhapchitietID"), 1L, 1);

                    b.Property<int>("Dongia")
                        .HasColumnType("int");

                    b.Property<int>("DonvitinhID")
                        .HasColumnType("int");

                    b.Property<int>("NhapsanphamID")
                        .HasColumnType("int");

                    b.Property<int>("SanphamID")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<int>("Thanhtien")
                        .HasColumnType("int");

                    b.HasKey("NhapchitietID");

                    b.HasIndex("DonvitinhID");

                    b.HasIndex("NhapsanphamID");

                    b.HasIndex("SanphamID");

                    b.ToTable("Nhapchitiet");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhapsanpham", b =>
                {
                    b.Property<int>("NhapsanphamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhapsanphamID"), 1L, 1);

                    b.Property<DateTime>("Ngaynhap")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhacungcapID")
                        .HasColumnType("int");

                    b.Property<int>("TaikhoanID")
                        .HasColumnType("int");

                    b.Property<int>("Tongtien")
                        .HasColumnType("int");

                    b.HasKey("NhapsanphamID");

                    b.HasIndex("NhacungcapID");

                    b.HasIndex("TaikhoanID");

                    b.ToTable("Nhapsanpham");
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

                    b.Property<int>("DanhmucID")
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

                    b.Property<int>("ThuonghieuID")
                        .HasColumnType("int");

                    b.HasKey("SanphamID");

                    b.HasIndex("DanhmucID");

                    b.HasIndex("ThuonghieuID");

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

            modelBuilder.Entity("websiteSPcongnghe.Models.Thongso", b =>
                {
                    b.Property<int>("ThongsoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongsoID"), 1L, 1);

                    b.Property<string>("Noidung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanphamID")
                        .HasColumnType("int");

                    b.Property<string>("Tenthongso")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThongsoID");

                    b.HasIndex("SanphamID");

                    b.ToTable("Thongso");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Thongtin", b =>
                {
                    b.Property<int>("ThongtinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongtinID"), 1L, 1);

                    b.Property<string>("Baohanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chinhsach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanphamID")
                        .HasColumnType("int");

                    b.Property<string>("Tronghop")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThongtinID");

                    b.HasIndex("SanphamID");

                    b.ToTable("Thongtin");
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

            modelBuilder.Entity("websiteSPcongnghe.Models.Danhmuc", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Loaisanpham", "Loaisanphams")
                        .WithMany()
                        .HasForeignKey("LoaisanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loaisanphams");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Dathangchitiet", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Dondathang", "Dondathang")
                        .WithMany()
                        .HasForeignKey("DondathangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Sanpham", "Sanpham")
                        .WithMany()
                        .HasForeignKey("SanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dondathang");

                    b.Navigation("Sanpham");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Hinhanh", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Sanpham", "Sanphams")
                        .WithMany()
                        .HasForeignKey("SanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhapchitiet", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Donvitinh", "Donvitinhs")
                        .WithMany()
                        .HasForeignKey("DonvitinhID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Nhapsanpham", "Nhapsanphams")
                        .WithMany("Nhapchitiets")
                        .HasForeignKey("NhapsanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Sanpham", "Sanphams")
                        .WithMany()
                        .HasForeignKey("SanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donvitinhs");

                    b.Navigation("Nhapsanphams");

                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhapsanpham", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Nhacungcap", "Nhacungcaps")
                        .WithMany()
                        .HasForeignKey("NhacungcapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Taikhoan", "Taikhoans")
                        .WithMany()
                        .HasForeignKey("TaikhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nhacungcaps");

                    b.Navigation("Taikhoans");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Sanpham", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Danhmuc", "Danhmucs")
                        .WithMany()
                        .HasForeignKey("DanhmucID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websiteSPcongnghe.Models.Thuonghieu", "Thuonghieus")
                        .WithMany()
                        .HasForeignKey("ThuonghieuID")
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

            modelBuilder.Entity("websiteSPcongnghe.Models.Thongso", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Sanpham", "Sanphams")
                        .WithMany()
                        .HasForeignKey("SanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Thongtin", b =>
                {
                    b.HasOne("websiteSPcongnghe.Models.Sanpham", "Sanpham")
                        .WithMany()
                        .HasForeignKey("SanphamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanpham");
                });

            modelBuilder.Entity("websiteSPcongnghe.Models.Nhapsanpham", b =>
                {
                    b.Navigation("Nhapchitiets");
                });
#pragma warning restore 612, 618
        }
    }
}
