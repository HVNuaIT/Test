using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hinhThuc",
                table: "BaiGiang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TaiNguyen",
                columns: table => new
                {
                    IdTaiNguyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTaiNguyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NgayUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maChuDe = table.Column<int>(type: "int", nullable: false),
                    hinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maBaiGiang = table.Column<int>(type: "int", nullable: false),
                    UpdateByMember = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiNguyen", x => x.IdTaiNguyen);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiNguyen");

            migrationBuilder.DropColumn(
                name: "hinhThuc",
                table: "BaiGiang");
        }
    }
}
