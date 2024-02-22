using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomiWeb.Migrations
{
    /// <inheritdoc />
    public partial class addOcijenatoArtiklToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ocjena",
                table: "Artikli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Artikli",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocjena",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artikli",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocjena",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artikli",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocjena",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artikli",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocjena",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artikli",
                keyColumn: "Id",
                keyValue: 5,
                column: "Ocjena",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "Artikli");
        }
    }
}
