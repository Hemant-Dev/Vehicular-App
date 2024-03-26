using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicular.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedColorPropAndTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInfo_ManufacturerInfo_manufacturerId",
                table: "CarInfo");

            migrationBuilder.RenameColumn(
                name: "manufacturerId",
                table: "CarInfo",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarInfo_manufacturerId",
                table: "CarInfo",
                newName: "IX_CarInfo_ManufacturerId");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "CarInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ColorInfo",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfo", x => x.ColorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarInfo_ColorId",
                table: "CarInfo",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfo_ColorInfo_ColorId",
                table: "CarInfo",
                column: "ColorId",
                principalTable: "ColorInfo",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfo_ManufacturerInfo_ManufacturerId",
                table: "CarInfo",
                column: "ManufacturerId",
                principalTable: "ManufacturerInfo",
                principalColumn: "manufacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInfo_ColorInfo_ColorId",
                table: "CarInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CarInfo_ManufacturerInfo_ManufacturerId",
                table: "CarInfo");

            migrationBuilder.DropTable(
                name: "ColorInfo");

            migrationBuilder.DropIndex(
                name: "IX_CarInfo_ColorId",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "CarInfo");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "CarInfo",
                newName: "manufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarInfo_ManufacturerId",
                table: "CarInfo",
                newName: "IX_CarInfo_manufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfo_ManufacturerInfo_manufacturerId",
                table: "CarInfo",
                column: "manufacturerId",
                principalTable: "ManufacturerInfo",
                principalColumn: "manufacturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
