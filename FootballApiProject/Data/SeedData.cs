﻿using FootballApiProject.Enums;
using FootballApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApiProject.Data
{
    public class SeedData
    {
        public static void AddRecord(ModelBuilder modelBuilder)
        {
            // Seed Leagues
            modelBuilder.Entity<League>().HasData(
                new League { LeagueId = 1, Name = "Premier League", Country = "England", Season = "2023/2024", LogoPath = "/images/default.jpg" },
                new League { LeagueId = 2, Name = "La Liga", Country = "Spain", Season = "2023/2024", LogoPath = "/images/default.jpg" },
                new League { LeagueId = 3, Name = "Bundesliga", Country = "Germany", Season = "2023/2024", LogoPath = "/images/default.jpg" },
                new League { LeagueId = 4, Name = "Serie A", Country = "Italy", Season = "2023/2024", LogoPath = "/images/default.jpg" },
                new League { LeagueId = 5, Name = "Ligue 1", Country = "France", Season = "2023/2024", LogoPath = "/images/default.jpg" }
            );

            // Seed Stadiums
            modelBuilder.Entity<Stadium>().HasData(
                new Stadium { StadiumId = 1, Name = "Old Trafford", Location = "Manchester, England", Capacity = 76000, ImagePath = "/images/stadiums/old_trafford.jpg" },
                new Stadium { StadiumId = 2, Name = "Camp Nou", Location = "Barcelona, Spain", Capacity = 99354, ImagePath = "/images/stadiums/camp_nou.jpg" },
                new Stadium { StadiumId = 3, Name = "Allianz Arena", Location = "Munich, Germany", Capacity = 75000, ImagePath = "/images/stadiums/allianz_arena.jpg" },
                new Stadium { StadiumId = 4, Name = "San Siro", Location = "Milan, Italy", Capacity = 80000, ImagePath = "/images/stadiums/san_siro.jpg" },
                new Stadium { StadiumId = 5, Name = "Parc des Princes", Location = "Paris, France", Capacity = 47929, ImagePath = "/images/stadiums/parc_des_princes.jpg" }
            );

            // Seed Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, Name = "Manchester United", StadiumId = 1, LeagueId = 1, Coach = "Erik ten Hag", LogoPath = "/images/default.jpg" },
                new Team { TeamId = 2, Name = "Barcelona", StadiumId = 2, LeagueId = 2, Coach = "Xavi Hernandez", LogoPath = "/images/default.jpg" },
                new Team { TeamId = 3, Name = "Bayern Munich", StadiumId = 3, LeagueId = 3, Coach = "Julian Nagelsmann", LogoPath = "/images/default.jpg" },
                new Team { TeamId = 4, Name = "AC Milan", StadiumId = 4, LeagueId = 4, Coach = "Stefano Pioli", LogoPath = "/images/default.jpg" },
                new Team { TeamId = 5, Name = "Paris Saint-Germain", StadiumId = 5, LeagueId = 5, Coach = "Mauricio Pochettino", LogoPath = "/images/default.jpg" }
            );

            // Seed Players
            modelBuilder.Entity<Player>().HasData(
                new Player { PlayerId = 1, Name = "David de Gea", Position = PlayerPosition.Goalkeeper, TeamId = 1, Nationality = "Spanish", ProfilePicturePath = "/images/playerAvatar.jpg" },
                new Player { PlayerId = 2, Name = "Lionel Messi", Position = PlayerPosition.Forward, TeamId = 2, Nationality = "Argentinian", ProfilePicturePath = "/images/playerAvatar.jpg" },
                new Player { PlayerId = 3, Name = "Robert Lewandowski", Position = PlayerPosition.Forward, TeamId = 3, Nationality = "Polish", ProfilePicturePath = "/images/playerAvatar.jpg" },
                new Player { PlayerId = 4, Name = "Zlatan Ibrahimovic", Position = PlayerPosition.Forward, TeamId = 4, Nationality = "Swedish", ProfilePicturePath = "/images/playerAvatar.jpg" },
                new Player { PlayerId = 5, Name = "Kylian Mbappe", Position = PlayerPosition.Forward, TeamId = 5, Nationality = "French", ProfilePicturePath = "/images/playerAvatar.jpg" }
            );

            // Seed Matches
            modelBuilder.Entity<Match>().HasData(
                new Match { MatchId = 1, HomeTeamId = 1, AwayTeamId = 2, Date = DateTime.Now.AddDays(-1), Score = "2-1", Result = MatchResult.HomeWin },
                new Match { MatchId = 2, HomeTeamId = 3, AwayTeamId = 4, Date = DateTime.Now, Score = "1-1", Result = MatchResult.Draw },
                new Match { MatchId = 3, HomeTeamId = 5, AwayTeamId = 1, Date = DateTime.Now.AddDays(1), Score = "", Result = null }
            );

            // Seed NewsItems
            modelBuilder.Entity<News>().HasData(
                new News { Id = 1, Title = "New Signing for Manchester United", Content = "Manchester United has signed a new forward.", ImagePath = "/newsimages/news1.jpg", DatePublished = DateTime.Now.AddDays(-5) },
                new News { Id = 2, Title = "Champions League Results", Content = "Barcelona won the Champions League quarterfinals.", ImagePath = "/newsimages/news2.jpg", DatePublished = DateTime.Now.AddDays(-2) }
            );
        }
    }
}