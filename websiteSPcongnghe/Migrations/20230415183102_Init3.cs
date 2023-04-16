using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Danhmuc_DanhMucID",
                table: "Sanpham");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Thuonghieu_ThuongHieuID",
                table: "Sanpham");

            migrationBuilder.RenameColumn(
                name: "ThuongHieuID",
                table: "Sanpham",
                newName: "ThuonghieuID");

            migrationBuilder.RenameColumn(
                name: "DanhMucID",
                table: "Sanpham",
                newName: "DanhmucID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_ThuongHieuID",
                table: "Sanpham",
                newName: "IX_Sanpham_ThuonghieuID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_DanhMucID",
                table: "Sanpham",
                newName: "IX_Sanpham_DanhmucID");

            migrationBuilder.CreateTable(
                name: "Nhapsanpham",
                columns: table => new
                {
                    NhapsanphamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaikhoanID = table.Column<int>(type: "int", nullable: false),
                    NhacungcapID = table.Column<int>(type: "int", nullable: false),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tongtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhapsanpham", x => x.NhapsanphamID);
                    table.ForeignKey(
                        name: "FK_Nhapsanpham_Nhacungcap_NhacungcapID",
                        column: x => x.NhacungcapID,
                        principalTable: "Nhacungcap",
                        principalColumn: "NhacungcapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhapsanpham_Taikhoan_TaikhoanID",
                        column: x => x.TaikhoanID,
                        principalTable: "Taikhoan",
                        principalColumn: "TaikhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nhapchitiet",
                columns: table => new
                {
                    NhapchitietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhapsanphamID = table.Column<int>(type: "int", nullable: false),
                    SanphamID = table.Column<int>(type: "int", nullable: false),
                    DonvitinhID = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhapchitiet", x => x.NhapchitietID);
                    table.ForeignKey(
                        name: "FK_Nhapchitiet_Donvitinh_DonvitinhID",
                        column: x => x.DonvitinhID,
                        principalTable: "Donvitinh",
                        principalColumn: "DonvitinhID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhapchitiet_Nhapsanpham_NhapsanphamID",
                        column: x => x.NhapsanphamID,
                        principalTable: "Nhapsanpham",
                        principalColumn: "NhapsanphamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhapchitiet_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "SanphamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhapchitiet_DonvitinhID",
                table: "Nhapchitiet",
                column: "DonvitinhID");

            migrationBuilder.CreateIndex(
                name: "IX_Nhapchitiet_NhapsanphamID",
                table: "Nhapchitiet",
                column: "NhapsanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_Nhapchitiet_SanphamID",
                table: "Nhapchitiet",
                column: "SanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_Nhapsanpham_NhacungcapID",
                table: "Nhapsanpham",
                column: "NhacungcapID");

            migrationBuilder.CreateIndex(
                name: "IX_Nhapsanpham_TaikhoanID",
                table: "Nhapsanpham",
                column: "TaikhoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Danhmuc_DanhmucID",
                table: "Sanpham",
                column: "DanhmucID",
                principalTable: "Danhmuc",
                principalColumn: "DanhmucID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Thuonghieu_ThuonghieuID",
                table: "Sanpham",
                column: "ThuonghieuID",
                principalTable: "Thuonghieu",
                principalColumn: "ThuonghieuID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Danhmuc_DanhmucID",
                table: "Sanpham");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Thuonghieu_ThuonghieuID",
                table: "Sanpham");

            migrationBuilder.DropTable(
                name: "Nhapchitiet");

            migrationBuilder.DropTable(
                name: "Nhapsanpham");

            migrationBuilder.RenameColumn(
                name: "ThuonghieuID",
                table: "Sanpham",
                newName: "ThuongHieuID");

            migrationBuilder.RenameColumn(
                name: "DanhmucID",
                table: "Sanpham",
                newName: "DanhMucID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_ThuonghieuID",
                table: "Sanpham",
                newName: "IX_Sanpham_ThuongHieuID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_DanhmucID",
                table: "Sanpham",
                newName: "IX_Sanpham_DanhMucID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Danhmuc_DanhMucID",
                table: "Sanpham",
                column: "DanhMucID",
                principalTable: "Danhmuc",
                principalColumn: "DanhmucID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Thuonghieu_ThuongHieuID",
                table: "Sanpham",
                column: "ThuongHieuID",
                principalTable: "Thuonghieu",
                principalColumn: "ThuonghieuID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
