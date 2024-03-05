using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameApp.Migrations
{
    /// <inheritdoc />
    public partial class M10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[] { 1, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 5 });
        }
    }
}
