﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartyPlaylists.MobileAppService.Contexts;

namespace PartyPlaylists.MobileAppService.Migrations
{
    [DbContext(typeof(PlaylistContext))]
    [Migration("20191118215751_AddRoomSongTokenTable")]
    partial class AddRoomSongTokenTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSpotifyEnabled");

                    b.Property<string>("Name");

                    b.Property<string>("Owner")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoomId");

                    b.Property<int>("SongId");

                    b.Property<int>("SongRating");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SongId");

                    b.ToTable("RoomSongs");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSongToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoomSongId");

                    b.Property<int>("TokenId");

                    b.HasKey("Id");

                    b.HasIndex("RoomSongId");

                    b.HasIndex("TokenId");

                    b.ToTable("RoomSongTokens");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ServiceAvailableOn");

                    b.Property<string>("SpotifyId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.SpotifyPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthCode")
                        .IsRequired();

                    b.Property<string>("PlaylistID");

                    b.Property<string>("PlaylistName");

                    b.Property<string>("PlaylistOwnerID");

                    b.Property<int>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("SpotifyPlaylist");
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JWTToken")
                        .IsRequired();

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
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PartyPlaylists.Models.DataModels.Song", "Song")
                        .WithMany("RoomSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.RoomSongToken", b =>
                {
                    b.HasOne("PartyPlaylists.Models.DataModels.RoomSong", "RoomSong")
                        .WithMany("RoomSongTokens")
                        .HasForeignKey("RoomSongId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PartyPlaylists.Models.DataModels.Token", "Token")
                        .WithMany("RoomSongTokens")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PartyPlaylists.Models.DataModels.SpotifyPlaylist", b =>
                {
                    b.HasOne("PartyPlaylists.Models.DataModels.Room", "Room")
                        .WithOne("SpotifyPlaylist")
                        .HasForeignKey("PartyPlaylists.Models.DataModels.SpotifyPlaylist", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
