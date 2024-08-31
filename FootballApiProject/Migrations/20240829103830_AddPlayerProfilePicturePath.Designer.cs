﻿// <auto-generated />
using System;
using EndProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballApiProject.Migrations
{
    [DbContext(typeof(FootballContext))]
    [Migration("20240829103830_AddPlayerProfilePicturePath")]
    partial class AddPlayerProfilePicturePath
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FootballApiProject.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeagueId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            LeagueId = 1,
                            Country = "England",
                            LogoPath = "/images/default.jpg",
                            Name = "Premier League",
                            Season = "2023/2024"
                        },
                        new
                        {
                            LeagueId = 2,
                            Country = "Spain",
                            LogoPath = "/images/default.jpg",
                            Name = "La Liga",
                            Season = "2023/2024"
                        },
                        new
                        {
                            LeagueId = 3,
                            Country = "Germany",
                            LogoPath = "/images/default.jpg",
                            Name = "Bundesliga",
                            Season = "2023/2024"
                        },
                        new
                        {
                            LeagueId = 4,
                            Country = "Italy",
                            LogoPath = "/images/default.jpg",
                            Name = "Serie A",
                            Season = "2023/2024"
                        },
                        new
                        {
                            LeagueId = 5,
                            Country = "France",
                            LogoPath = "/images/default.jpg",
                            Name = "Ligue 1",
                            Season = "2023/2024"
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("Result")
                        .HasColumnType("int");

                    b.Property<string>("Score")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            AwayTeamId = 2,
                            Date = new DateTime(2024, 8, 28, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9590),
                            HomeTeamId = 1,
                            Result = 0,
                            Score = "2-1"
                        },
                        new
                        {
                            MatchId = 2,
                            AwayTeamId = 4,
                            Date = new DateTime(2024, 8, 29, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9662),
                            HomeTeamId = 3,
                            Result = 2,
                            Score = "1-1"
                        },
                        new
                        {
                            MatchId = 3,
                            AwayTeamId = 1,
                            Date = new DateTime(2024, 8, 30, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9665),
                            HomeTeamId = 5,
                            Score = ""
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("NewsItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Manchester United has signed a new forward.",
                            DatePublished = new DateTime(2024, 8, 24, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9701),
                            ImagePath = "/newsimages/news1.jpg",
                            Title = "New Signing for Manchester United"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Barcelona won the Champions League quarterfinals.",
                            DatePublished = new DateTime(2024, 8, 27, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9705),
                            ImagePath = "/newsimages/news2.jpg",
                            Title = "Champions League Results"
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicturePath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            Name = "David de Gea",
                            Nationality = "Spanish",
                            Position = 0,
                            ProfilePicturePath = "/images/playerAvatar.jpg",
                            TeamId = 1
                        },
                        new
                        {
                            PlayerId = 2,
                            Name = "Lionel Messi",
                            Nationality = "Argentinian",
                            Position = 3,
                            ProfilePicturePath = "/images/playerAvatar.jpg",
                            TeamId = 2
                        },
                        new
                        {
                            PlayerId = 3,
                            Name = "Robert Lewandowski",
                            Nationality = "Polish",
                            Position = 3,
                            ProfilePicturePath = "/images/playerAvatar.jpg",
                            TeamId = 3
                        },
                        new
                        {
                            PlayerId = 4,
                            Name = "Zlatan Ibrahimovic",
                            Nationality = "Swedish",
                            Position = 3,
                            ProfilePicturePath = "/images/playerAvatar.jpg",
                            TeamId = 4
                        },
                        new
                        {
                            PlayerId = 5,
                            Name = "Kylian Mbappe",
                            Nationality = "French",
                            Position = 3,
                            ProfilePicturePath = "/images/playerAvatar.jpg",
                            TeamId = 5
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.Stadium", b =>
                {
                    b.Property<int>("StadiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StadiumId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StadiumId");

                    b.ToTable("Stadiums");

                    b.HasData(
                        new
                        {
                            StadiumId = 1,
                            Capacity = 76000,
                            ImagePath = "/images/stadiums/old_trafford.jpg",
                            Location = "Manchester, England",
                            Name = "Old Trafford"
                        },
                        new
                        {
                            StadiumId = 2,
                            Capacity = 99354,
                            ImagePath = "/images/stadiums/camp_nou.jpg",
                            Location = "Barcelona, Spain",
                            Name = "Camp Nou"
                        },
                        new
                        {
                            StadiumId = 3,
                            Capacity = 75000,
                            ImagePath = "/images/stadiums/allianz_arena.jpg",
                            Location = "Munich, Germany",
                            Name = "Allianz Arena"
                        },
                        new
                        {
                            StadiumId = 4,
                            Capacity = 80000,
                            ImagePath = "/images/stadiums/san_siro.jpg",
                            Location = "Milan, Italy",
                            Name = "San Siro"
                        },
                        new
                        {
                            StadiumId = 5,
                            Capacity = 47929,
                            ImagePath = "/images/stadiums/parc_des_princes.jpg",
                            Location = "Paris, France",
                            Name = "Parc des Princes"
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Coach = "Erik ten Hag",
                            LeagueId = 1,
                            LogoPath = "/images/default.jpg",
                            Name = "Manchester United",
                            StadiumId = 1
                        },
                        new
                        {
                            TeamId = 2,
                            Coach = "Xavi Hernandez",
                            LeagueId = 2,
                            LogoPath = "/images/default.jpg",
                            Name = "Barcelona",
                            StadiumId = 2
                        },
                        new
                        {
                            TeamId = 3,
                            Coach = "Julian Nagelsmann",
                            LeagueId = 3,
                            LogoPath = "/images/default.jpg",
                            Name = "Bayern Munich",
                            StadiumId = 3
                        },
                        new
                        {
                            TeamId = 4,
                            Coach = "Stefano Pioli",
                            LeagueId = 4,
                            LogoPath = "/images/default.jpg",
                            Name = "AC Milan",
                            StadiumId = 4
                        },
                        new
                        {
                            TeamId = 5,
                            Coach = "Mauricio Pochettino",
                            LeagueId = 5,
                            LogoPath = "/images/default.jpg",
                            Name = "Paris Saint-Germain",
                            StadiumId = 5
                        });
                });

            modelBuilder.Entity("FootballApiProject.Models.Match", b =>
                {
                    b.HasOne("FootballApiProject.Models.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FootballApiProject.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("FootballApiProject.Models.Player", b =>
                {
                    b.HasOne("FootballApiProject.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballApiProject.Models.Team", b =>
                {
                    b.HasOne("FootballApiProject.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballApiProject.Models.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("FootballApiProject.Models.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("FootballApiProject.Models.Stadium", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("FootballApiProject.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
