using FootballApiProject.Enums;
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
                new League { LeagueId = 1, Name = "Premier League", Country = "England", Season = "2023/2024", LogoPath = "/images/default.jpg", Description = "The top level of the English football league system." },
                new League { LeagueId = 2, Name = "La Liga", Country = "Spain", Season = "2023/2024", LogoPath = "/images/default.jpg", Description = "The men's top professional football division of the Spanish football league system." },
                new League { LeagueId = 3, Name = "Bundesliga", Country = "Germany", Season = "2023/2024", LogoPath = "/images/default.jpg", Description = "A professional association football league in Germany." },
                new League { LeagueId = 4, Name = "Serie A", Country = "Italy", Season = "2023/2024", LogoPath = "/images/default.jpg", Description = "A professional league competition for football clubs located at the top of the Italian football league system." },
                new League { LeagueId = 5, Name = "Ligue 1", Country = "France", Season = "2023/2024", LogoPath = "/images/default.jpg", Description = "The French professional league for men's association football clubs." }
            );

            // Seed Stadiums
            modelBuilder.Entity<Stadium>().HasData(
                new Stadium { StadiumId = 1, Name = "Old Trafford", Location = "Manchester, England", Capacity = 76000, ImagePath = "/images/stadiums/old_trafford.jpg", Description = "The home of Manchester United, known as 'The Theatre of Dreams'." },
                new Stadium { StadiumId = 2, Name = "Camp Nou", Location = "Barcelona, Spain", Capacity = 99354, ImagePath = "/images/stadiums/camp_nou.jpg", Description = "The home of FC Barcelona, the largest stadium in Spain and Europe." },
                new Stadium { StadiumId = 3, Name = "Allianz Arena", Location = "Munich, Germany", Capacity = 75000, ImagePath = "/images/stadiums/allianz_arena.jpg", Description = "A football stadium in Munich with a unique exterior design." },
                new Stadium { StadiumId = 4, Name = "San Siro", Location = "Milan, Italy", Capacity = 80000, ImagePath = "/images/stadiums/san_siro.jpg", Description = "One of the most iconic stadiums in Italy, home to AC Milan." },
                new Stadium { StadiumId = 5, Name = "Parc des Princes", Location = "Paris, France", Capacity = 47929, ImagePath = "/images/stadiums/parc_des_princes.jpg", Description = "The home of Paris Saint-Germain, located in Paris." }
            );

            // Seed Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, Name = "Manchester United", StadiumId = 1, LeagueId = 1, Coach = "Erik ten Hag", LogoPath = "/images/default.jpg", Description = "One of the most successful clubs in English football." },
                new Team { TeamId = 2, Name = "Barcelona", StadiumId = 2, LeagueId = 2, Coach = "Xavi Hernandez", LogoPath = "/images/default.jpg", Description = "A dominant force in Spanish and European football." },
                new Team { TeamId = 3, Name = "Bayern Munich", StadiumId = 3, LeagueId = 3, Coach = "Julian Nagelsmann", LogoPath = "/images/default.jpg", Description = "The most successful football club in Germany." },
                new Team { TeamId = 4, Name = "AC Milan", StadiumId = 4, LeagueId = 4, Coach = "Stefano Pioli", LogoPath = "/images/default.jpg", Description = "One of the most successful football clubs in Italy." },
                new Team { TeamId = 5, Name = "Paris Saint-Germain", StadiumId = 5, LeagueId = 5, Coach = "Mauricio Pochettino", LogoPath = "/images/default.jpg", Description = "A dominant club in French football with numerous titles." }
            );

            // Seed Players
            modelBuilder.Entity<Player>().HasData(
                new Player { PlayerId = 1, Name = "David de Gea", Position = PlayerPosition.Goalkeeper, TeamId = 1, Nationality = "Spanish", ProfilePicturePath = "/images/playerAvatar.jpg", Description = "A world-class goalkeeper known for his incredible reflexes." },
                new Player { PlayerId = 2, Name = "Lionel Messi", Position = PlayerPosition.Forward, TeamId = 2, Nationality = "Argentinian", ProfilePicturePath = "/images/playerAvatar.jpg", Description = "Considered one of the greatest football players of all time." },
                new Player { PlayerId = 3, Name = "Robert Lewandowski", Position = PlayerPosition.Forward, TeamId = 3, Nationality = "Polish", ProfilePicturePath = "/images/playerAvatar.jpg", Description = "A prolific goal scorer and one of the best forwards in the world." },
                new Player { PlayerId = 4, Name = "Zlatan Ibrahimovic", Position = PlayerPosition.Forward, TeamId = 4, Nationality = "Swedish", ProfilePicturePath = "/images/playerAvatar.jpg", Description = "Known for his incredible skills and larger-than-life personality." },
                new Player { PlayerId = 5, Name = "Kylian Mbappe", Position = PlayerPosition.Forward, TeamId = 5, Nationality = "French", ProfilePicturePath = "/images/playerAvatar.jpg", Description = "A young, explosive forward with a bright future ahead." }
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
