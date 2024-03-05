﻿// <auto-generated />
using GameApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240305092914_M11")]
    partial class M11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("GameApp.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            Description = "Lorem ipsum",
                            Name = "Cyberpunk 2077",
                            Url = "https://ivankraus.com"
                        },
                        new
                        {
                            GameID = 2,
                            Description = "Peak hra",
                            Name = "Escape the fortress",
                            Url = "https://pslib.cloud/EscapeTheFortress"
                        });
                });

            modelBuilder.Entity("GameApp.Models.GamesGenres", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenreId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GamesGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 5,
                            GameId = 1
                        },
                        new
                        {
                            GenreId = 7,
                            GameId = 1
                        },
                        new
                        {
                            GenreId = 6,
                            GameId = 2
                        });
                });

            modelBuilder.Entity("GameApp.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreID = 5,
                            Name = "Cyberpunk"
                        },
                        new
                        {
                            GenreID = 6,
                            Name = "RPG"
                        },
                        new
                        {
                            GenreID = 7,
                            Name = "Action"
                        });
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<int>("GamesGameID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenresGenreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesGameID", "GenresGenreID");

                    b.HasIndex("GenresGenreID");

                    b.ToTable("GameGenre");
                });

            modelBuilder.Entity("GameApp.Models.GamesGenres", b =>
                {
                    b.HasOne("GameApp.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameApp.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("GameApp.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameApp.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
