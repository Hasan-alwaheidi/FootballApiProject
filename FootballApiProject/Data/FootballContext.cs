using FootballApiProject.Models;
using FootballApiProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EndProject.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<News> NewsItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure League
            modelBuilder.Entity<League>(entity =>
            {
                entity.HasKey(e => e.LeagueId);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Country)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Season)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.LogoPath)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(e => e.Description)  // Add Description field
                      .HasMaxLength(500);

                entity.HasMany(e => e.Teams)
                      .WithOne(e => e.League)
                      .HasForeignKey(e => e.LeagueId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Team
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Coach)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LogoPath)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(e => e.Description)  // Add Description field
                      .HasMaxLength(500);

                entity.HasOne(e => e.Stadium)
                      .WithMany()
                      .HasForeignKey(e => e.StadiumId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Players)
                      .WithOne(e => e.Team)
                      .HasForeignKey(e => e.TeamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Player
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Nationality)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Position)
                      .IsRequired();

                entity.Property(e => e.ProfilePicturePath)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(e => e.Description)  // Add Description field
                      .HasMaxLength(500);

                entity.HasOne(e => e.Team)
                      .WithMany(e => e.Players)
                      .HasForeignKey(e => e.TeamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Stadium
            modelBuilder.Entity<Stadium>(entity =>
            {
                modelBuilder.Entity<Stadium>()
                    .HasKey(s => s.StadiumId);

                modelBuilder.Entity<Stadium>()
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                modelBuilder.Entity<Stadium>()
                    .Property(s => s.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                modelBuilder.Entity<Stadium>()
                    .Property(s => s.Capacity)
                    .IsRequired();

                modelBuilder.Entity<Stadium>()
                    .Property(s => s.Description)  // Add Description field
                    .HasMaxLength(500);

                modelBuilder.Entity<Stadium>()
                    .HasMany(s => s.Teams)
                    .WithOne(t => t.Stadium)
                    .HasForeignKey(t => t.StadiumId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            // Configure Match
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.Property(e => e.Date)
                      .IsRequired();

                entity.Property(e => e.Score)
                      .HasMaxLength(10);

                entity.HasOne(e => e.HomeTeam)
                      .WithMany()
                      .HasForeignKey(e => e.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AwayTeam)
                      .WithMany()
                      .HasForeignKey(e => e.AwayTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure News
            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Content)
                      .IsRequired();

                entity.Property(e => e.ImagePath)
                      .HasMaxLength(256);

                entity.Property(e => e.DatePublished)
                      .IsRequired();
            });

            // Seed data
            SeedData.AddRecord(modelBuilder);
        }
    }
}
