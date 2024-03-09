
using GameApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GamesGenres> GamesGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(h => h.Games)
                .UsingEntity<GamesGenres>();
            // fluent zápis složitějších věcí
            // seed databáze
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = 1, Name = "Cyberpunk 2077", Url = @"https://ivankraus.com", Description = "Lorem ipsum" },
                new Game { GameID = 2, Name = "Escape the fortress", Url = @"https://pslib.cloud/EscapeTheFortress", Description = "Peak hra" }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 5, Name = "Cyberpunk" },
                new Genre { GenreID = 6, Name = "RPG" },
                new Genre { GenreID = 7, Name = "Action" }
                );

            modelBuilder.Entity<GamesGenres>().HasData(
                new GamesGenres { GameId = 1, GenreId = 5 },
                new GamesGenres { GameId = 1, GenreId = 7 },
                new GamesGenres { GameId = 2, GenreId = 6 }
                );
        }
    }
}
