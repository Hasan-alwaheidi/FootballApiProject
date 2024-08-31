namespace FootballApiProject.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int StadiumId { get; set; }
        public int LeagueId { get; set; }
        public string Coach { get; set; }
        public Stadium Stadium { get; set; }
        public League League { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Player> Players { get; set; }
        public string? LogoPath { get; set; }
        public string? Description { get; set; }
    }
}
