using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hinhanh",
                columns: table => new
                {
                    HinhanhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanphamID = table.Column<int>(type: "int", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinhanh", x => x.HinhanhID);
                    table.ForeignKey(
                        name: "FK_Hinhanh_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "SanphamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thongso",
                columns: table => new
                {
                    ThongsoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanphamID = table.Column<int>(type: "int", nullable: false),
                    Tenthongso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Noidung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thongso", x => x.ThongsoID);
                    table.ForeignKey(
                        name: "FK_Thongso_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "SanphamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thongtin",
                columns: table => new
                {
                    ThongtinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanphamID = table.Column<int>(type: "int", nullable: false),
                    Tronghop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baohanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chinhsach = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thongtin", x => x.ThongtinID);
                    table.ForeignKey(
                        name: "FK_Thongtin_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "SanphamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hinhanh_SanphamID",
                table: "Hinhanh",
                column: "SanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_Thongso_SanphamID",
                table: "Thongso",
                column: "SanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_Thongtin_SanphamID",
                table: "Thongtin",
                column: "SanphamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hinhanh");

            migrationBuilder.DropTable(
                name: "Thongso");

            migrationBuilder.DropTable(
                name: "Thongtin");
        }
    }
}
