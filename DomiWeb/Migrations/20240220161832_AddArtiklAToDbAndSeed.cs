using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DomiWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddArtiklAToDbAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikli", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artikli",
                columns: new[] { "Id", "Cijena", "Kategorija", "Naziv" },
                values: new object[,]
                {
                    { 1, 12m, "Voće", "Banane" },
                    { 2, 14m, "Voće", "Jabuke" },
                    { 3, 11m, "Voće", "Kruške" },
                    { 4, 10m, "Povrće", "Krastavac" },
                    { 5, 9m, "Povrće", "Paprika" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikli");
        }
    }
}
