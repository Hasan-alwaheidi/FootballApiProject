namespace FootballApiProject.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Season { get; set; }
        public string LogoPath { get; set; } = "/images/default.jpg";

        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public string? Description { get; set; }
    }
}
