using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dondathang",
                columns: table => new
                {
                    DondathangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngaylap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tongtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dondathang", x => x.DondathangID);
                });

            migrationBuilder.CreateTable(
                name: "Dathangchitiet",
                columns: table => new
                {
                    DathangchitietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DondathangID = table.Column<int>(type: "int", nullable: false),
                    SanphamID = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dathangchitiet", x => x.DathangchitietID);
                    table.ForeignKey(
                        name: "FK_Dathangchitiet_Dondathang_DondathangID",
                        column: x => x.DondathangID,
                        principalTable: "Dondathang",
                        principalColumn: "DondathangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dathangchitiet_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "SanphamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dathangchitiet_DondathangID",
                table: "Dathangchitiet",
                column: "DondathangID");

            migrationBuilder.CreateIndex(
                name: "IX_Dathangchitiet_SanphamID",
                table: "Dathangchitiet",
                column: "SanphamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dathangchitiet");

            migrationBuilder.DropTable(
                name: "Dondathang");
        }
    }
}
