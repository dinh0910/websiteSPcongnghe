using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhsachBanner",
                columns: table => new
                {
                    DanhsachBannerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhsachBanner", x => x.DanhsachBannerID);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    SanphamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensanpham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhMucID = table.Column<int>(type: "int", nullable: false),
                    ThuongHieuID = table.Column<int>(type: "int", nullable: false),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dongia = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.SanphamID);
                    table.ForeignKey(
                        name: "FK_Sanpham_Danhmuc_DanhMucID",
                        column: x => x.DanhMucID,
                        principalTable: "Danhmuc",
                        principalColumn: "DanhmucID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanpham_Thuonghieu_ThuongHieuID",
                        column: x => x.ThuongHieuID,
                        principalTable: "Thuonghieu",
                        principalColumn: "ThuonghieuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taikhoan",
                columns: table => new
                {
                    TaikhoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendangnhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HovaTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sodt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyenhanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taikhoan", x => x.TaikhoanID);
                    table.ForeignKey(
                        name: "FK_Taikhoan_Quyenhan_QuyenhanID",
                        column: x => x.QuyenhanID,
                        principalTable: "Quyenhan",
                        principalColumn: "QuyenhanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_DanhMucID",
                table: "Sanpham",
                column: "DanhMucID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_ThuongHieuID",
                table: "Sanpham",
                column: "ThuongHieuID");

            migrationBuilder.CreateIndex(
                name: "IX_Taikhoan_QuyenhanID",
                table: "Taikhoan",
                column: "QuyenhanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhsachBanner");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "Taikhoan");
        }
    }
}
