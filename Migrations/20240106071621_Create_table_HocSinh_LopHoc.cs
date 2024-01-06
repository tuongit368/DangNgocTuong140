using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DangNgocTuong140.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_HocSinh_LopHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    MaHocSinh = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<int>(type: "INTEGER", nullable: false),
                    Diem = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinh", x => x.MaHocSinh);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLopHoc = table.Column<string>(type: "TEXT", nullable: false),
                    SoLopHoc = table.Column<int>(type: "INTEGER", nullable: false),
                    MaHocSinh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLopHoc);
                    table.ForeignKey(
                        name: "FK_LopHoc_HocSinh_MaHocSinh",
                        column: x => x.MaHocSinh,
                        principalTable: "HocSinh",
                        principalColumn: "MaHocSinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaHocSinh",
                table: "LopHoc",
                column: "MaHocSinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "HocSinh");
        }
    }
}
