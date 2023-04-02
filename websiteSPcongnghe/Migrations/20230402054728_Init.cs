using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websiteSPcongnghe.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Danhmuc",
                columns: table => new
                {
                    DanhmucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendanhmuc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuc", x => x.DanhmucID);
                });

            migrationBuilder.CreateTable(
                name: "Quyenhan",
                columns: table => new
                {
                    QuyenhanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyenhan", x => x.QuyenhanID);
                });

            migrationBuilder.CreateTable(
                name: "Thuonghieu",
                columns: table => new
                {
                    ThuonghieuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenthuonghieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuonghieu", x => x.ThuonghieuID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danhmuc");

            migrationBuilder.DropTable(
                name: "Quyenhan");

            migrationBuilder.DropTable(
                name: "Thuonghieu");
        }
    }
}
