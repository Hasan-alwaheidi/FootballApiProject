namespace FootballApiProject.Models.DTO_s.LeaguesDto
{
    public class UpdateLeagueDto
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Season { get; set; }
        public string? LogoPath { get; set; }
    }
}
