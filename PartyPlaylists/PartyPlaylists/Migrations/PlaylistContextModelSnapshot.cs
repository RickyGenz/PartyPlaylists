﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartyPlaylists.Contexts;

namespace PartyPlaylists.MobileAppService.Migrations
{
    [DbContext(typeof(PlaylistContext))]
    partial class PlaylistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AllowTransferOfControl")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSpotifyEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SpotifyAuthCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("PreviouslyPlayed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("SongAddedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<int>("SongRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SongId");

                    b.ToTable("RoomSongs");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSongToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoomSongId")
                        .HasColumnType("int");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomSongId");

                    b.HasIndex("TokenId");

                    b.ToTable("RoomSongTokens");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlbumArt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ServiceAvailableOn")
                        .HasColumnType("int");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.SpotifyPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthCode")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaylistID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaylistName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaylistOwnerID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("SpotifyPlaylist");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("JWTToken")
                        .IsRequired()
                        .HasColumnName("JWTToken")
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("JWTToken")
                        .IsUnique();

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSong", b =>
                {
                    b.HasOne("PartyPlaylists.Models.DataModels.Room", "Room")
                        .WithMany("RoomSongs")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyPlaylists.Models.DataModels.Song", "Song")
                        .WithMany("RoomSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSongToken", b =>
                {
                    b.HasOne("PartyPlaylists.Models.DataModels.RoomSong", "RoomSong")
                        .WithMany("RoomSongTokens")
                        .HasForeignKey("RoomSongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyPlaylists.Models.DataModels.Token", "Token")
                        .WithMany("RoomSongTokens")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.SpotifyPlaylist", b =>
                {
                    b.HasOne("PartyPlaylists.Models.DataModels.Room", "Room")
                        .WithOne("SpotifyPlaylist")
                        .HasForeignKey("PartyPlaylists.Models.DataModels.SpotifyPlaylist", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
