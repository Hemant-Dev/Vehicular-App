using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicular.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeEngineTypeAndBrakeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrakeType",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "CarInfo");

            migrationBuilder.AddColumn<int>(
                name: "BrakeId",
                table: "CarInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "CarInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brakes",
                columns: table => new
                {
                    BrakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrakeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brakes", x => x.BrakeId);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarInfo_BrakeId",
                table: "CarInfo",
                column: "BrakeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarInfo_EngineId",
                table: "CarInfo",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfo_Brakes_BrakeId",
                table: "CarInfo",
                column: "BrakeId",
                principalTable: "Brakes",
                principalColumn: "BrakeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarInfo_Engines_EngineId",
                table: "CarInfo",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "EngineId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInfo_Brakes_BrakeId",
                table: "CarInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CarInfo_Engines_EngineId",
                table: "CarInfo");

            migrationBuilder.DropTable(
                name: "Brakes");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_CarInfo_BrakeId",
                table: "CarInfo");

            migrationBuilder.DropIndex(
                name: "IX_CarInfo_EngineId",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "BrakeId",
                table: "CarInfo");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "CarInfo");

            migrationBuilder.AddColumn<string>(
                name: "BrakeType",
                table: "CarInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                table: "CarInfo",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
