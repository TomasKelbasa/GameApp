using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameApp.Migrations
{
    /// <inheritdoc />
    public partial class sigma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres");

            migrationBuilder.DropIndex(
                name: "IX_GamesGenres_GameId",
                table: "GamesGenres");

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" });

            migrationBuilder.InsertData(
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 7 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenres_GenreId",
                table: "GamesGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres");

            migrationBuilder.DropIndex(
                name: "IX_GamesGenres_GenreId",
                table: "GamesGenres");

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "GamesGenres",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesGenres",
                table: "GamesGenres",
                columns: new[] { "GenreId", "GameId" });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "INTEGER", nullable: false),
                    GenresGenreID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesGameID, x.GenresGenreID });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresGenreID",
                        column: x => x.GenresGenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GamesGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 6 },
                    { 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenres_GameId",
                table: "GamesGenres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresGenreID",
                table: "GameGenre",
                column: "GenresGenreID");
        }
    }
}
