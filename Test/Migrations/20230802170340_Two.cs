using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeThiTuLuan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeThi",
                table: "DeThi");

            migrationBuilder.RenameTable(
                name: "DeThi",
                newName: "DeThi&KiemTra");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGiangThi",
                table: "DeThi&KiemTra",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "DeThi&KiemTra",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeThi&KiemTra",
                table: "DeThi&KiemTra",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeThi&KiemTra",
                table: "DeThi&KiemTra");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "DeThi&KiemTra");

            migrationBuilder.RenameTable(
                name: "DeThi&KiemTra",
                newName: "DeThi");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGiangThi",
                table: "DeThi",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeThi",
                table: "DeThi",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeThiTuLuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeThiId = table.Column<int>(type: "int", nullable: true),
                    IdDethi = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuTuCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThiTuLuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThiTuLuan_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeThiTuLuan_DeThiId",
                table: "DeThiTuLuan",
                column: "DeThiId");
        }
    }
}
